using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO {
	public static class BatimentDtoHelper {
		public static BatimentDto ToDto(this BatimentDao batimentDao) {
			return new BatimentDto {
				Id = batimentDao.Id,
				Name = batimentDao.Name,
				Level = batimentDao.Level,
				Type = batimentDao.Type,
				Cout = batimentDao.Cout?.ToDto(),
				Picture = batimentDao.Picture,
				//Village = batimentDao.Village?.ToDto(),
				VillageId = batimentDao.VillageId,
				CoutId = batimentDao.CoutId,
			};
		}
	}
}

