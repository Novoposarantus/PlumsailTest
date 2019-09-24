using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Models;

namespace Domain.DTOs
{
    public class ObjectDto
    {
        private const string NotSingleObjectError = "Попытка создать множественное поле с данными разных объектов";
        public Guid Id { get; set; }
        public List<FieldDto> Fields { get; set; }
        public ObjectDto(IEnumerable<FieldModel> fields)
        {
            var firstField = fields.First();
            if (fields.Any(field => field.ObjectId != firstField.ObjectId))
            {
                throw new FieldException(NotSingleObjectError);
            }

            Id = firstField.ObjectId;
            var fieldsByLineNumber = fields.ToListDictionary(field => field.LineNumber);
            Fields = fieldsByLineNumber.Values.Select(groupedFields => new FieldDto(groupedFields)).ToList();
        }

    }
}
