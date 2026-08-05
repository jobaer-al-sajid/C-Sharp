using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nature_s_Corner
{
    
    public static class AppSession
    {
        public static string UserName { get; set; }
        public static string Role { get; set; }

        public static void Clear()
        {
            UserName = null;
            Role = null;
        }
    }
}


