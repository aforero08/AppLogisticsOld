//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppLogisticsModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        public int Id { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        public int ClientId { get; set; }
        public Nullable<int> ClientAreaId { get; set; }
        public int ActivityId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        public Nullable<int> VehicleTypeId { get; set; }
        public string VehicleNumber { get; set; }
        public Nullable<int> CarrierId { get; set; }
        public string ExternalId { get; set; }
        public string Comments { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }
        public virtual ClientArea ClientArea { get; set; }
        public virtual Product Product { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
