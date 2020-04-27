using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T1809E.SEM3.P102_Team05.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public int InStock { get; set; }
        public OrderStatus Status { get; set; }


    }
    enum OrderStatus
    {
        ACTIVE,
        DISABLE,
        OUT_OF_STOCK,
        DELETED
    }
}