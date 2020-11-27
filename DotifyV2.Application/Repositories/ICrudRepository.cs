using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotifyV2.Application.Repositories
{
	public interface ICrudRepository<DTO>
	{
		Task<IEnumerable<DTO>> GetAllAsync();
		Task<DTO> GetAsync(int id);
		Task<DTO> GetWithRelationsAsync(int id);
		Task<bool> UpdateAsync(DTO model);
		Task<DTO> CreateAsync(DTO model);
		Task<bool> DeleteAsync(int id);
	}
}
