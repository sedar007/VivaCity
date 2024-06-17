using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO {
	public static class GameDtoHelper {
		public static GameDto ToDto(this GameDao gameDao) {
			return new GameDto {
				Id = gameDao.Id,
				Name = gameDao.Name,
				Description = gameDao.Description,
				Logo = gameDao.Logo,
			};
		}
	}
}
