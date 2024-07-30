using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRG_Project_Final.Data_Layer;

namespace PRG_Project_Final.Logic_Layer
{
    internal class Students
    {
        public Students() { }

        public Students(string stuNo, string name, DateTime dOB, string gender, string phone, string address, string codes)
        {
            StuNo = stuNo;
            Name = name;
            DOB = dOB;
            Gender = gender;
            Phone = phone;
            Address = address;
            Codes = codes;
        }

        public string StuNo { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Codes { get; set; }

    }
}
