using HW_9.Classes;
using System.Collections;

namespace HW_9.Services
{
    public class AgeComparer : IComparer
    {
        public int Compare(Object? x, Object? y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
}
