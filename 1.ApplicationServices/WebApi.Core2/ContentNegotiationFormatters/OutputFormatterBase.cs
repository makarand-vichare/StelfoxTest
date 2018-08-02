using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core2.BindingModels;

namespace WebApi.Core2.ContentNegotiationFormatters
{
    public abstract class OutputFormatterBase<T> : TextOutputFormatter where T: class
    {
        public OutputFormatterBase()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            if (typeof(T).IsAssignableFrom(type) || typeof(IEnumerable<T>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<T>)
            {
                foreach (var viewodel in (IEnumerable<T>)context.Object)
                {
                    FormatCsv(buffer, viewodel);
                }
            }
            else
            {
                FormatCsv(buffer, (T)context.Object);
            }

            using (var writer = context.WriterFactory(response.Body, selectedEncoding))
            {
                return writer.WriteAsync(buffer.ToString());
            }
        }

        public abstract void FormatCsv(StringBuilder buffer, T viewModel);
        
    }
}
