using System;
using System.Collections.Generic;

namespace AirConditionerShop.DAL.Entities
{
    public partial class SupplierCompany
    {
        public SupplierCompany()
        {
            AirConditioners = new HashSet<AirConditioner>();
        }

        public string SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierDescription { get; set; }
        public string PlaceOfOrigin { get; set; }

        public virtual ICollection<AirConditioner> AirConditioners { get; set; }
    }
}
