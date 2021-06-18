using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.Repository
{
    public interface IRepository<TDomainModel>
        where TDomainModel : class
    {
        Task<bool> InsertAsync(TDomainModel entity);

        Task<bool> DeleteAsync(int id);

        Task<bool> UpdateAsync(int id, TDomainModel entity);

        Task<TDomainModel> GetByIdAsync(int id);

        Task<List<TDomainModel>> GetMultipleByIdAsync(IEnumerable<int> id);

        Task<List<TDomainModel>> GetAllAsync();

    }
}
