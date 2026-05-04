using Multilingual1.Models;
using Multilingual1.Models.ViewModels;
using Multilingual1.Services;
using System;
using System.Web.Mvc;

namespace Multilingual1.Controllers
{
    public class HomeController : Controller
    {
        private readonly PageLanguageLogsBL _PageLanguageLogsBL;

        public HomeController()
            : this(new PageLanguageLogsBL(new MultilingualContext()))
        {
        }

        public HomeController(PageLanguageLogsBL pageLanguageLogsBL)
        {
            _PageLanguageLogsBL = pageLanguageLogsBL;
        }

        public ActionResult Index()
        {
            var model = new PageLanguageLogsVM
            {
                CurrentVersion = _PageLanguageLogsBL.GetCurrentLanguage(),
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SavePageLanguageLogs(string languageName)
        {
            if (string.IsNullOrWhiteSpace(languageName))
                return new HttpStatusCodeResult(400, "請選擇語言。");

            try
            {
                _PageLanguageLogsBL.SaveLanguageChoice(languageName);
                return Json(new { ok = true });
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(500, ex.Message);
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}