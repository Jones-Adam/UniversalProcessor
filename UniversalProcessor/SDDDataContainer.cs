using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public abstract class SDDDataContainer : SDDDataViewDefinition
    {

        //TODO: fetch from source ... in subclasses which know how to handle the source...processor?
        public abstract SelfDescribingData GetContent();

        private SDDDataContainer(Guid Identifier) : base(Identifier)
        {

        }
    }
}
