using System;
using System.Collections.Generic;
using System.Text;
using UniversalProcessor.SDD.Common;

namespace UniversalProcessor.SDD.IT
{
    public class SDDUrl : SDDDataViewDefinition
    {
        public readonly static Guid UrlIdentifier = new Guid("e737eea1-9198-44e9-8f02-5e020fe9a916");

        private const int ID_WHOLESTRING_LENGTH = 0;

        private const int FUNC_GetScheme = 1;
        private const int FUNC_GetHost = 2;
        private const int FUNC_GetPort = 3;
        private const int FUNC_GetPath = 4;
        private const int FUNC_GetQueryString = 5;

        private readonly Uri value;
        
        public SDDUrl() : base(UrlIdentifier)
        {
            value = null;
            //this.Calculators.Add(FUNC_GetLength, (SSDCalculateSingle)(() => { return MainProcessor.Describe(value.Length); }));
            //this.Add(ID_WHOLESTRING_LENGTH, "Length", CommonDefinitions.SDDInteger, FUNC_GetLength);
            this.Calculators.Add(FUNC_GetScheme, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.Scheme); }));
            this.Calculators.Add(FUNC_GetHost, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.DnsSafeHost); }));
            this.Calculators.Add(FUNC_GetPort, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.Port); }));
            this.Calculators.Add(FUNC_GetPath, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.LocalPath); }));
            this.Calculators.Add(FUNC_GetQueryString, (SSDCalculateSingle)(() => { return ProcessorAPI.Describe(value.Query); }));
            this.Add(ID_WHOLESTRING_LENGTH, "Scheme", CommonDefinitions.SDDString, FUNC_GetScheme);
            this.Add(ID_WHOLESTRING_LENGTH, "Host", CommonDefinitions.SDDString, FUNC_GetHost);
            this.Add(ID_WHOLESTRING_LENGTH, "Port", CommonDefinitions.SDDInteger, FUNC_GetPort);
            this.Add(ID_WHOLESTRING_LENGTH, "Path", CommonDefinitions.SDDString, FUNC_GetPath);
            this.Add(ID_WHOLESTRING_LENGTH, "Query", CommonDefinitions.SDDString, FUNC_GetQueryString);
        }

        public SDDUrl(string initValue) : this()
        {
            value = new Uri(initValue);
        }

        public override string DisplayValue()
        {
            return value.OriginalString;
        }
    }
}
