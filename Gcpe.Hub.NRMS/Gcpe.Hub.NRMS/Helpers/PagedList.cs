using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gcpe.Hub.NRMS.Helpers
{
    public class PagedList<T> : List<T>
    {
        public static IEnumerable<T> Create(IEnumerable<T> source,
            int pageNumber, int pageSize)
        {
            return source.Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }
    }
}
