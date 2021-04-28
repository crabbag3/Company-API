using GL.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GL.Core
{
    public class Company
    {
        public string Name { get; set; } = null!;

        public Exchange Exchange { get; set; }

        public string Ticker { get; set; } = null!;

        [Key]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string ISIN { get; set; } = null!;

        public string? Website { get; set; }
    }
}