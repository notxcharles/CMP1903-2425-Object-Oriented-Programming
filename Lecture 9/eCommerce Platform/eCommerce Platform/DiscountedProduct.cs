using eCommerce_Platform;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce
{
    // DiscountedProduct.cs
    public class DiscountedProduct : ProductBase, IProduct
    {
        public decimal DiscountPercentage { get; set; }
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public decimal Price { get; set; }

        public DiscountedProduct(string productID, string productName, decimal price, decimal discountPercentage): base(productName, price)
        {
            ProductID = productID;
            DiscountPercentage = discountPercentage;
        }

        public override string GetProductName() => ProductName;
        public override decimal GetPrice() => Price;
        public decimal CalculateFinalPrice()
        {
            return Price * (1 - DiscountPercentage / 100);
        }


    }

}
