using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatusGraphQL.Entities
{
    public class MentalStatus
    {
        public System.Guid? Id { get; set; }
        public int Status { get; set; }

        public DateTime StatusDate { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }

        public int Age { get; set; }
        public int Sex { get; set; }

        public string AddInfo { get; set; }
       
    }

    public enum Sex
    {
        Female,
        Male,
        NA
    }

    public enum MStatus
    {
        VeryBad,
        Bad,
        Average,
        Good,
        Excellent
    }
}
