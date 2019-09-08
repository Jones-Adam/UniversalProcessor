using System;
using System.Collections.Generic;

namespace UniversalProcessor.SDD.Common
{
    public class SDDList : SDDDataViewDefinition
    {
        private const int ID_LIST_LENGTH = 0;

        private const int FUNC_GetCount = 0;

        private readonly List<SelfDescribingData> dataSet;

        public SDDList() : base(CommonDefinitions.SSDList)
        {
            dataSet = new List<SelfDescribingData>();
            this.Calculators.Add(FUNC_GetCount, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(dataSet.Count); }));
            this.Add(ID_LIST_LENGTH, "Count", CommonDefinitions.SDDInteger, FUNC_GetCount);
        }

        public SDDList(List<SelfDescribingData> dataSet) : this()
        {
            this.dataSet = dataSet;
        }

        public SDDList(SelfDescribingData[] dataSet) : this()
        {
            this.dataSet = new List<SelfDescribingData>(dataSet);
        }

        public override string DisplayValue()
        {
            return "[list]";
        }
    }
}
