using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.DTOs
{
    public class FieldDto
    {
        private const string NullFieldError = "Попытка создать пустое поле.";

        public int LineNumber { get; }
        public List<string> Values { get; }

        public FieldDto(IEnumerable<FieldModel> fields)
        {
            if (!fields.Any())
            {
                throw new FieldException(NullFieldError);
            }

            var firstField = fields.First();
            LineNumber = firstField.LineNumber;
            Values = fields.Select(field => field.Value).ToList();
        }
    }
}
