using FoodDeliveryPRojectFull.Server.Data;
using FoodDeliveryPRojectFull.Server.IRepository;
using FoodDeliveryPRojectFull.Server.Models;
using FoodDeliveryPRojectFull.Shared.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace FoodDeliveryPRojectFull.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Catergory> _catergory;
        private IGenericRepository<Events> _events;
        private IGenericRepository<Payment> _payment;
        private IGenericRepository<Orders> _orders;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Food> _food;
        private UserManager<ApplicationUser> _userManager;
        public UnitOfWork(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

       

        public IGenericRepository<Catergory> Catergories
            => _catergory ??= new GenericRepository<Catergory>(_context);
        public IGenericRepository<Events> Events
            => _events ??= new GenericRepository<Events>(_context);
        public IGenericRepository<Payment> Payments
            => _payment ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Orders> Orders
            => _orders ??= new GenericRepository<Orders>(_context);
        public IGenericRepository<Food> Foods
            => _food ??= new GenericRepository<Food>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //string user = "System";
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user.UserName;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user.UserName;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
