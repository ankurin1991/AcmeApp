using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the products
    /// </summary>
    public class Product
    {
        public const double InchesPerMeter = 39.37; 

        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created");
            this.Category = "Tools";
            var logAction = LoggingService.LogAction("Test");
        }
        public Product(int productId, string productName,
            string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name: " + 
                ProductName);
        }
        #endregion

        #region Properties
        // Using Null Operator: "?"
        private DateTime? availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }


        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get 
            {
                //Lazy Loading
                if(productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor; 
            }
            set { productVendor = value; }
        }

        internal string Category { get; set; }

        //Auto-Implemented Properties
        public int SequenceNumber { get; set; } = 1;

        //public string ProductCode
        //{
        //    get { return this.Category + "-" + this.SequenceNumber};
        //}

        //Expression-Bodied Properties
        public string ProductCode => this.Category + "-" + this.SequenceNumber;

        #endregion

        public string SayHello()
        {
            return "Hello " + ProductName +
                " (" + ProductId + "): " +
                Description + 
                " Available on: " +
                AvailabilityDate?.ToShortDateString();
        }

        public override string ToString() =>
            this.ProductName + "(" + this.ProductId + ")";
    }
}
