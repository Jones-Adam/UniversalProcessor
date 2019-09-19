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

        /// <summary>
        /// Adds a new property to the object
        /// </summary>
        /// <param name="index">The identifier of the property</param>
        /// <param name="propertyName">A name for the property</param>
        /// <param name="propertyType">The property type</param>
        /// <param name="func">A delegate to call to obtain the value of the property</param>
        /// <returns>The id of the calculating function</returns>
        public int Add(int index, string propertyName, Guid propertyType, Delegate func)
        {
            int calindex = GetFirstUnusedKey(Calculators);
            Calculators.Add(calindex, func);
            Properties.Add(index, new SDDPropertyDefinition(propertyName, propertyType, calindex));
            return calindex;
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

        private static int GetFirstUnusedKey<TValue>(Dictionary<int, TValue> dict)
        {
            if (dict.Comparer != Comparer<int>.Default)
                throw new NotSupportedException("Unsupported comparer");

            using (var enumerator = dict.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                    return 0;

                var nextKeyInSequence = enumerator.Current.Key + 1;

                if (nextKeyInSequence < 1)
                    throw new InvalidOperationException("The dictionary contains keys less than 0");

                if (nextKeyInSequence != 1)
                    return 0;

                while (enumerator.MoveNext())
                {
                    var key = enumerator.Current.Key;
                    if (key > nextKeyInSequence)
                        return nextKeyInSequence;

                    ++nextKeyInSequence;
                }

                return nextKeyInSequence;
            }
        }
    }
}
