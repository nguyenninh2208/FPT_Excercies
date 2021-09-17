using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.DTO.Students
{
   public class StudentModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime B_Day { get; set; }
        public string Class { get; set; }
        public string Email { get; set; }

    }
}
