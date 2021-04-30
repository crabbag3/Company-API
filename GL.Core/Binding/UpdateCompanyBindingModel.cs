using System;
using System.Collections.Generic;
using System.Text;

namespace GlassLewis.Core.Binding
{
    public class UpdateCompanyBindingModel : CompanyBindingModel
    {
        /// <summary>
        /// ISIN of the company
        /// </summary>
        public string Id { get; set; } = null!;
    }
}