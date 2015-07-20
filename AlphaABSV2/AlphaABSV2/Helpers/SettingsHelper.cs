using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlphaABSV2.DAL;

namespace AlphaABSV2.Helpers
{
    public enum SystemOwner {  Jungle = 1, Mayhem = 2, Paradise = 3, Bunker = 4, Demo = 99 }

    public static class SettingsHelper
    {
        static ABSContext db = new ABSContext();

        public static int GetCurrentCompanyRef()
        {
            
            return db.ABSSetting.First().CompanyRef;
            
        }

        public static int GetCurrentOwner()
        {
            switch (GetCurrentCompanyRef())
            {
                case 1:
                    return (int)SystemOwner.Jungle;
                case 2:
                    return (int)SystemOwner.Mayhem;
                case 3:
                    return (int)SystemOwner.Paradise;
                case 4:
                    return (int)SystemOwner.Bunker;
                default:
                    return (int)SystemOwner.Demo;

            }
        }
    }


   
}