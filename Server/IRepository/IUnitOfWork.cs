using FoodDeliveryPRojectFull.Shared.Domains;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryPRojectFull.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Catergory> Catergories { get; }
        IGenericRepository<Events> Events { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Orders> Orders { get; }
        IGenericRepository<Food> Foods { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}
