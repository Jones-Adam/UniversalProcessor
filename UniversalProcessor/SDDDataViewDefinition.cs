using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor
{

    public delegate void SSDCalculate();

    public delegate SelfDescribingData SSDCalculateSingle();

    public abstract class SDDDataViewDefinition
    {
        public Guid Identifier;

        public Dictionary<int, SDDPropertyDefinition> Properties = new Dictionary<int, SDDPropertyDefinition>();
        protected Dictionary<int, Delegate> Calculators = new Dictionary<int, Delegate>();

        public SDDDataViewDefinition(Guid identifier)
        {
            Identifier = identifier;
        }

        public void Add(int index, string propertyName, Guid propertyType, int CalculatorIndex)
        {
            Properties.Add(index, new SDDPropertyDefinition(propertyName, propertyType, CalculatorIndex));
        }

        public SelfDescribingData GetProperty(int PropertyIdentifier)
        {
            SDDPropertyDefinition property = Properties[PropertyIdentifier];

            if (property.HasCalculatingFunction)
            {
                if (Calculators[property.CalculatingFunctionIndex].GetType() == typeof(SSDCalculateSingle))
                {
                    property.Value = ((SSDCalculateSingle)Calculators[property.CalculatingFunctionIndex]).Invoke();
                }
                else
                {
                    Calculators[property.CalculatingFunctionIndex].DynamicInvoke();
                }
            }

            return property.Value;
        }

        public abstract string DisplayValue();
    }
}
