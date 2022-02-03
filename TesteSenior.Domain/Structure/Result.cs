using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSenior.Domain.Entities;

namespace TesteSenior.Domain.Structure
{
    public class Result
    {
        public Result()
        {
            Status = true;
        }
        public bool Status { get; set; }
        public string Msg { get; set; }
        public string TipoMsg { get; set; }
    }
}
