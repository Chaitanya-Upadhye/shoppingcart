using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDAL;
using ShoppingCartBE;

namespace ShoppingCartBAL
{
    
    public class OrdersBAL
    {
        OrdersDAL _ordersDal = new OrdersDAL();
        public void CreateOrder(int customerId, List<ProductsBE> products)
        {
            try
            {
                _ordersDal.CreateOrder(customerId,products);
            }
            catch (Exception)
            {
                
                throw;
            }

        }


         public List<OrderBE> GetOrderDetails(int customerId)
        {
            try
            {
                return _ordersDal.GetOrderDetails(customerId);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
