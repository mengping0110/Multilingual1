using Multilingual1.Models;
using System;
using System.Linq;
using System.Web;

namespace Multilingual1.Services
{
    public class PageLanguageLogsBL
    {
        private readonly MultilingualContext _context;

        public PageLanguageLogsBL(MultilingualContext context)
        {
            _context = context;
        }

        public string GetCurrentLanguage()
        {
            // 檢查資料庫是否有紀錄
            var log = _context.PageLanguageLogs?.OrderByDescending(x => x.CreatedAt).FirstOrDefault();

            if (log != null)
            {
                return log.LanguageName;
            }

            // 資料庫沒紀錄，改抓取瀏覽器語系
            var browserLang = HttpContext.Current?.Request?.Headers["Accept-Language"];

            if (!string.IsNullOrEmpty(browserLang))
            {
                var firstLang = browserLang.Split(',').FirstOrDefault().ToLower();

                if (firstLang.Contains("zh")) return "繁體中文";
                if (firstLang.Contains("ja")) return "日本語";
                if (firstLang.Contains("ko")) return "韓文";
            }

            // 如果都抓不到，回傳預設值
            return "繁體中文";
        }


        public void SaveLanguageChoice(string languageName)
        {
            if (string.IsNullOrWhiteSpace(languageName))
                throw new ArgumentException("語言名稱不可為空白。", nameof(languageName));

            _context.PageLanguageLogs.Add(new PageLanguageLogs
            {
                LanguageName = languageName.Trim(),
                CreatedAt = DateTime.Now,
            });
            _context.SaveChanges();
        }
    }
}