using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor
{

    public class SelfDescribingData
    {
        public object SourceData { get; set; }

        protected List<SDDDataViewDefinition> DataViews { get; set; } = new List<SDDDataViewDefinition>();

        public List<Exception> Errors { get; set; } = new List<Exception>();

        public SelfDescribingData(ref object sourceData)
        {
            SourceData = sourceData;
        }

        #region API

        public int ViewCount
        {
            get { return DataViews.Count; }
        }

        public SDDDataViewDefinition GetViewDefinition(int index)
        {
            return DataViews[index];
        }

        public SDDDataViewDefinition GetViewOfType(Guid typeIdentifier)
        {
            for (int i = 0; i < DataViews.Count; i++)
            {
                if (DataViews[i].Identifier == typeIdentifier)
                {
                    return DataViews[i];
                }
            }
            return null;
        }

        #endregion

        internal void Add(SDDDataViewDefinition dataView)
        {
            DataViews.Add(dataView);
        }

        internal void AddRange(List<SDDDataViewDefinition> dataViews)
        {
            DataViews.AddRange(dataViews);
        }

    }
}
