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
            _productName = productName;
            _price = price;
        }
        public abstract string GetProductName();

        public abstract decimal GetPrice();

        public virtual void ReportProduct()
        {
            Console.WriteLine($"{_productName} costs £{_price}");
        }

    }
}
