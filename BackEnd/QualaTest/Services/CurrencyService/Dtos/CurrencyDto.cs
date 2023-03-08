using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CurrencyService.Dtos
{
    public record CurrencyDto(Guid Id, string Name, char Symbol, bool IsActive);
}
