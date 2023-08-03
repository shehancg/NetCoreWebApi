using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Models;

namespace CoreWebApi.Repository
{
    public interface IAllocateClassroomsRepository
    {
        Task<IEnumerable<AllocateClassroomsModel>> GetAllAllocateClassrooms();
        Task<AllocateClassroomsModel> GetAllocateClassroomById(int allocationId);
        Task<AllocateClassroomsModel> AddAllocateClassroom(AllocateClassroomsModel allocation);
        Task<AllocateClassroomsModel> UpdateAllocateClassroom(AllocateClassroomsModel allocation);
        Task<bool> DeleteAllocateClassroom(int allocationId);
    }
}
