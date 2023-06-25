using EFGetSetValues.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetSetValues
{
    public class MappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Country, Country>
                .NewConfig();
        }
    }
}
