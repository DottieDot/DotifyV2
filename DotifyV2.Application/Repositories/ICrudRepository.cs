using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotifyV2.Application.Repositories
{
	public interface ICrudRepository<TModelDescription, TModel>
	{
		Task<IEnumerable<TModelDescription>> GetAllAsync();
		Task<TModelDescription> GetAsync(int id);
		Task<TModel> GetFullAsync(int id);
		Task<bool> UpdateAsync(TModelDescription model);
		Task<TModelDescription> CreateAsync(TModelDescription model);
		Task<bool> DeleteAsync(int id);
	}
}
