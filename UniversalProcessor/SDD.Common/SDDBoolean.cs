using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public class SDDBoolean : SDDDataViewDefinition
    {
         private readonly bool value;

        public SDDBoolean() : base(CommonDefinitions.SSDBoolean)
        {
            value = false;
        }

        public SDDBoolean(bool initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
