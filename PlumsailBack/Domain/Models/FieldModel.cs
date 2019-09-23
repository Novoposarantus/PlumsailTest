using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class FieldModel
    {
        public int Id { get; set; }
        public Guid ObjectId { get; set; }
        public int LineNumber { get; set; }
        public string Value { get; set; }
    }
}
