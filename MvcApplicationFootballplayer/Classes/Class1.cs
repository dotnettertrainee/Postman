using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplicationFootballplayer;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Dynamic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Globalization;
using System.Media;
using System.Net.Cache;
using System.Reflection;
using System.Linq;
using System.CodeDom.Compiler;


namespace MvcApplicationFootballplayer.Classes
{
    public class Class1
    {
        var con = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
            //MvcApplicationFootballplayer.Data.Player
            using (MvcApplicationFootballplayer.Data.Player player = new Data.Player())
            {

            }
    }
}