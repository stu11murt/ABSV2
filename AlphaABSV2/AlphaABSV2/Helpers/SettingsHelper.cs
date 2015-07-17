using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.DAL;

namespace AlphaABSV2.Helpers
{
    public enum CompanyRefSelection {  Jungle = 1, Mayhem = 2, Paradise = 3, Bunker = 4 }

    public static class SettingsHelper
    {
        public static int GetCurrentCompanyRef()
        {
            ABSContext db = new ABSContext();
            return db.ABSSetting.First().CompanyRef;
            
        }
    }
}