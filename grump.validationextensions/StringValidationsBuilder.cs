using System;
using System.Collections.Generic;
using System.Text;

namespace Grump.ValidationExtensions
{
    internal class StringValidationsBuilder
    {
        public string StringUnderValidation { get; set; }

        public StringValidationsBuilder(string stringUnderValidation)
        {
            this.StringUnderValidation = stringUnderValidation;

        }
    }
}
