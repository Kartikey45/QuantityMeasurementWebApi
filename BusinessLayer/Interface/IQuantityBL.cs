using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    // Interface for Implementing Repository Pattern In Business Layer.
    public interface IQuantityBL
    {
        // Function to Perform Conversion.
        QuantityAttributes AddQuantity(QuantityAttributes quantity);

        // Function to Perform Calculation For Conversion.
        decimal Calculation(QuantityAttributes quantity);

        // Abstract Function For Getting All Conversion Detail.
        IEnumerable<QuantityAttributes> ViewQuantities();

        // Abstract Function For Get Specific Conversion Detail.
        QuantityAttributes ViewQuantityById(int Id);

        // Function To Delete Cnversion Detail.
        QuantityAttributes DeleteQuantityById(int Id);

        // Abstract Function for Adding Specific Comparison Detail.
        QuantityComparision AddQuantityComparison(QuantityComparision comparison);

        // Abstract Function for Geting Specific Comparison Detail.
        QuantityComparision ViewQuantityComparisonById(int Id);

        // Abstract Function for Geting All Comparison Detail.
        IEnumerable<QuantityComparision> ViewQuantityComparisons();

        // Abstract Function For Deleting Comparison Details.
        QuantityComparision DeleteQuantityComparisonById(int Id);

        // Abstract Comparison.
        string Compare(QuantityComparision comparison);

        //Abstract method for Comparing units 
        string CompareUnitValues(QuantityComparision comparison);
    }
}
