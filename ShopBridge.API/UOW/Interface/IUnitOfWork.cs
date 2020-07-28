using ShopBridge.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.UOW.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        ApplicationDbContext _context { get; }
        void Commit();
    }
}
