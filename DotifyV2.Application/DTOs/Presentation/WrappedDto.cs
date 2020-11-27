
namespace DotifyV2.Application.DTOs.Presentation
{
	public class WrappedDto<TDataDto>
	{
		public bool Success { get; set; } 
		public TDataDto Data { get; set; }

		public WrappedDto(TDataDto data)
		{
			Success = data != null;
			Data = data;
		}
	}
}
