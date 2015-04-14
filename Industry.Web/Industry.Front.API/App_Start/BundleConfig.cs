using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Industry.Front.API
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"
                        , "~/Scripts/angular-route.js"
                        , "~/Scripts/angular-resource.js"
                        //, "~/Scripts/angular-ui/ui-bootstrap-tpls.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/App/app.js"
                        , "~/Scripts/App/config.js"
                        , "~/Scripts/App/Controllers/*.js"
                        //, "~/Scripts/App/Filters/*.js"
                        //, "~/Scripts/App/Services/customers-service.js"
                        //, "~/Scripts/App/Directives/*.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                  "~/Scripts/bootstrap.js"
                //, "~/Scripts/respond.js"
                , "~/Content/Theme/js/app.admin.lte.js"
                //, "~/Content/Theme/js/app.admin.lte.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css"
                 , "~/Content/Theme/css/skins/skin-green.css"
                 , "~/Content/Theme/css/AdminLTE.css"
                 //, "~/Content/Theme/css/AdminLTE.min.css"
                 , "~/Content/font-awesome.css"
                 //, "~/Content/font-awesome.min.css"
                 ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
