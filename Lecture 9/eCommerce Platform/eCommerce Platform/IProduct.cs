using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce
{
    public interface IProduct
    {
        string GetProductName();
        decimal GetPrice();
        decimal CalculateFinalPrice();
    }
}
