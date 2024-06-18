using VivaCityWebApi.Common.DAO;

namespace VivaCityWebApi.Common.DTO;

public static class UsersDtoHelper
{
    public static UsersDto ToDto(this UserDao userDao) {
        return new UsersDto {
            Pseudo = userDao.Pseudo,
            Name = userDao.Name,
            
        };
    }
}
