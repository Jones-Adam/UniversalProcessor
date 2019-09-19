using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalProcessor.SDD.Common
{
    public static class CommonDefinitions
    {
        //primatives
        public readonly static Guid SSDObject = new Guid("df6eebd3-6f83-4b23-a7da-7c551b2ca3e8");

        public readonly static Guid SSDBoolean = new Guid("7a83d6ac-d00f-43be-a89f-390275b28683");
        public readonly static Guid SSDCharacter = new Guid("9690c22b-c264-496c-9997-da1d425ff15d");
        public readonly static Guid SDDInteger = new Guid("3b6c58a4-aecf-46db-b449-3e7106034898");
        public readonly static Guid SDDFloat = new Guid("05a41561-7899-4e90-a00d-ee52e864a3d4");
        public readonly static Guid SDDDouble = new Guid("71397f7b-2fa2-47a3-840b-5070534e9282");

        public readonly static Guid SDDRangeBoundInteger = new Guid("41d1f36c-e4fd-461f-9154-c8d5d208ae2f");

        //Abstract
        public readonly static Guid SSDList = new Guid("31a1e7c8-4caf-4046-9e09-0e84d16fe977");
        public readonly static Guid SSDTuple = new Guid("e9219d90-36db-48c9-89fb-9c46578b0ded");
        public readonly static Guid SSDContainer = new Guid("a524c438-3200-49c3-8c3d-4e4727b7c628");

        public readonly static Guid SDDString = new Guid("da969778-409a-4c6e-9fd9-1a44c3b62928");
        public readonly static Guid SSDCharList = new Guid("d898bc81-80a4-4239-ac7d-381d674d1c6e");

        public readonly static Guid SDDWord = new Guid("bbd9ec42-4712-4f8b-acb4-78c0dd5fb699");

    }
}
