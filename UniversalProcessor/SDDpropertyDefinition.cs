using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor
{
    public class SDDPropertyDefinition
    {
        public string PropertyName;
        public Guid PropertyType;
        public SelfDescribingData Value;
        public int CalculatingFunctionIndex;

        public SDDPropertyDefinition(string propertyName, Guid propertyType, int calculatorIndex)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            CalculatingFunctionIndex = calculatorIndex;
        }

        public bool HasCalculatingFunction
        {
            get { return CalculatingFunctionIndex >= 0; }
        }

    }
}
