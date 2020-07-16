using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBE
{
    public class CommonBE:BaseRequestBE
    {
        public int HobbieId { get; set; }

        public int GenderId { get; set; }
        public int StateId { get; set; }

        public bool MarraigeStatusId { get; set; }
        public string StateName { get; set; }
        public string HobbieName { get; set; }



    }
}
