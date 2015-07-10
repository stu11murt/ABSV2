using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaABSV2.DAL;
using AlphaABSV2.Helpers;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html;
//using iTextSharp.text.html.simpleparser;
using AlphaABSV2.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

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

        public ActionResult DaySheets(DateTime? selectedDate, int queryType = 0)
        {
            if(selectedDate != null && queryType == 0)
            {
                ViewBag.PassedDate = ReverseDate(Convert.ToDateTime(selectedDate));
                return View(MayhemHelper.FindQueryType(Convert.ToDateTime(selectedDate), queryType));
            }
            else if(queryType > 0)
            {
                ViewBag.PassedDate = ReverseDate(Convert.ToDateTime(selectedDate));
                return View(MayhemHelper.FindQueryType(Convert.ToDateTime(selectedDate), queryType));
            }
            else
            {
                ViewBag.PassedDate = ReverseDate(DateTime.Today);
                return View(db.EventRecords.ToList());
            }
        }

        
        private string ReverseDate(DateTime passedDate)
        {
            return passedDate.Month.ToString() + "/" + passedDate.Day.ToString() + "/" + passedDate.Year.ToString(); 
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

        public void ExportToExcel(DateTime eventDate, int queryType)
        {
            List<EventRecord> events = MayhemHelper.FindQueryType(eventDate, queryType);

            if(events != null)
            {
                 var grid = new GridView();

                 grid.DataSource = events;
                 grid.DataBind();

                 Response.ClearContent();
                 Response.AddHeader("content-disposition", "attachment; filename=DaySheets" + DateTime.Today.ToShortDateString() + ".xls");
                 Response.ContentType = "application/excel";
                 StringWriter sw = new StringWriter();
                 HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

                 grid.RenderControl(htmlTextWriter);
                 Response.Write(sw.ToString());
                 Response.End();


            }
           
        }
    }
}