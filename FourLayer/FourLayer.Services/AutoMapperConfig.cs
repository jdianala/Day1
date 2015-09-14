using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FourLayer.Domain.Models;
using FourLayer.Services.Models;

namespace FourLayer.Services
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<Account, AccountDTO>();
            Mapper.CreateMap<AccountDTO, Account>();
        }
    }
}
