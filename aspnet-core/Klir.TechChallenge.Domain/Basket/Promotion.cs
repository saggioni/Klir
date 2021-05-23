using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Domain.Basket
{
    public class Promotion
    {
        public Promotion(int id, string name, string formula, int quantityToApply)
        {
            Id = id;
            Name = name;
            Formula = formula;
            QuantityToApply = quantityToApply;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Formula { get; private set; }
        public int QuantityToApply { get; set; }
    }
}
