using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Teacher
    {
        public Teacher(int id, string fullName, string contactInfo)
        {
            Id = id;
            FullName = fullName;
            ContactInfo = contactInfo;
        }

        public int Id { get; }
        public string FullName { get; set; }
        public string ContactInfo { get; set; }
    }
}
