using AutoMapper;
using ShopBridge.API.Model;
using ShopBridge.API.Repository.Interface;
using ShopBridge.API.Services.Interface;
using ShopBridge.API.UOW.Interface;
using ShopBridge.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Services
{
    public class InventoryService:IInventoryService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;
        private IRepository<Inventory> _repository;

        public InventoryService(IUnitOfWork uow,IMapper mapper,IRepository<Inventory> repository)
        {
            _uow = uow;
            _mapper = mapper;
            _repository = repository;
        }
        public bool createProduct(InventoryViewModel objInventoryVM)
        {
            var objInventory = _mapper.Map<Inventory>(objInventoryVM);
            _repository.Add(objInventory);
            _uow.Commit();
            return true;
        }
        public bool updateProduct(InventoryViewModel objInventoryVM, int id)
        {
            var objInventory = _repository.Get(m => m.id == id).FirstOrDefault();
            objInventory.name = objInventoryVM.name;
            objInventory.description = objInventoryVM.description;
            objInventory.price = objInventoryVM.price;
            objInventory.imageUrl = objInventoryVM.imageUrl;
            _repository.Update(objInventory);
            _uow.Commit();
            return true;
        }
        public bool deleteProduct(int id)
        {
            var objInventory = _repository.Get(m => m.id == id).FirstOrDefault();
            _repository.Delete(objInventory);
            _uow.Commit();
            return true;
        }
        public Inventory getInventoryById(int id)
        {
            var objInventory = _repository.Get(m => m.id == id).FirstOrDefault();
            return objInventory;
        }
        public List<Inventory> getAllInventories()
        {
            var lstInventory = _repository.Get().ToList();
            return lstInventory;
        }
    }
}
