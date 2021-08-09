using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCBCDemo.Business.Common.Utility.Pagination
{
    public class CustomPageModel<T> where T : class
    {
        public int RecordCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<T> DataList { get; set; }

        public string SearchString { get; set; }
    }
}
