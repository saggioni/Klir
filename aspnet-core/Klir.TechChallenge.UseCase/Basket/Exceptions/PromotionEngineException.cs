using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.UseCase.Basket.Exceptions
{
    public class PromotionEngineException : ApplicationException
    {
        public PromotionEngineException() : base() { }

        public PromotionEngineException(string message) : base(message) { }
        public PromotionEngineException(string message, Exception innerException) : base(message, innerException) { }
    }
}
