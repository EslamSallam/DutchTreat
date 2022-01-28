using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchTreatMapper : Profile
    {
        public DutchTreatMapper()
        {
            CreateMap<Order, OrdersViewModel>()
                .ForMember(vm => vm.orderId,n => n.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemsViewModel>()
                .ReverseMap();
        } 

    }
}
