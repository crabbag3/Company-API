using GlassLewis.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlassLewis.Core.Binding
{
    public class CompanyBindingModel
    {
        public string Name { get; set; } = null!;

        public string Exchange { get; set; } = null!;

        public string Ticker { get; set; } = null!;

        public string ISIN { get; set; } = null!;

        public string? Website { get; set; }
    }
}