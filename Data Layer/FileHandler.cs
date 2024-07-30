using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PRG_Project_Final.Data_Layer
{
    internal class FileHandler
    {
        public Dictionary<string, string> readfromfile()
        {
            List<string> admins = new List<string>();
            Dictionary<string, string> lec = new Dictionary<string, string>();

            admins = File.ReadAllLines("users.txt").ToList();
            foreach (var line in admins)
            {
                string[] item = line.Split(',');
                if (item.Length == 2)
                {
                    lec.Add(item[0], item[1]);
                }

            }

            return lec;
        }

        public void writeToFile(string uname, string pword)
        {

            string text = uname + "," + pword;

            File.WriteAllText("users.txt", text);

        }
    }
}
