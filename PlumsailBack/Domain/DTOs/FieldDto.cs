using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.DTOs
{
    public class FieldDto
    {
        private const string NullFieldError = "Попытка создать пустое поле.";
        private const string NotSingleObjectError = "Попытка создать множественное поле с данными разных объектов";

        public int LineNumber { get; }
        public List<string> Values { get; }

        public FieldDto(IEnumerable<FieldModel> fields)
        {
            if (!fields.Any())
            {
                throw new FieldException(NullFieldError);
            }


            var firstField = fields.First();
            if (fields.Any(field => field.ObjectId != firstField.ObjectId))
            {
                throw new FieldException(NotSingleObjectError);
            }

            LineNumber = firstField.LineNumber;
            Values = fields.Select(field => field.Value).ToList();
        }
    }
}
