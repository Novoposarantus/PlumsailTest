using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Abstraction
{
    public interface IObjectRepository
    {
        Task<List<ObjectDto>> GetObjects();
        Task<ObjectDto> GetObject(Guid objectId);
        Task<ObjectDto> SaveObject(IEnumerable<NewFieldDto> fields);
    }
}
