using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç
    public interface IResult
    {
        // get ile readonly değer ekliyoruz. set kısmı constructor ile yapılacak.
        bool Success { get; }
        string Message { get; }
    }
}
