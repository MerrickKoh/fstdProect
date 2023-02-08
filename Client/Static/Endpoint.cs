using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryPRojectFull.Client.Static
{
    public static class EndPoint
    {
        private static readonly string Prefix = "api";

        public static readonly string CatergoriesEndPoint = $"{Prefix}/catergories";
        public static readonly string CustomersEndPoint = $"{Prefix}/customers";
        public static readonly string EventsEndPoint = $"{Prefix}/events";
        public static readonly string FoodsEndPoint = $"{Prefix}/foods";
        public static readonly string OrdersEndPoint = $"{Prefix}/orders";
        public static readonly string PaymentsEndPoint = $"{Prefix}/payments";
        public static readonly string AccountsEndPoint = $"{Prefix}/accounts";
    }
}
