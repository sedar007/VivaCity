using VivaCityWebApi.Common.DAO;
namespace VivaCityWebApi.Common.DTO {
	public static class VillageDtoHelper {
		public static VillageDto ToDto(this VillageDao villageDao) {
			return new VillageDto {
				Name = villageDao.Name,
				Id = villageDao.Id,
				Level = villageDao.Level,
				Batiments = villageDao.Batiments?.Select(b => b.ToDto()),
				Ressources = villageDao.Ressources?.Select(r => r.ToDto()),
			};
		}
	}
}


