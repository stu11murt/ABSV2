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
using Newtonsoft.Json;

namespace AlphaABSV2.Controllers
{
    public class StaffController : Controller
    {
        private ABSContext db = new ABSContext();

        // GET: Staff
        public ActionResult Index()
        {
            return View(db.Staff.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,MobileNum,Email,NINumber,DateEmployed")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,FirstName,LastName,MobileNum,Email,NINumber,DateEmployed")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staff.Find(id);
            db.Staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AssignStaff(string eventDate)
        {
            if (eventDate != null)
            {
                DateTime conDate = DateTime.Parse(eventDate);
                ViewBag.Events = db.EventRecords.Where(e => e.BookingForm.DateOfEvent == conDate).ToList();
            }
            else
            {
                ViewBag.Events = db.EventRecords.Where(e => e.BookingForm.DateOfEvent == DateTime.Today).ToList();
            }

            return View(db.Staff.ToList());
        }

        public ActionResult StaffRota()
        {
            return View(db.Staff.ToList());
        }
        
        public ActionResult CreateRota(string assignments)
        {
            
            try
            {
                StaffArrayRoot[] result = JsonConvert.DeserializeObject<StaffArrayRoot[]>(assignments);
                List<StaffEventRota> staffRota = new List<StaffEventRota>();
                DateTime eDate = DateTime.Today;

                if (result.Count() > 0)
                    CheckForDeletions(db.EventRecords.Find(Convert.ToInt32(result.First().id)).BookingForm.DateOfEvent);

                foreach (StaffArrayRoot staff in result)
                {
                    if (staff.children != null)
                    {
                        foreach (children child in staff.children)
                        {
                            StaffEventRota staffAssign = new StaffEventRota();
                            staffAssign.EventRecordID = Convert.ToInt32(staff.id);
                            staffAssign.StaffID = Convert.ToInt32(child.id);
                            staffRota.Add(staffAssign);
                        }
                    }
                    
                }

                foreach (StaffEventRota sRota in staffRota)
                {
                    eDate = GetEvDate(sRota.EventRecordID);
                    db.StaffEventRotas.Add(sRota);
                    db.SaveChanges();
                }

                return RedirectToAction("DisplayRotas", new { eventDate = eDate });
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private DateTime GetEvDate(int id)
        {
            return db.EventRecords.Find(id).BookingForm.DateOfEvent;
        }

        public ActionResult DisplayRotas(DateTime? eventDate)
        {
            if(eventDate != null)
                return View(db.StaffEventRotas.Where(s => s.EventRecord.BookingForm.DateOfEvent == eventDate).ToList());
            else
                return View(db.StaffEventRotas.ToList());
        }

        public ActionResult RemoveStaffRota(int eventRecordID, int staffID)
        {
            DateTime eDate = DateTime.Today;

            if (db.StaffEventRotas.Where(r => r.EventRecordID == eventRecordID && r.StaffID == staffID) != null)
            {
                StaffEventRota RotaEntry = db.StaffEventRotas.FirstOrDefault(r => r.EventRecordID == eventRecordID && r.StaffID == staffID);
                db.StaffEventRotas.Remove(RotaEntry);
                db.SaveChanges();
            }

            return RedirectToAction("AssignStaff", new { eventDate = eDate.ToShortDateString() });
        }
        
        private void CheckForDeletions(DateTime eDate)
        {
            
            if (db.StaffEventRotas.Where(s => s.EventRecordID > 0) != null)
            {
                List<StaffEventRota> rotas = db.StaffEventRotas.Where(s => s.EventRecord.BookingForm.DateOfEvent == eDate).ToList();
                foreach (StaffEventRota rota in rotas)
                {
                    db.StaffEventRotas.Remove(rota);
                    db.SaveChanges();
                }
            }
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

    public class StaffArrayRoot
    {
        public string id { get; set;}
        public List<children> children { get; set; }
    }

    public class children
    {
        public string id { get; set; }
        
    }

   
    
}
