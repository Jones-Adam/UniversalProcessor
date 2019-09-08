using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public class SDDInteger : SDDDataViewDefinition
    {
        private readonly int value;

        public SDDInteger() : base(CommonDefinitions.SDDInteger)
        {
            value = 0;
           
        }

        public SDDInteger(int initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
