using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarResponse
{
    public Guid ModelId { get; set; }
    public string ModelName { get; set; }
    public int Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public short MinFindexScore { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public CarState CarState { get; set; }
}
