using System;
using System.Collections.Generic;
using System.Text;
using UniversalProcessor.SDD.Common;

namespace UniversalProcessor.Processors
{
    public class IntegerDescriber : DataDescriber
    {
        public override bool CanProcess(object data)
        {
            if (data is int)
                return true;

            return false;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            List<SDDDataViewDefinition> views = new List<SDDDataViewDefinition>();
            if (data is int val)
            {
                views.Add( new SDDInteger(val));
            }
            return views;
        }
    }
}
