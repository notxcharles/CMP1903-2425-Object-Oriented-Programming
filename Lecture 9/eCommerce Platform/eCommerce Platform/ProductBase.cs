using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Platform
{
    public abstract class ProductBase
    {
        private protected string _productName;
        private protected decimal _price;
        public ProductBase(string productName, decimal price)
        {
            CheckValidName(productName);
            _productName = productName;
            CheckValidPrice(price);
            _price = price;
        }
        private void CheckValidName(string productName)
        {
            if (String.IsNullOrEmpty(productName))
            {
                throw new Exception("productName is null or empty");
            }
        }
        private void CheckValidPrice(decimal price)
        {
            if (_price <= 0)
            {
                throw new Exception("Price must be positive");
            }
        }
        public abstract string GetProductName();

        public abstract decimal GetPrice();

        public virtual void ReportProduct()
        {
            Console.WriteLine($"{_productName} costs £{_price}");
        }

    }
}
