using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartBE
{
    public class UserRegistrationRequestBE:BaseRequestBE
    {
        public string Email { get; set; }

        public string ConfimredPassword { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfJoining { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int HobbieId { get; set; }
    
        public int GenderId { get; set; }
        public int StateId { get; set; }

        public bool MarraigeStatusId { get; set; }

        public string EmpName { get; set; }



    
    }
}
