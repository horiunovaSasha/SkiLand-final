using System;
using System.Collections.Generic;
using System.Text;

namespace SkiLand.Domain.Entities
{
    public class RelaxServiceRelaxComplex : IEntity
    {
        public long Id { get; set; }
        //public int RelaxServiceId { get; set; }
        public RelaxServise RelaxServise { get; set; }
        //public int RelaxComplexId { get; set; }
        public RelaxComplex RelaxComplex { get; set; }
    }
}
