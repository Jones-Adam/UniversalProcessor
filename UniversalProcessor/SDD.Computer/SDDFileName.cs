using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Computer
{
    public class SDDFileName : SDDDataViewDefinition
    {
        public readonly static Guid FileNameIdentifier = new Guid("e737eea1-9198-44e9-8f02-5e020fe9a916");

        private const int ID_WHOLESTRING_LENGTH = 0;

        private const int FUNC_GetLength = 0;

        private readonly string value;

        public SDDFileName() : base(FileNameIdentifier)
        {
            value = "";
            //this.Calculators.Add(FUNC_GetLength, (SSDCalculateSingle)(() => { return MainProcessor.Describe(value.Length); }));
            //this.Add(ID_WHOLESTRING_LENGTH, "Length", CommonDefinitions.SDDInteger, FUNC_GetLength);
        }

        public SDDFileName(string initValue) : this()
        {
            value = initValue;
        }

        public override string DisplayValue()
        {
            return value;
        }
    }
}
