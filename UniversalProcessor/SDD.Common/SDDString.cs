using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public class SDDString : SDDDataViewDefinition
    {
        private const int ID_WHOLESTRING_LENGTH = 0;

        private const int FUNC_GetLength = 0;

        private readonly string value;

        public SDDString() : base(CommonDefinitions.SDDString)
        {
            value = "";
            this.Calculators.Add(FUNC_GetLength, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.Length); }));
            this.Add(ID_WHOLESTRING_LENGTH, "Length", CommonDefinitions.SDDInteger, FUNC_GetLength);
        }

        public SDDString(string initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value;
        }
    }
    //TODO: new class - Word
}
