using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using static CommonLayer.Model.QuantityOperations;

namespace BusinessLayer.Service
{
    public class QuantityBL : IQuantityBL
    {
       
        private IQuantityRL quatityMeasure;

        public QuantityBL(IQuantityRL quatityMeasure)
        {
            this.quatityMeasure = quatityMeasure;
        }

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
    }
}
