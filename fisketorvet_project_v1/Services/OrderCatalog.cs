﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using fisketorvet_project_v1.Helpers;
using fisketorvet_project_v1.Models;

namespace fisketorvet_project_v1.Services
{
    public class OrderCatalog
    {
        private string filePath = @".\Data\Orders.json";
        private Dictionary<int, Order> Orders { get; set; }
        private CustomerCatalog Customers { get; set; }
        private Customer c;

        public OrderCatalog(CustomerCatalog c)
        {
            Customers = c;
        }
        public Dictionary<int, Order> MyOrders(int id)
        {
            Dictionary<int,Order> orders=new Dictionary<int, Order>();
            c=Customers.GetCustomer(id);
            if (c != null)
            {
                Orders=GetAllOrders();
                foreach (var o in Orders.Values)
                {
                    if(o.Customer==c) orders.Add(o.Id,o);
                }
            }
            return orders;
        }

        public Dictionary<int, Order> GetAllOrders()
        {
            return JsonReader<int, Order>.ReadJson(filePath);
        }

        public void AddOrder(Order order)
        {
            
            Orders = GetAllOrders(); //Populate it 
            order.Id = GenerateOrderId(Orders);
            Orders.Add(order.Id, order);
            JsonWriter<int, Order>.WriteToJson(Orders, filePath); //After adding the new one to the dictionary, writes it again to json
        }

        public void RemoveOrder(int id)
        {
            Orders = GetAllOrders();
            Orders.Remove(id);
            JsonWriter<int, Order>.WriteToJson(Orders,filePath);
        }


        private int GenerateOrderId(Dictionary<int, Order> oldOrders)
        {
            List<int> Ids = new List<int>();
            foreach (var s in oldOrders) 
            {
                Ids.Add(s.Value.Id); 
            }
            if (Ids.Count != 0)
            {
                return Ids.Max() + 1;
            }
            else
                return 1; 

        }
       
    }
}
