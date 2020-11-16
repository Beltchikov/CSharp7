using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7
{
    public class InlineExceptions
    {
        public static void Demo()
        {
            object someValue = null;
            var anotherValue = someValue ?? throw new ArgumentNullException();

            var secondValue = someValue == null ? throw new InvalidOperationException() : someValue;
        }
    }
}
