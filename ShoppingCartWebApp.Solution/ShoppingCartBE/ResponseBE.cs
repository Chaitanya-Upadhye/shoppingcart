using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBE
{
    public class ResponseBE:BaseResponseBE
    {
        public string UserName { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }
    }
}
