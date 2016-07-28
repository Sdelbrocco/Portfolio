using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.BLL.Managers;
using HRPortal.Data.RepoFactory;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class EmployerController : Controller
    {
        JobManager job = new JobManager();
        private ApplicationManager app;

        CompanyManager comp = new CompanyManager();

        public EmployerController()
        {
            app = new ApplicationManager(RepositoryFactory.GetPersonRepo());
        }

        // GET: Employer
        public ActionResult Index()
        {
            var model = comp.GetAllCompanies();
            return View(model);
        }


        public ActionResult SeeApplications()
        {
            var model = app.GetAllApps();
            return View(model);
        }

        //public ActionResult Create()
        //{
        //    Comapny newcomp = new Comapny();
        //    return View();
        //}
    }
}