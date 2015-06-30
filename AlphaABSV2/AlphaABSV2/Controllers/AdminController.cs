using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaABSV2.DAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace AlphaABSV2.Controllers
{
    public class AdminController : Controller
    {
        ABSContext db = new ABSContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DaySheets(DateTime? selectedDate)
        {
            if(selectedDate != null)
            { 
                return View(db.Bookings.Where(b => b.DateOfEvent == selectedDate));
            }
            else
            {
                return View(db.Bookings);
            }
        }

        //TODO
        //protected FileContentResult ViewPdf(string pageTitle, string viewName, object model)
        //{
        //    // Render the view html to a string.
        //    string htmlText = this.htmlViewRenderer.RenderViewToString(this, viewName, model);

        //    // Let the html be rendered into a PDF document through iTextSharp.
        //    byte[] buffer = standardPdfRenderer.Render(htmlText, pageTitle);

        //    // Return the PDF as a binary stream to the client.
        //    return File(buffer, "application/pdf", "file.pdf");
        //}

        protected ActionResult ExportPDF(string pageTitle, string viewName, object model)
        {
            return View();
        }
    }
}