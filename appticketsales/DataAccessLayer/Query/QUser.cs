using DataAccessLayer.Connection;
using DataAccessLayer.Entities;
using DataTransferLayer.Objects;

namespace DataAccessLayer.Query
{
    public class QUser
    {
        public int create (DtoUser dtoUser)
        {
            using DataBaseContext dbc = new();

            dbc.Users.Add(AutoMapper.mapper.Map<User>(dtoUser));

            return dbc.SaveChanges();
        }

        public DtoUser getById(string idUser)
        {
            using DataBaseContext dbc = new();

            return AutoMapper.mapper.Map<DtoUser>(dbc.Users.Find(idUser));
        }

        public List<DtoUser> getAll()
        {
            using DataBaseContext dbc = new();

            return AutoMapper.mapper.Map<List<DtoUser>>(dbc.Users.ToList());
        }

        public int update(DtoUser dtoUser)
        {
            using DataBaseContext dbc = new();
    
            User user = dbc.Users.Find(dtoUser.idUser);

            user.idSubsidiary = dtoUser.idSubsidiary;
            user.username = dtoUser.username;
            user.password = dtoUser.password;
            user.firstName = dtoUser.firstName;
            user.surName = dtoUser.surName;
            user.dni = dtoUser.dni;
            user.birthDate = dtoUser.birthDate;
            user.gender = dtoUser.gender;
            user.modificationDate = dtoUser.modificationDate;

            return dbc.SaveChanges();
        }

        public int delete(string idUser)
        {
            using DataBaseContext dbc = new();

            int quantityModify = 0;

            User user = dbc.Users.Find(idUser);

            if (user is not null)
            {
                dbc.Users.Remove(user);
                quantityModify = dbc.SaveChanges();
            }

            return quantityModify;
        }
    }
}
