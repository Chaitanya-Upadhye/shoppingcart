using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBE
{
   public class BaseRequestBE
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SecurityKey { get; set; }
   }
}
