using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Extensions;
using Domain.Models;

namespace Domain.DTOs
{
    public class ObjectDto
    {
        public List<FieldDto> Fields { get; set; }

        public ObjectDto(IEnumerable<FieldModel> fields)
        {
            var fieldsByLineNumber = fields.ToListDictionary(field => field.LineNumber);
            Fields = fieldsByLineNumber.Values.Select(groupedFields => new FieldDto(groupedFields)).ToList();
        }

    }
}
