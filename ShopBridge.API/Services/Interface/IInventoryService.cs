using ShopBridge.API.Model;
using ShopBridge.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Services.Interface
{
    public interface IInventoryService
    {
        bool createProduct(InventoryViewModel objInventoryVM);
        bool updateProduct(InventoryViewModel objInventoryVM,int id);
        bool deleteProduct(int id);
        Inventory getInventoryById(int id);
        List<Inventory> getAllInventories();
    }
}
