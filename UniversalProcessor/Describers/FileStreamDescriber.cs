using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UniversalProcessor.Processors
{
    [ProcessorConfiguration(Parent = typeof(StreamDescriber))]
    public class FileStreamDescriber : DataDescriber
    {
        public override bool CanProcess(object data)
        {
            return data is FileStream;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            List<SDDDataViewDefinition> views = new List<SDDDataViewDefinition>();
            if (data is FileStream fs)
            {
                long fileLength = fs.Length;
                string fileName = fs.Name;
                //views.Add( a file record )

                //views.Add( a continer record - byte [] )
            }
            return views;

        }
    }
}
