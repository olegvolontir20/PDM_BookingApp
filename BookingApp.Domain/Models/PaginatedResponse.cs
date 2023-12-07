using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Domain.Models
{
    public class PaginatedResponse<T>
    {
        public int Count { get; set; }
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public T Items { get; set; }

        public PaginatedResponse(int count, int perPage, int currentPage, T items)
        {
            Count = count;
            PerPage = perPage;
            CurrentPage = currentPage;
            Items = items;
        }
    }
}
