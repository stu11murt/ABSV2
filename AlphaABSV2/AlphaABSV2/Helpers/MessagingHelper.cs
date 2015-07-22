using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.DAL;
using AlphaABSV2.Models;
using Microsoft.AspNet.Identity;
using AlphaABSV2.Controllers;


namespace AlphaABSV2.Helpers
{
    public static class MessagingHelper
    {
        public static List<string> GetMessages()
        {
            ABSContext db = new ABSContext();
            var usID = HttpContext.Current.User.Identity.GetUserId().ToString();
            List<string> messages = db.Messages.Where(m => m.UserID == usID.ToString() && m.Read == false && m.Deleted == false && m.Archived == false).Select(c => c.Message).ToList();

            return messages;
        }

        //public static int MessageCount()
        //{
        //    ABSContext db = new ABSContext();
        //    var usID = HttpContext.Current.User.Identity.GetUserId().ToString();
        //    List<string> messages = db.Messages.Where(m => m.UserID == usID.ToString() && m.Read == false && m.Deleted == false && m.Archived == false).Select(c => c.Message).ToList();

        //    return messages.Count;
        //}


        public static string GetUserName(string userID)
        {
            AccountController acc = new AccountController();
            string userName = acc.GetUserNameFromID(userID);
            if (userName != null)
                return userName;
            else
                return "NA";
        }
    }
}