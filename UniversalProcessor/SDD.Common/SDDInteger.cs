using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public class SDDInteger : SDDDataViewDefinition
    {
        protected readonly int value;

        public SDDInteger(Guid Identifer) : base(Identifer)
        {
            value = 0;          
        }

        public SDDInteger(int initValue) : this(CommonDefinitions.SDDInteger)
        {
            value = initValue;
        }

        public SDDInteger(Guid Identifier, int initValue) : this(Identifier)
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
