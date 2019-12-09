using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class RelaxComplex : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float Raiting { get; set; }
        public string ContactInformation { get; set; }
    }
}
