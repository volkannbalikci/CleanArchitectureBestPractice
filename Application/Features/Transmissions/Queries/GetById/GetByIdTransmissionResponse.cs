using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetById;

public class GetByIdTransmissionResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
