using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class QuantityOperations
    {
        public enum Length
        {
            InchToFeet, InchToYard, FeetToInch,
            FeetToYard, YardToInch, YardToFeet
        }

        public enum Weight
        {
            GramToKilogram, GramToTonne, KilogramToGram,
            KilogramToTonne, TonneToGram, TonneToKilogram
        }

        public enum Volume
        {
            LitreToMillilitre, MillilitreToLitre
        }

        public enum Temperature
        {
            CelsiusToFahrenheit, FahrenheitToCelsius
        }
    }
}
