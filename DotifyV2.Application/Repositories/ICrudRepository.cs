using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotifyV2.Application.Repositories
{
	public interface ICrudRepository<TModel>
	{
		Task<IEnumerable<TModel>> GetAllAsync();
		Task<TModel> GetAsync(int id);
		Task<bool> UpdateAsync(TModel model);
		Task<bool> CreateAsync(TModel model);
		Task<bool> DeleteAsync(TModel model);
	}
}
