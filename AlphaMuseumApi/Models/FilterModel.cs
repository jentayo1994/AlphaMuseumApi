using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaMuseumApi.Models
{
    public class FilterModel
    {
        public int Limit { get; set; }
        public int Skip { get; set; }

        public FilterModel()
        {
            //Limit = 100;
            //Skip = 0;
        }
    }
}
