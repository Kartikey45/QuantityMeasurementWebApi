﻿using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IQuantityBL
    {
        QuantityAttributes AddQuantity(QuantityAttributes quantity);

        decimal Calculation(QuantityAttributes quantity);

        IEnumerable<QuantityAttributes> ViewQuantities();

        QuantityAttributes ViewQuantityById(int Id);

        QuantityAttributes DeleteQuantityById(int Id);
    }
}