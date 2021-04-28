using GL.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GL.Core.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public string Exchange { get; set; } = null!;

        public string Ticker { get; set; } = null!;

        public string ISIN { get; set; } = null!;

        public string? Website { get; set; }
    }
}