using CommonLayer.Model;
using RepositoryLayer.DBContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class QuantityRL : IQuantityRL
    {
        private QuantityMeasurementDBContext dBContext;

        public QuantityRL(QuantityMeasurementDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public QuantityAttributes Add(QuantityAttributes quantity)
        {
            try
            {
                dBContext.QuantityMeasure.Add(quantity);
                dBContext.SaveChanges();
                return quantity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

       

        public QuantityAttributes DeleteQuantityById(int Id)
        {
            try
            {
                QuantityAttributes quantity = dBContext.QuantityMeasure.Find(Id);
                if (quantity != null)
                {
                    dBContext.QuantityMeasure.Remove(quantity);
                    dBContext.SaveChanges();

                }
                return quantity;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        

        public IEnumerable<QuantityAttributes> ViewQuantities()
        {
            try
            {
                return dBContext.QuantityMeasure;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public QuantityAttributes ViewQuantityById(int Id)
        {
            try
            {
                QuantityAttributes quantity = dBContext.QuantityMeasure.Find(Id);
                return quantity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public QuantityComparision AddQuantityComparison(QuantityComparision comparison)
        {
            try
            {
                dBContext.QuantityComparisions.Add(comparison);
                dBContext.SaveChanges();
                return comparison;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public QuantityComparision ViewQuantityComparisonById(int Id)
        {
            try
            {
                QuantityComparision comparison = dBContext.QuantityComparisions.Find(Id);
                return comparison;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IEnumerable<QuantityComparision> ViewQuantityComparisons()
        {
            try
            {
                return dBContext.QuantityComparisions;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
        public QuantityComparision DeleteQuantityComparisonById(int Id)
        {
            try
            {
                QuantityComparision comparison = dBContext.QuantityComparisions.Find(Id);
                if (comparison != null)
                {
                    dBContext.QuantityComparisions.Remove(comparison);
                    dBContext.SaveChanges();
                }
                return comparison;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
