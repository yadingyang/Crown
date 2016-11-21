using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CM.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Descn { get; set; }

    }


    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public System.Decimal Listprice { get; set; }
        public string Name { get; set; }
        public string Descn { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }



    public class CrownContext : DbContext
    {
        public DbSet<Category> Cat { get; set; }
        public DbSet<Product> Pro { get; set; }
        public DbSet<Order> Ord { get; set; }
        public DbSet<Item> Ite { get; set; }

    }

}