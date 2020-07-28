using AutoMapper;
using ShopBridge.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ShopBridge.API.ViewModel
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<InventoryViewModel, Inventory>();
            CreateMap<InventoryViewModel, Inventory>()
                .ForMember(x => x.id, opt => opt.Ignore());

        }
    }
}
