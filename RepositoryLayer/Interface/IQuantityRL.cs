using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IQuantityRL
    {
        // Abstract Function for Geting All Conversions Detail.
        IEnumerable<QuantityAttributes> ViewQuantities();

        // Abstract Function for Adding Conversion Detail.
        QuantityAttributes Add(QuantityAttributes quantity);

        // Abstract Function for Geting Specific Conversion Detail.
        QuantityAttributes ViewQuantityById(int Id);

        // Abstract Function for Deleting Specific Conversion Detail.
        QuantityAttributes DeleteQuantityById(int Id);

        // Abstract Function for Adding Specific Comparison Detail.
        QuantityComparision AddQuantityComparison(QuantityComparision comparison);

        // Abstract Function for Geting Specific Comparison Detail.
        QuantityComparision ViewQuantityComparisonById(int Id);

        // Abstract Function for Geting All Comparison Detail.
        IEnumerable<QuantityComparision> ViewQuantityComparisons();

        // Abstract Function For Deleting Comparison Details.
        QuantityComparision DeleteQuantityComparisonById(int Id);
    }
}
