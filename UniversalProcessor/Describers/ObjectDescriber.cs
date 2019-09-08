using System;
using System.Collections.Generic;
using System.Text;
using UniversalProcessor.SDD.Common;

namespace UniversalProcessor.Processors
{
    public class ObjectDescriber : DataDescriber
    {
        public override bool CanProcess(object data)
        {
            return true;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            SDDDataViewDefinition dataview = new SDDObject(data);
            return new List<SDDDataViewDefinition>() { dataview };
        }
    }
}
