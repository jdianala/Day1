using FourLayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourLayer.Infrastructure.Models
{
    public class DataContext : DbContext
    {
        public IDbSet<Account> Accounts { get; set; }
    }
}
