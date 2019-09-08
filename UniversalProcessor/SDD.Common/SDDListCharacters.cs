using System;
using System.Collections.Generic;

namespace UniversalProcessor.SDD.Common
{
    public class SDDListCharacters : SDDDataViewDefinition
    {
        private const int ID_LIST_LENGTH = 0;

        private const int FUNC_GetLength = 0;

        private readonly List<char> chars;

        public SDDListCharacters() : base(CommonDefinitions.SSDCharList)
        {
            chars = new List<char>();
            this.Calculators.Add(FUNC_GetLength, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(chars.Count); }));
            //this.Calculators.Add(FUNC_GetLength, (SSDCalculate)GetLength);
            this.Add(ID_LIST_LENGTH, "Length", CommonDefinitions.SDDInteger, FUNC_GetLength);
        }

        public SDDListCharacters(List<char> characters) : this()
        {
            chars = characters;
        }

        public SDDListCharacters(char[] characters) : this()
        {
            chars = new List<char>(characters);
        }

        public override string DisplayValue()
        {
            return string.Join(" ", new string(chars.ToArray()));
        }

        /*
        private void GetLength()
        {
            Properties[ID_LIST_LENGTH].Value = CommonDefinitions.GetDataForNetType(chars.Count);
        }
        */
    }
}
