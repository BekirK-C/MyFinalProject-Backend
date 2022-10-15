using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // static yapmamızın nedeni her kullanımda Messages class'ını new'lememek. Direkt Messages. şeklinde kullabiliriz. Proje boyunca sadece 1 instance oluşturur

        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz!";
        public static string MaintenanceTime = "Sistem Bakımda!";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductCountofCategoryError = "Bir kategoride 10 üründen fazla olamaz!";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductNameAlreadyExist = "Bu isimde başka bir ürün vardır.";
        public static string CategoryLimitExceded = "Kategori limitine ulaşılmıştır.";
    }
}
