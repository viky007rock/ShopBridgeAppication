using ShopBridge.API.Model;
using ShopBridge.API.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();

        }
    }
}
