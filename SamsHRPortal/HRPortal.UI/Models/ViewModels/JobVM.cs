using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Models;
using HRPortal.Models.Enums;

namespace HRPortal.UI.Models.ViewModels
{
    public class JobVM
    {

        public Job Job { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> Statuses { get; }


        public JobVM()
        {
            CompanyList = new List<SelectListItem>();

            Statuses = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "0",
                    Text = "Open",

                },
                new SelectListItem()
                {
                    Value = "1",
                    Text = "Filled",

                },
                new SelectListItem()
                {
                    Value = "2",
                    Text = "Pending",

                }
            };
        }


        public void SetCompanyList(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
            {
                CompanyList.Add(new SelectListItem()
                {
                    Value = company.Id.ToString(),
                    Text = company.Name
                });
            }
        }
    }
}