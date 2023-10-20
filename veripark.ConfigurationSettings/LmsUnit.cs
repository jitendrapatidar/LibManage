using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veripark.ConfigurationSettings
{
    public class LmsUnit
    {
        public static int MaxIssueDays = 14;
            


    }
    enum LmsRoles
    {
        Admin,
        User,
        Customer,
    }
    enum Status
    {
        Available,
        NotAvailable,
    }
}
