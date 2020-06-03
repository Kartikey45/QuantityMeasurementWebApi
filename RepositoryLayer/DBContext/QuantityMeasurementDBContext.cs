using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.DBContext
{
    public class QuantityMeasurementDBContext : DbContext
    {
        public QuantityMeasurementDBContext(DbContextOptions<QuantityMeasurementDBContext> options) : base(options)
        {

        }

        public DbSet<QuantityAttributes> QuantityMeasure { get; set; }

        public DbSet<QuantityComparision> QuantityComparisions { get; set; }
    }
}
