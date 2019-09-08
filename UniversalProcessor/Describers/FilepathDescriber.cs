using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UniversalProcessor.SDD.Computer;

namespace UniversalProcessor.Processors
{
    public class FilepathDescriber : DataDescriber
    {
        private const int MAX_PATH = 260;

        public override bool CanProcess(object data)
        {
            if (data is string filenameCandidate)
            {
                if (string.IsNullOrWhiteSpace(filenameCandidate) || filenameCandidate.Length > MAX_PATH || filenameCandidate.Length < 4)
                {
                    return false;
                }

                if (filenameCandidate.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                {
                    return false;
                }
                
                //TODO: more robust path checking

                return true;
            }
            return false;
        }

        public override List<SDDDataViewDefinition> GenerateViews(object data)
        {
            List<SDDDataViewDefinition> views = new List<SDDDataViewDefinition>();
            if (data is string filename )
            {
                System.IO.FileInfo fi = null;
                try
                {
                    fi = new System.IO.FileInfo(filename);
                }
                catch (ArgumentException) { }
                catch (System.IO.PathTooLongException) { }
                catch (NotSupportedException) { }
                if (!(fi is null) && Path.IsPathRooted(filename))
                {
                    views.Add(new SDDFileName(filename));
                }            
            }
            return views;

        }
    }
}
