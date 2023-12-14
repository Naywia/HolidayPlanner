using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner.Models
{
    public static class Session
    {
        private static Employee? employee;
        public static Employee? Employee
        {
            get => employee;
            set
            {
                if(employee != null)
                {
                    employee = value;
                }
            }
        }

        public static void DropSession()
        {
            Employee = null;
        }
    }
}
