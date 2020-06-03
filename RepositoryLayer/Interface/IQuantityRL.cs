using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IQuantityRL
    {
        IEnumerable<QuantityAttributes> ViewQuantities();

        QuantityAttributes Add(QuantityAttributes quantity);

        QuantityAttributes ViewQuantityById(int Id);

        QuantityAttributes DeleteQuantityById(int Id);

        QuantityComparision AddQuantityComparison(QuantityComparision comparison);

        QuantityComparision ViewQuantityComparisonById(int Id);

        IEnumerable<QuantityComparision> ViewQuantityComparisons();

        QuantityComparision DeleteQuantityComparisonById(int Id);
    }
}
