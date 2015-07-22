using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Configuration;
using Quartz;
using Quartz.Impl;
using Quartz.Job;
using AlphaABSV2.Models;
using AlphaABSV2.DAL;

namespace AlphaABSV2.Scheduler
{
    public class RunScheduledJobs
    {
        #region "Customer Emails"

        public static void RunJobBookingConfirmation()
        {
            bool jobDuplicate = false;
            NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("quartz");
            ISchedulerFactory factory = new StdSchedulerFactory(config);
            IScheduler payReminderShed = factory.GetScheduler();

            string currentJob = "jobBookingPayReminder" + DateTime.Today.Date.ToShortDateString();
            string currentTrigger = "triggerBookingPayReminder" + DateTime.Today.Date.ToShortDateString();
            string currentGroup = "groupBookingPayReminder";

            try
            {
                JobKey checkJobKey = new JobKey(currentJob);
                TriggerKey trigKey = new TriggerKey(currentTrigger);

                if(IsJobScheduledInStore(currentJob))
                {
                    jobDuplicate = true;

                }

                if(!payReminderShed.CheckExists(checkJobKey) && jobDuplicate == false)
                {
                    payReminderShed.Start();

                    IJobDetail job = JobBuilder.Create<SendBookingConfirmation>()
                        .WithIdentity(currentJob, currentGroup)
                        .Build();

                    ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                        .WithIdentity(currentTrigger, currentGroup)
                        .StartAt(DateBuilder.DateOf(16, 55, 00))
                        .WithSimpleSchedule(x => x
                            .WithIntervalInMinutes(5)
                            .RepeatForever()
                            .WithMisfireHandlingInstructionNextWithExistingCount())

                    .Build();

                    payReminderShed.ScheduleJob(job, trigger);


                }
                else
                {
                    payReminderShed.Start();

                    IJobDetail job = JobBuilder.Create<SendBookingConfirmation>()
                        .WithIdentity(currentJob, currentGroup)
                        .Build();

                    ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                        .WithIdentity(currentTrigger, currentGroup)
                        .StartAt(DateBuilder.DateOf(00, 45, 00))
                        .WithSimpleSchedule(x => x
                            .WithIntervalInMinutes(5)
                            .RepeatForever()
                            .WithMisfireHandlingInstructionNextWithExistingCount())

                    .Build();

                    removeJobFromStore(currentGroup);
                    payReminderShed.ScheduleJob(job, trigger);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static void removeJobFromStore(string groupName)
        {
            //IDataContextWrapper dcw = new DataContextWrapper<BoomDataContext>();
            //IEnumerable<QRTZ_TRIGGER> triggers = dcw.GetTable<QRTZ_TRIGGER>().Where(t => t.TRIGGER_GROUP == groupName);

            //try
            //{
            //    foreach (QRTZ_TRIGGER trig in triggers.ToList())
            //    {
            //        QRTZ_SIMPLE_TRIGGER simTrigger = dcw.GetTable<QRTZ_SIMPLE_TRIGGER>().FirstOrDefault(j => j.TRIGGER_GROUP == groupName);
            //        if (simTrigger != null)
            //        {
            //            dcw.Delete(simTrigger);
            //            dcw.Commit();
            //        }

            //        QRTZ_TRIGGER trigger = dcw.GetTable<QRTZ_TRIGGER>().FirstOrDefault(j => j.TRIGGER_GROUP == groupName);
            //        if (trigger != null)
            //        {
            //            dcw.Delete(trigger);
            //            dcw.Commit();
            //        }


            //        QRTZ_JOB_DETAIL job = dcw.GetTable<QRTZ_JOB_DETAIL>().FirstOrDefault(j => j.JOB_GROUP == groupName);
            //        if (job != null)
            //        {
            //            dcw.Delete(job);
            //            dcw.Commit();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    ErrorHandlerHelper.HandleError(ex, "Scheduler", "Errored on deleting jobs_triggers");
            //}


        }

        //TODO
        private static bool IsJobScheduledInStore(string groupName)
        {
            //ABSContext db = new ABSContext();
            //if (db.Entry<QRTZ_TRIGGER>().FirstOrDefault(j => j.JOB_NAME == groupName) != null)
            //    return true;
            //else
            //    return false;
            return false;
        }
       


        #endregion

    }
}