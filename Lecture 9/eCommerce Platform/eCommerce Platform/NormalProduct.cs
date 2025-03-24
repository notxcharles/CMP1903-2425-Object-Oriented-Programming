using eCommerce_Platform;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce
{
    public class NormalProduct : ProductBase, IProduct
    {
        // Constructor to initialize ProductName and Price
        public NormalProduct(string productName, decimal price): base(productName, price)
        {
        }

        // Implementation of CalculateFinalPrice (no discount)
        public override string GetProductName() => _productName;
        public override decimal GetPrice() => _price;
        public decimal CalculateFinalPrice() => _price;  // No discount
    }

}
