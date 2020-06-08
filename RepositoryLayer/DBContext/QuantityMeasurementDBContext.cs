using CommonLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.DBContext
{
    // Class For DBContext.
    public class QuantityMeasurementDBContext : DbContext
    {
        // Parameter Constructor.
        public QuantityMeasurementDBContext(DbContextOptions<QuantityMeasurementDBContext> options) : base(options)
        {

        }

        // DbSet Property For QuantityModel.
        public DbSet<QuantityAttributes> QuantityMeasure { get; set; }

        // DbSetProperty For ComparisonModel.
        public DbSet<QuantityComparision> QuantityComparisions { get; set; }
    }
}
