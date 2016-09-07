using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        JobsContext db = new JobsContext();

        /// <summary>
        /// Get the view for job title
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Jobs()
        {
            return View("Jobs");
        }

        /// <summary>
        /// Get the list of jobs for autocomplete 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetJobsTitles(string title)
        {
            List<string> list = db.LuJobTitles
                .Where(x => x.JobTitleText.Contains(title))
                .Select(x => x.JobTitleText).ToList();

            return Json(new
            {
                list
            });
        }

        /// <summary>
        /// Get the list of jobs description
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetJobs(string title)
        {
            List<string> list = db.Jobs
                .Join(db.LuJobTitles,
                    j => j.LuJobTitleId,
                    lj => lj.Id,
                    (j, lj) => new { Jobs = j, LuJobTitle = lj })
                .Where(j => j.LuJobTitle.JobTitleText.Contains(title)).
                Select(j => j.Jobs.JobDescription)
                .ToList();

            return Json(new
            {
                list
            });
        }


        /// <summary>
        /// Get the view for entering the url
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Tags()
        {
            return View("Tags");
        }

        /// <summary>
        /// Get the results of href urls
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetHref(string url)
        {
            List<string> list = new List<string>();
            using (var webclient = new WebClient())
            {
                try
                {
                    string result = webclient.DownloadString(url);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MatchCollection m1 = Regex.Matches(result ,@"href=\""(.*?)\""");
                        list.AddRange(from Match m in m1 where m.Groups[1].Value.Contains(url) select m.Groups[1].Value);
                    }
                }
                catch (Exception)
                {

                }
            }

            return Json(new
            {
                list
            });
        }
    }
}