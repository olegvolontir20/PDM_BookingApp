using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models.ApiResponses
{
    public class PaginationFilter
    {
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }

        public PaginationFilter()
        {
            PerPage = 2;
            CurrentPage = 1;
        }

        public PaginationFilter(int perPage, int currentPage)
        {
            PerPage = perPage > 10 ? 10 : perPage;
            CurrentPage = currentPage < 1 ? 1 : currentPage;
        }
    }
}
