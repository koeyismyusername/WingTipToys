using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace WingtipToys.Models
{
    public class WingtipToysDatabase : DataContext
    {
        private WingtipToysDatabase() : base(ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString)
        {

        }

        public static WingtipToysDatabase New { get => new WingtipToysDatabase(); }
    }
}