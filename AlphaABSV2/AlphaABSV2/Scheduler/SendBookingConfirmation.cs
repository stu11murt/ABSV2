using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
using AlphaABSV2.DAL;
using AlphaABSV2.Models;

namespace AlphaABSV2.Scheduler
{
    public class SendBookingConfirmation : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //send email
                ABSContext db = new ABSContext();
                EmailManager eMan = new EmailManager();
                eMan.EmailCount = 1;
                eMan.EmailTemplateContent = "Recorded At : " + DateTime.Today.Date.ToShortTimeString();
                db.EmailManager.Add(eMan);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}