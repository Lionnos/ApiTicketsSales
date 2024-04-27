using DataAccessLayer.Connection;
using DataTransferLayer.Objects;

namespace DataAccessLayer.Query
{
    public class QAuthentication
    {
        public DtoAuthentication getByUsername(string username)
        {
            using DataBaseContext dbc = new();

            return AutoMapper.mapper.Map<DtoAuthentication>(dbc.Users.Where(w => w.username == username).FirstOrDefault());
        }
    }
}
