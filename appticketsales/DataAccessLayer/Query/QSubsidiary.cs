using DataAccessLayer.Connection;
using DataAccessLayer.Entities;
using DataTransferLayer.Objects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Query
{
    public class QSubsidiary
    {
        public int create(DtoSubsidiary dtoSubsidiary)
        {
            using DataBaseContext dbc = new();

            dbc.Subsidiarys.Add(AutoMapper.mapper.Map<Subsidiary>(dtoSubsidiary));

            return dbc.SaveChanges();
        }

        public DtoSubsidiary getById(string idSubsidiary)
        {
            using DataBaseContext dbc = new();
            //return AutoMapper.mapper.Map<DtoSubsidiary>(dbc.Subsidiarys.Find(idSubsidiary));

            Subsidiary x = dbc.Subsidiarys.Include(i => i.childUser).Where(w => w.idSubsidiary == idSubsidiary).FirstOrDefault();

            ICollection<DtoUser> dtoUsers = new List<DtoUser>();

            foreach (User user in x.childUser)
            {
                DtoUser dtoUser = AutoMapper.mapper.Map<DtoUser>(user);
                dtoUsers.Add(dtoUser);
            }

            DtoSubsidiary dtoSubsidiary = AutoMapper.mapper.Map<DtoSubsidiary>(x);

            dtoSubsidiary.childDtoUser = dtoUsers;
            
            return dtoSubsidiary;
        }

        public List<DtoSubsidiary> getAll()
        {
            using DataBaseContext dbc = new();

            return AutoMapper.mapper.Map<List<DtoSubsidiary>>(dbc.Subsidiarys.ToList());

            //List<Subsidiary> x = dbc.Subsidiarys.Include(i => i.childUser).ToList();
            //List<ProjectType> y = dbc.ProjectTypes.Include(i => i.childProjectTypeMechanism).ThenInclude(i => i.childAssignProject).OrderBy(ob => ob.name).ToList();
            //return AutoMapper.mapper.Map<List<DtoSubsidiary>>(x);
        }

        public int update(DtoSubsidiary dtoSubsidiary)
        {
            using DataBaseContext dbc = new();

            Subsidiary subsidiary = dbc.Subsidiarys.Find(dtoSubsidiary.idSubsidiary);


            return dbc.SaveChanges();
        }

        public int delete(string idSubsidiary)
        {
            using DataBaseContext dbc = new();

            int quantityModify = 0;

            Subsidiary subsidiary = dbc.Subsidiarys.Find(idSubsidiary);

            if (subsidiary is not null)
            {
                dbc.Subsidiarys.Remove(subsidiary);
                quantityModify = dbc.SaveChanges();
            }

            return quantityModify;
        }
    }
}
