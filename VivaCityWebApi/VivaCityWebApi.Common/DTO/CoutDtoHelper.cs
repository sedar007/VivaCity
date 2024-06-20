using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO {
	public static class CoutDtoHelper {
		public static CoutDto ToDto(this CoutDao coutDao) {
			return new CoutDto {
				Id = coutDao.Id,
				Nbr = coutDao.Nbr,
				RessourceId = coutDao.RessourceId,
				Ressource = coutDao.Ressource?.ToDto(),
			};
		}
	}
}


