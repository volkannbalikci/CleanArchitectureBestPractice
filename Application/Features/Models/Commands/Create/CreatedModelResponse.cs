using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create
{
    public class CreatedModelResponse
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
