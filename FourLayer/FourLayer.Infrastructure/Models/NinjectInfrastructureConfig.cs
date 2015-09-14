using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Infrastructure.Models
{
    public class NinjectInfrastructureConfig
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository>().To<Repository>();

        }
    }
}
