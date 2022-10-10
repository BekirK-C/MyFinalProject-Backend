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

    }
}
