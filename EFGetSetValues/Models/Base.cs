using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetSetValues.Models
{
    public class Country : Base
    {
        public string CountryName { get; set; } = string.Empty;

        public int CountryCode { get; set; } = 0;

        public List<State> States { get; set; } = new List<State>();
    }

    public class State : Base
    {
        public string StateName { get; set; } = string.Empty;

        public int StateCode { get; set; } = 0;

        public List<District> Districts { get; set; } = new List<District>();

    }

    public class District : Base
    {
        public string DistrictName { get; set; } = string.Empty;

        public int DistrictCode { get; set;} = 0;

    }

    public class Base
    {
        public Base()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
    }
}
