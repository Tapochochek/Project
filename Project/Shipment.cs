//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shipment
    {
        public int id_Shipment { get; set; }
        public int id_Medicament { get; set; }
        public int id_Firms { get; set; }
        public int id_Employee { get; set; }
        public System.DateTime dateShipment { get; set; }
    
        public virtual Medicament Medicament { get; set; }
        public virtual MedicamentFirms MedicamentFirms { get; set; }
        public virtual Workers Workers { get; set; }
    }
}
