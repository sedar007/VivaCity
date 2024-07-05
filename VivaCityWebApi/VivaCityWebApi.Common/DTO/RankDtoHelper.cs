using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO;

public static class RankDtoHelper
{
    public static RankDto ToDto(this RankDao rankDao) {
        return new RankDto {
            Score = rankDao.Score,
            Pseudo = rankDao.Pseudo,
        };
    }
}
