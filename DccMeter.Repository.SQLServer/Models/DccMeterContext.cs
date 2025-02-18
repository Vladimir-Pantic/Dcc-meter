using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;



namespace DccMeter.Repository.SQLServer.Models
{
    public class DccMeterContext : DbContext
    {
        public DccMeterContext() { }

        public DccMeterContext(DbContextOptions<DccMeterContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
