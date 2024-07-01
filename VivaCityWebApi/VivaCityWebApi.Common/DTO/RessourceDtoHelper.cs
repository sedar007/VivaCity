using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO {
	public static class RessourceDtoHelper {
		public static RessourceDto ToDto(this RessourceDao ressourceDao) {
			return new RessourceDto {
				Id = ressourceDao.Id,
				RessourceItem = ressourceDao.RessourceItem?.ToDto(),
				Nbr = ressourceDao.Nbr,
				Max = ressourceDao.Max,
				VillageId = ressourceDao.VillageId,
			};
		}
	}
}