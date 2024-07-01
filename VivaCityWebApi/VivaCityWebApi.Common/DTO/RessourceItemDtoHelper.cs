using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO {
	public static class RessourceItemDtoHelper {
		public static RessourceItemDto ToDto(this RessourceItemDao ressourceItemDao) {
			return new RessourceItemDto {
				Id = ressourceItemDao.Id,
				Name = ressourceItemDao.Name,
				Picture = ressourceItemDao.Picture,
			};
		}
	}
}
