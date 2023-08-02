using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaStore.API.Helpers
{
    public class UserParams
    {
        private const int MAXPAGESIZE = 50;
        public int pageNumber { get; set; } = 1;
        private int PageSize = 10;
        public int pageSize
        {
            get { return PageSize; }
            set { PageSize = (value > MAXPAGESIZE) ? MAXPAGESIZE : value; }
        }

        public int UserId { get; set; }
        public string? email { get; set; }
        public string? orderBy { get; set; }
        public int customerId { get; set; }
    }
}