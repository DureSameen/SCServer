using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;



namespace SCServer.Common.Helpers
{
    public static class Configurations
    {
         
        public static string Api_URL()
        { return  ConfigurationManager.AppSettings["Api_URL"] ; }

        

        

    }
}
