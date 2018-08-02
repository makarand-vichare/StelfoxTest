using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core2.BindingModels;

namespace WebApi.Core2.ContentNegotiationFormatters
{
    public class CsvOutputFormatter : OutputFormatterBase<RegisterBindingModel>
    {
        public override void FormatCsv(StringBuilder buffer, RegisterBindingModel viewModel)
        {
              buffer.AppendLine($"{viewModel.Email},\"{viewModel.Gender},\"{viewModel.AboutInfo},\"{viewModel.DateOfBirth}\"");
        }
    }
}
