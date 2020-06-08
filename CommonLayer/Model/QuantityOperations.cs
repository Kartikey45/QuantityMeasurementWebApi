using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class QuantityOperations
    {
        // Enum For Length Conversion Operations. 
        public enum Length
        {
            InchToFeet, InchToYard, FeetToInch,
            FeetToYard, YardToInch, YardToFeet
        }

        // Enum For Weight Conversion Operations. 
        public enum Weight
        {
            GramToKilogram, GramToTonne, KilogramToGram,
            KilogramToTonne, TonneToGram, TonneToKilogram
        }

        // Enum For Volume Conversion Operations. 
        public enum Volume
        {
            LitreToMillilitre, MillilitreToLitre
        }

        // Enum For Temperature Conversion Operations. 
        public enum Temperature
        {
            CelsiusToFahrenheit, FahrenheitToCelsius
        }
    }
}
