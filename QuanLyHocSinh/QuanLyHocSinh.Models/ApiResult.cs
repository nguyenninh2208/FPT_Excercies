using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.Models
{
    public class BaseResultAPI<T> : ResultAPI
    {
        public T Data { get; set; }
    }

    public class ResultAPI
    {
        public bool IsSuccessfull { get; set; }
        public int RowEffect { get; set; }
    }
}
