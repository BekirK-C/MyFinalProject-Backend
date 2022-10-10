using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // readonly constructor'da set edilebilir.
        // set kullanmayarak yazıılımda standardizeyi constructor ile sağlamış oluyoruz.
        public Result(bool success, string message) : this(success)  // this bulunduğu class'ı ifade eder. 
        {
            Message = message;
            // Success = success;  bu kodu tekrar etmemek adında 2.overload ile bu constructor'da :this(success) şeklinde çalıştırıyoruz.
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
