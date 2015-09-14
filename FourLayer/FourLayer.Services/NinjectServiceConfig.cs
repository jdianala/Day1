using FourLayer.Infrastructure.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Services
{
    public class NinjectServiceConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            NinjectInfrastructureConfig.RegisterServices(kernel);
 
        }
    }
    
}
