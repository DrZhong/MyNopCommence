using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nop.Web.Models.Catalog
{
    public partial class ProductOverviewModel
    {
        public bool ShowVendor { get; set; }
        public VendorBriefInfoModel VendorModel { get; set; }
    }
}