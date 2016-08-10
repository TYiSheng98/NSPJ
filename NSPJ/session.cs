using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NSPJ
{
    public class session
    {
         private static string sessionid;
        public static string SName
        {
            get
            {
                return sessionid;
            }
            set
            {
                sessionid = value;
            }
        }
    }
}