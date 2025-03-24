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

        public DiscountedProduct(string productID, string productName, decimal price, decimal discountPercentage): base(productName, price)
        {
            ProductID = productID;
            DiscountPercentage = discountPercentage;
        }

        public override string GetProductName() => _productName;
        public override decimal GetPrice() => _price;
        public decimal CalculateFinalPrice()
        {
            return _price * (1 - DiscountPercentage / 100);
        }
        public override void ReportProduct()
        {
            Console.WriteLine($"{_productName} is on discount at {DiscountPercentage} and costs {_price}");
        }

    }

}
