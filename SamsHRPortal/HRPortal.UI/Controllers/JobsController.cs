using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.BLL.Managers;
using HRPortal.Data.RepoFactory;
using HRPortal.Models;
using HRPortal.UI.Models.ViewModels;

namespace HRPortal.UI.Controllers
{
    public class JobsController : Controller
    {
        JobManager job = new JobManager();
        private readonly ApplicationManager _app;
        CompanyManager comp = new CompanyManager();

        public JobsController()
        {
            _app = new ApplicationManager(RepositoryFactory.GetPersonRepo());

        }
        public ActionResult Index()
        {
            var model = job.GetAllJobs();
            return View(model);
        }


        public ActionResult Details(int jobId)
        {
            var model = job.GetJob(jobId);

            return View(model);
        }


        public ActionResult Apply(int jobId)
        {
            Application newApp = new Application();
            newApp.JobId = jobId;
            return View(newApp);
        }


        [HttpPost]
        public ActionResult Apply([Bind(Include = "JobId, FirstName, LastName, Address, PhoneNumber, Education, Salary, WorkHistory")]Application newApp)
        {
            if (ModelState.IsValid)
            {
                var rsp = this._app.AddApp(newApp);
                if (rsp.Success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", rsp.Message);
            }
            Application app = new Application();
            app.JobId = newApp.JobId;
            return View(app);
        }


        public ActionResult AddJob()
        {
            var viewModel = new JobVM();
            viewModel.SetCompanyList(comp.GetAllCompanies());
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult AddJob([Bind(Include = "CompanyId,Status,Title,JobDescription")]Job job)
        {
            if (ModelState.IsValid)
            {
                var rsp = this.job.AddJob(job);
                if (rsp.Success)
                {
                    return RedirectToAction("Index"); 
                }
                ModelState.AddModelError("", rsp.Message);
            }
            var viewModel = new JobVM();
            viewModel.SetCompanyList(comp.GetAllCompanies());
            viewModel.Job = job;
            return View(viewModel);
        }


        //public ActionResult Edit(int jobId)
        //{
        //    var job = job.GetJob(jobId);


        //    //var student = StudentRepository.Get(id);
        //    //var viewmodel = new StudentVM();
        //    //viewmodel.Student.Address = student.Address;
        //    //return View(viewmodel);
        //}

        //[HttpPost]
        //public ActionResult Edit(JobVM job)
        //{
        //    job.(job.job);
        //    return RedirectToAction("Index");
        //}
    }
}