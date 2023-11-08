using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class BookStatusDto : IDto
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Status { get; set; }
        public DateTime ReserveDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
