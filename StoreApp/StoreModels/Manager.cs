using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StoreModels
{
    public class Manager
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerPassword { get; set; }
    }
}
