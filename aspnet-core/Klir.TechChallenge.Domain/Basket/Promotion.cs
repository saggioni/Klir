using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Basket
{
    public class Promotion
    {
        public Promotion() { }
        public Promotion(int id, string name, string formula, int quantityToApply)
        {
            Id = id;
            Name = name;
            Formula = formula;
            QuantityToApply = quantityToApply;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
        public int QuantityToApply { get; set; }
    }
}
