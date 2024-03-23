using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Models.AdminToken
{
    public class ProductDetail_Token
    {
        public string Title { get; set; }

        public string Image { get; set; }
        public decimal OrigianlPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }

        public int ProductCategoryId { get; set; }
        public int ProductCompanyId { get; set; }

    }
}