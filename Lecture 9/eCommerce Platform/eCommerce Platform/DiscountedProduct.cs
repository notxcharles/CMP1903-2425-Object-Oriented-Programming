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
        public string ProductID { get; set; }

        public DiscountedProduct(string productID, string productName, decimal price): base(productName, price)
        {
            ProductID = productID;
            DiscountPercentage = CalculateDiscountPercentage();

        }

        public override string GetProductName() => _productName;
        public override decimal GetPrice() => _price;
        public decimal CalculateFinalPrice()
        {
            return _price * (1 - DiscountPercentage / 100);
        }
        public override void ReportProduct()
        {
            Console.WriteLine($"{_productName} is on discount at {DiscountPercentage} and costs {CalculateFinalPrice()}");
        }
        private int CalculateDiscountPercentage()
        {
            if (_price > 200)
            {
                return 20;
            }
            else if (_price > 100)
            {
                return 10;
            }
            return 0;
        }
    }

}
