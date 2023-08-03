using System.Collections.Generic;
using System.Threading.Tasks;
using CoreWebApi.Models;

namespace CoreWebApi.Repository
{
    public interface IAllocateSubjectsRepository
    {
        Task<IEnumerable<AllocateSubjectsModel>> GetAllAllocationsAsync();
        Task<AllocateSubjectsModel> GetAllocationByIdAsync(int allocateSubjectId);
        Task<AllocateSubjectsModel> AddAllocationAsync(AllocateSubjectsModel allocation);
        Task<AllocateSubjectsModel> UpdateAllocationAsync(AllocateSubjectsModel allocation);
        Task<bool> DeleteAllocationAsync(int allocateSubjectId);
    }
}
