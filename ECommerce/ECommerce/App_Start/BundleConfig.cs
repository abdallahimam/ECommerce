using System.Web;
using System.Web.Optimization;

namespace ECommerce
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
							"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
							"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
							"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
						 "~/Scripts/bootstrap.bundle.js"));

			// Admin Layout Scripts
			/**
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						 "~/AdminPanel/plugins/jquery/jquery.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
						 "~/AdminPanel/plugins/jquery-ui/jquery-ui.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/bootstrap4").Include(
						 "~/AdminPanel/plugins/bootstrap/js/bootstrap.bundle.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/chartJS").Include(
						 "~/AdminPanel/plugins/chart.js/Chart.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/sparklines").Include(
						 "~/AdminPanel/plugins/sparklines/sparkline.js"));
			bundles.Add(new ScriptBundle("~/bundles/jqvmap").Include(
						 "~/AdminPanel/plugins/jqvmap/jquery.vmap.min.js",
						 "~/AdminPanel/plugins/jqvmap/maps/jquery.vmap.usa.js"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryknob").Include(
						 "~/AdminPanel/plugins/jquery-knob/jquery.knob.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
						 "~/AdminPanel/plugins/moment/moment.min.js",
						 "~/AdminPanel/plugins/daterangepicker/daterangepicker.js"));
			bundles.Add(new ScriptBundle("~/bundles/tempusdominus").Include(
						 "~/AdminPanel/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
						 "~/AdminPanel/plugins/summernote/summernote-bs4.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/overlayScrollbars").Include(
						 "~/AdminPanel/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
						 "~/AdminPanel/dist/js/adminlte.js"));
			bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
						 "~/AdminPanel/dist/js/pages/dashboard.js"));
			bundles.Add(new ScriptBundle("~/bundles/demo").Include(
						 "~/AdminPanel/dist/js/demo.js"));
			bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
						 "~/AdminPanel/plugins/datatables/jquery.dataTables.min.js",
						 "~/AdminPanel/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
						 "~/AdminPanel/plugins/datatables-responsive/js/dataTables.responsive.min.js",
						 "~/AdminPanel/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"));
			*/

			bundles.Add(new ScriptBundle("~/bundles/adminlayoutjs").Include(
						 "~/AdminPanel/plugins/jquery/jquery.min.js",
						 "~/AdminPanel/plugins/jquery-ui/jquery-ui.min.js",
						 "~/AdminPanel/plugins/bootstrap/js/bootstrap.bundle.min.js",
						 "~/AdminPanel/plugins/chart.js/Chart.min.js",
						 "~/AdminPanel/plugins/sparklines/sparkline.js",
						 "~/AdminPanel/plugins/jqvmap/jquery.vmap.min.js",
						 "~/AdminPanel/plugins/jqvmap/maps/jquery.vmap.usa.js",
						 "~/AdminPanel/plugins/jquery-knob/jquery.knob.min.js",
						 "~/AdminPanel/plugins/moment/moment.min.js",
						 "~/AdminPanel/plugins/daterangepicker/daterangepicker.js",
						 "~/AdminPanel/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
						 "~/AdminPanel/plugins/summernote/summernote-bs4.min.js",
						 "~/AdminPanel/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
						 "~/AdminPanel/plugins/datatables/jquery.dataTables.min.js",
						 "~/AdminPanel/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
						 "~/AdminPanel/plugins/datatables-responsive/js/dataTables.responsive.min.js",
						 "~/AdminPanel/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
						 "~/AdminPanel/dist/js/adminlte.js",
						 "~/AdminPanel/dist/js/pages/dashboard.js",
						 "~/AdminPanel/dist/js/demo.js"
						 ));

			// Add Styles Sheets To Bundles.
			bundles.Add(new StyleBundle("~/Content/css").Include(
						 "~/Content/bootstrap-5.0.0/bootstrap.css",
						 "~/Content/site.css"));
			// Admin Layout Styles
			/**
			bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
				"~/AdminPanel/plugins/fontawesome-free/css/all.min.css"));
			bundles.Add(new StyleBundle("~/bundles/bootstrap4").Include(
				"~/AdminPanel/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"));
			bundles.Add(new StyleBundle("~/bundles/icheck").Include(
				"~/AdminPanel/plugins/icheck-bootstrap/icheck-bootstrap.min.css"));
			bundles.Add(new StyleBundle("~/bundles/jqvmap").Include(
				"~/AdminPanel/plugins/jqvmap/jqvmap.min.css"));
			bundles.Add(new StyleBundle("~/bundles/adminlte").Include(
				"~/AdminPanel/dist/css/adminlte.min.css"));
			bundles.Add(new StyleBundle("~/bundles/overlayScrollbars").Include(
				"~/AdminPanel/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"));
			bundles.Add(new StyleBundle("~/bundles/daterangepicker").Include(
				"~/AdminPanel/plugins/daterangepicker/daterangepicker.css"));
			bundles.Add(new StyleBundle("~/bundles/summernote").Include(
				"~/AdminPanel/plugins/summernote/summernote-bs4.css"));
			bundles.Add(new StyleBundle("~/bundles/datatables").Include(
				"~/AdminPanel/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
				"~/AdminPanel/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"));
			*/

			bundles.Add(new StyleBundle("~/bundles/adminlayoutcss").Include(
				"~/AdminPanel/plugins/fontawesome-free/css/all.min.css",
				"~/AdminPanel/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
				"~/AdminPanel/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
				"~/AdminPanel/plugins/jqvmap/jqvmap.min.css",
				"~/AdminPanel/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
				"~/AdminPanel/plugins/datatables-responsive/css/responsive.bootstrap4.min.css",
				"~/AdminPanel/dist/css/adminlte.min.css",
				"~/AdminPanel/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
				"~/AdminPanel/plugins/daterangepicker/daterangepicker.css",
				"~/AdminPanel/plugins/summernote/summernote-bs4.css"
				));

		}
	}
}
