using CommonLayer.Model;
using RepositoryLayer.DBContext;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    // Class Implementing Repository Pattern And Entity Frameork Core.
    public class QuantityRL : IQuantityRL
    {
        //DBContext Refernce.
        private QuantityMeasurementDBContext dBContext;

        // Parameter Constructor For Seting DbContext Reference by DI.
        public QuantityRL(QuantityMeasurementDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        // Function to Add Conversion Detail to Database.
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

        // Function to Delete Specific Data From DataBase.
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


        // Function To Get All Convserion Details.
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

        // Function to get Specific Conversion Detail.
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

        // Function To Add Comparison Detail to Database.
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

        // Function to get Sppecific Comparison Details.
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

        // Function to Get All Comparison Details.
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

        // Functionn To Delete  Specific Comparison Detail.
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
