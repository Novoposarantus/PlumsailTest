using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.DTOs
{
    public class NewFieldDto
    {
        public int LineNumber { get; set; }
        public string Value { get; set; }

        public NewFieldDto(string value, int lineNumber)
        {
            LineNumber = lineNumber;
            Value = value;
        }
    }
}
