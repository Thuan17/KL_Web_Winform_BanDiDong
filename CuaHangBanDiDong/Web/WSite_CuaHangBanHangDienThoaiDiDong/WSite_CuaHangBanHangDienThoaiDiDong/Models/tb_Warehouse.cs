//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSite_CuaHangBanHangDienThoaiDiDong.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Warehouse()
        {
            this.tb_ExportWareHouse = new HashSet<tb_ExportWareHouse>();
        }
    
        public int WarehouseId { get; set; }
        public string DiaChi { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Modifeby { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_ExportWareHouse> tb_ExportWareHouse { get; set; }
    }
}
