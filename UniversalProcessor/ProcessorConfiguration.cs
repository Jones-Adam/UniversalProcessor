using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProcessorConfiguration : Attribute
    {
        public Type Parent;
    }
}
