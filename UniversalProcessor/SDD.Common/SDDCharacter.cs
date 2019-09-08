using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public class SDDCharacter : SDDDataViewDefinition
    {
        private readonly char value;

        public SDDCharacter() : base(CommonDefinitions.SSDBoolean)
        {
            value = (char)0;
        }

        public SDDCharacter(char initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
