using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{

    /// <summary>
    /// This describes an integer with an optional lower and upper limit
    /// </summary>
    public class SDDRangeBoundInteger : SDDInteger
    {
        protected readonly int? lowerBound;
        protected readonly int? upperBound;

        public const int PROP_LOWERBOUND = 0;
        public const int PROP_UPPERBOUND = 1;

        public SDDRangeBoundInteger(int initValue, int? lowerLimit, int? upperLimit) : this(CommonDefinitions.SDDRangeBoundInteger, initValue)
        {
            this.lowerBound = lowerLimit;
            this.upperBound = upperLimit;
        }

        public SDDRangeBoundInteger(Guid Identifier, int initValue) : base(Identifier, initValue)
        {
            this.Add(PROP_LOWERBOUND, "LowerBound", CommonDefinitions.SDDInteger, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(lowerBound); }));
            this.Add(PROP_UPPERBOUND, "UpperBound", CommonDefinitions.SDDInteger, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(upperBound); }));
        }

        public SDDRangeBoundInteger(Guid Identifier, int initValue, int? lowerLimit, int? upperLimit) : this(Identifier, initValue)
        {
            this.lowerBound = lowerLimit;
            this.upperBound = upperLimit;
        }


        public override string DisplayValue()
        {
            return value.ToString();
        }
    }
}
