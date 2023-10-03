using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazunov_VisualComponents
{
    public class NotFilledException : Exception
    {
        public NotFilledException() {}
        public NotFilledException(string message) : base(message) {}
        public NotFilledException(string message, Exception inner) : base(message, inner) {}
    }
}
