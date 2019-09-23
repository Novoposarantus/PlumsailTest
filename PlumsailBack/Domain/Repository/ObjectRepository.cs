using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstraction;
using Domain.DTOs;
using Domain.Extensions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class ObjectRepository : BaseRepository, IObjectRepository
    {
        public ObjectRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<List<ObjectDto>> GetObjects()
        {
            var fields = await Context.Fields.ToListAsync();
            if (!fields.Any())
            {
                return null;
            }

            var fieldByObject = fields.ToListDictionary(field => field.ObjectId);
            return fieldByObject.Values.Select(groupedFields => new ObjectDto(groupedFields)).ToList();
        }

        public async Task<ObjectDto> GetObject(Guid objectId)
        {
            var fields = await Context.Fields.Where(field => field.ObjectId == objectId).ToListAsync();
            return new ObjectDto(fields);
        }

        public async Task<ObjectDto> SaveObject(IEnumerable<NewFieldDto> fields)
        {
            var objectId = Guid.NewGuid();
            var newFields = fields.Select(field => new FieldModel()
            {
                ObjectId = objectId,
                LineNumber = field.LineNumber,
                Value = field.Value
            });
            Context.Fields.AddRange(newFields);
            await Context.SaveChangesAsync();

            return new ObjectDto(newFields);
        }
    }
}
