//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesBillDetail
    {
        public int Id { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> SalesBillId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Sales_Bill Sales_Bill { get; set; }
    }
}
