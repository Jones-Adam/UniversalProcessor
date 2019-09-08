using System;
using System.Collections.Generic;
using System.Text;
using UniversalProcessor.SDD.Common;

namespace UniversalProcessor.Processors
{
    public class StringDescriber : DataDescriber
    {
        public override bool CanProcess(object data)
        {
            if (data is String)
                return true;

            return false;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            List<SDDDataViewDefinition> views = new List<SDDDataViewDefinition>();
            if (data is string)
            {
                string strData = data as string;
                views.Add(new SDDString(strData));
                views.Add(new SDDListCharacters(strData.ToCharArray()));
            }
            return views;
        }
    }
}
