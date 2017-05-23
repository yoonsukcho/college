using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class ShoppingCart : IShoppngCart
    {

        Customers customers;
        Orders orders;

        public ShoppingCart()
        {
            //this Model is Injected into the Constructor of the ShoppingCart
            Products = new HashSet<Products>();
        }

        public ShoppingCart(Customers customers, Orders orders)
        {
            //this Model is Injected into the Constructor of the ShoppingCart
            this.customers = customers;
            this.orders = orders;
            Products = new HashSet<Products>();
        }

        public ShoppingCart(Customers customers)
        {
            //this Model is Injected into the Constructor of the ShoppingCart
            this.customers = customers;
            Products = new HashSet<Products>();
        }

        public ShoppingCart(Orders orders)
        {
            //this Model is Injected into the Constructor of the ShoppingCart
            this.orders = orders;
            Products = new HashSet<Products>();
        }

        [Key]
        public int CartId { get; set; }
        //We create a virtual object to handle to the one-to-one relationship
        public virtual Customers Customers { get; set; }
        public virtual Orders Orders { get; set; }
        //We bring in the entire Product object table so that we have access to all the Products
        public ICollection<Products> Products { get; set; }

    }
}
