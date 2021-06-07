using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Helper
{
    public static class Randomizer
    {
        public static string Date { get => GetCurrentDate(); }
        private static string GetCurrentDate()
        {
            DateTime now = DateTime.Now;
            return now.ToString("yyyyMMddmmssffff");
        }
    }
}
