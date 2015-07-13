using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaABSV2.DAL;
using AlphaABSV2.Models;
using AlphaABSV2.Helpers;

namespace AlphaABSV2.Controllers
{
    public class EmailManagerController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: EmailManager
        public ActionResult Index()
        {
            return View(db.EmailTemplates.ToList());
        }

      
        // GET: EmailManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            emailTemplate.TemplateContent = HttpUtility.HtmlDecode(emailTemplate.TemplateContent);
            return View(emailTemplate);
        }

        // GET: EmailManager/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(string sHTML, string templateNAME = "Template")
        {
            try
            {
                EmailTemplates emailTemplate = new EmailTemplates();
                emailTemplate.TemplateContent = HttpUtility.HtmlEncode(sHTML);
                emailTemplate.TemplateTitle = templateNAME;
                db.EmailTemplates.Add(emailTemplate);
                db.SaveChanges();

                return JavaScript("window.location = '/emailmanager/index'");
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        // GET: EmailManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            emailTemplate.TemplateContent = HttpUtility.HtmlDecode(emailTemplate.TemplateContent);
            return View(emailTemplate);
        }

        // POST: EmailManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, string sHTML, string template = "Template")
        {
            try
            {
                EmailTemplates emailTemplate = db.EmailTemplates.Find(Convert.ToInt32(id));
                if (emailTemplate != null)
                {
                    emailTemplate.TemplateContent = HttpUtility.HtmlEncode(sHTML);
                    emailTemplate.TemplateTitle = template;
                    db.SaveChanges();
                }

                return JavaScript("window.location = '/emailmanager/index'");
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        // GET: EmailManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            emailTemplate.TemplateContent = HttpUtility.HtmlDecode(emailTemplate.TemplateContent);
            return View(emailTemplate);
        }

        // POST: EmailManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            db.EmailTemplates.Remove(emailTemplate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EditEmail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            emailTemplate.TemplateContent = HttpUtility.HtmlDecode(emailTemplate.TemplateContent);
            return View(emailTemplate);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmail(EmailTemplates template)
        {
            EmailTemplates emailTemplate = db.EmailTemplates.Find(template.EmailTemplatesID);
            emailTemplate.TemplateContent = template.TemplateContent;
            emailTemplate.TemplateTitle = template.TemplateTitle;
            //db.EmailTemplates.Add(emailTemplate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
