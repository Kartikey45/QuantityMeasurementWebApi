﻿using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static CommonLayer.Model.QuantityOperations;

namespace BusinessLayer.Service
{
    // Class for implementing Repository pattern in Business Layer And Containg Business Logic.
    public class QuantityBL : IQuantityBL
    {
        // Repository Layer Reference.
        private IQuantityRL quatityMeasure;

        // Parameter Cnstructr For Setting Repositoory Layer Reference.
        public QuantityBL(IQuantityRL quatityMeasure)
        {
            this.quatityMeasure = quatityMeasure;
        }

        // Function To Perform Calculations For Conversion.
        public decimal Calculation(QuantityAttributes quantity)
        {
            try
            {
                string operation = quantity.Operation;
                decimal value = quantity.Value;
                decimal result = quantity.Result;

                if (operation == Length.InchToFeet.ToString())
                {
                    result = value / 12;
                }
                else if (operation == Length.InchToYard.ToString())
                {
                    result = value / 36;
                }
                else if (operation == Length.FeetToInch.ToString())
                {
                    result = value * 12;
                }
                else if (operation == Length.FeetToYard.ToString())
                {
                    result = value / 3;
                }
                else if (operation == Length.YardToInch.ToString())
                {
                    result = value * 36;
                }
                else if (operation == Length.YardToFeet.ToString())
                {
                    result = value * 3;
                }
                else if (operation == Weight.KilogramToGram.ToString())
                {
                    result = value * 1000;
                }
                else if (operation == Weight.GramToKilogram.ToString())
                {
                    result = value / 1000;
                }
                else if (operation == Weight.GramToTonne.ToString())
                {
                    result = value / (1000 * 1000);
                }
                else if (operation == Weight.TonneToGram.ToString())
                {
                    result = value * (1000 * 1000);
                }
                else if (operation == Weight.KilogramToTonne.ToString())
                {
                    result = value / 1000;
                }
                else if (operation == Weight.TonneToKilogram.ToString())
                {
                    result = value * 1000;
                }
                else if (operation == Volume.LitreToMillilitre.ToString())
                {
                    result = value * 1000;
                }
                else if (operation == Volume.MillilitreToLitre.ToString())
                {
                    result = value / 1000;
                }
                else if (operation == Temperature.CelsiusToFahrenheit.ToString())
                {
                    result = (value * 9 / 5) + 32;
                }
                else if (operation == Temperature.FahrenheitToCelsius.ToString())
                {
                    result = (value - 32) * 5 / 9;
                }
                return Math.Round(result, 2);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Perform Conversion.
        public QuantityAttributes AddQuantity(QuantityAttributes quantity)
        {
            try
            {
                quantity.Result = Calculation(quantity);
                if (quantity.Result > 0)
                {
                    return this.quatityMeasure.Add(quantity);
                }
                return quantity;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function TO Get All Conversion Details.
        public IEnumerable<QuantityAttributes> ViewQuantities()
        {
            try
            {
                return this.quatityMeasure.ViewQuantities();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Get Specific Conversion Details.
        public QuantityAttributes ViewQuantityById(int Id)
        {
            try
            {
                return this.quatityMeasure.ViewQuantityById(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Delete Conversion Details.
        public QuantityAttributes DeleteQuantityById(int Id)
        {
            try
            {
                return this.quatityMeasure.DeleteQuantityById(Id);
            }
            catch (Exception exceptioon)
            {
                throw exceptioon;
            }
        }

        // Function To Add Comparison.
        public QuantityComparision AddQuantityComparison(QuantityComparision comparison)
        {
            try
            {
                comparison.Result = Compare(comparison);
                if (comparison.Result != null)
                {
                    return this.quatityMeasure.AddQuantityComparison(comparison);
                }
                return comparison;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Get Specific Comparison Detail.
        public QuantityComparision ViewQuantityComparisonById(int Id)
        {
            try
            {
                return this.quatityMeasure.ViewQuantityComparisonById(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Get All Comparison Details.
        public IEnumerable<QuantityComparision> ViewQuantityComparisons()
        {
            try
            {
                return this.quatityMeasure.ViewQuantityComparisons();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function To Delete Comparison Details.
        public QuantityComparision DeleteQuantityComparisonById(int Id)
        {
            try
            {
                return this.quatityMeasure.DeleteQuantityComparisonById(Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Function to perform comparision between two values 
        public string CompareUnitValues(QuantityComparision comparison)
        {
            if (comparison.firstValue > comparison.SecondValue)
            {
                comparison.Result = $"{comparison.firstValue} {comparison.SecondValueQuantityUnit} Is Greater Than {comparison.SecondValue} {comparison.SecondValueQuantityUnit}";
            }
            else if (comparison.firstValue < comparison.SecondValue)
            {
                comparison.Result = $"{comparison.firstValue} {comparison.SecondValueQuantityUnit} Is Less Than {comparison.SecondValue} {comparison.SecondValueQuantityUnit}";
            }
            else
            {
                comparison.Result = $"{comparison.firstValue} {comparison.SecondValueQuantityUnit} Is Equal To {comparison.SecondValue} {comparison.SecondValueQuantityUnit}";
            }
            return comparison.Result;
        }

        // Function To Perform Comparison.
        public string Compare(QuantityComparision comparison)
        {
            try
            {
                if (comparison.firstValueQuantityUnit == QuantityUnits.Gram.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Kilogram.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 1000;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Kilogram.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Gram.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 1000;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Gram.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Tonne.ToString())
                {
                    comparison.firstValue = comparison.firstValue / ( 1000 * 1000 );
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Tonne.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Gram.ToString())
                {
                    comparison.firstValue = comparison.firstValue * (1000 * 1000);
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Kilogram.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Tonne.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 1000 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Tonne.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Kilogram.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 1000;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Inch.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Feet.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 12 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Feet.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Inch.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 12;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Inch.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Yard.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 36 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Yard.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Inch.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 36 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Feet.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Yard.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 3 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Yard.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Feet.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 3 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Litre.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Millilitre.ToString())
                {
                    comparison.firstValue = comparison.firstValue * 1000 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Millilitre.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Litre.ToString())
                {
                    comparison.firstValue = comparison.firstValue / 1000 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Celsius.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Fahrenheit.ToString())
                {
                    comparison.firstValue = ( comparison.firstValue * 9 / 5 ) + 32 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                if (comparison.firstValueQuantityUnit == QuantityUnits.Fahrenheit.ToString() && comparison.SecondValueQuantityUnit == QuantityUnits.Celsius.ToString())
                {
                    comparison.firstValue = ( comparison.firstValue - 32 ) * 5 / 9 ;
                    comparison.Result = CompareUnitValues(comparison);
                }
                return comparison.Result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
