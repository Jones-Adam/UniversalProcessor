using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UniversalProcessor.Processors
{
    public class StreamDescriber : DataDescriber
    {
        public override bool CanProcess(object data)
        {
            if (data is Stream)
            {
                return true;
            }
            return false;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            List<SDDDataViewDefinition> views = new List<SDDDataViewDefinition>();
            if (data is Stream s)
            {
                long streamLength = s.Length;
                //TODO: views.Add( a stream record )

                //TODO: views.Add( a container record - byte [] )
            }
            return views;
        }
    }
}
