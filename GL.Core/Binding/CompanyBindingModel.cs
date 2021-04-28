using GL.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GL.Core.Binding
{
    public class CompanyBindingModel
    {
        public string Name { get; set; } = null!;

        public Exchange Exchange { get; set; }

        public string Ticker { get; set; } = null!;

        public string ISIN { get; set; } = null!;

        public string? Website { get; set; }
    }
}