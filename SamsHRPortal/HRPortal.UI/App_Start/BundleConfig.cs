﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace HRPortal.UI.App_Start
{
    public class BundleConfig
    {
            // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/bootstrap-darkly.min.css",
                "~/Content/Site.css"));
        }
    }
}