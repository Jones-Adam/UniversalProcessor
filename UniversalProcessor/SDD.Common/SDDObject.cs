using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    class SDDObject : SDDDataViewDefinition
    {
        private readonly object value;

        public SDDObject() : base(CommonDefinitions.SSDObject)
        {
            value = null;
        }

        public SDDObject(object initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
