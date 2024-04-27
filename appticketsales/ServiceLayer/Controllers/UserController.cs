using DataAccessLayer.Query;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Generic;
using ServiceLayer.ServiceObject;
using System.Transactions;

namespace ServiceLayer.Controllers
{
    public class UserController : ControllerGeneric<SoUser>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoUser> Insert([FromForm] SoUser so)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    so.dtoUser.idUser = Guid.NewGuid().ToString().Substring(0,12);

                    _so.mo = ValidateDto(so.dtoUser, new List<string>()
                    {
                        //nameof(so.dto.name)

                    });

                    if (_so.mo.ExistsMessage())
                    {
                        return _so;
                    }

                    QUser qProfessional = new QUser();

                    so.dtoUser.registerDate = DateTime.Now;
                    so.dtoUser.modificationDate = DateTime.Now;

                    qProfessional.create(so.dtoUser);

                    _so.mo.listMessage.Add("Operación realizada correctamente.");
                    _so.mo.Success();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add("Ocurrió un error inesperado. Estamos trabajando para resolverlo.");
                _so.mo.listMessage.Add("ERROR_EXCEPTION_-_-_" + ex.Message);
                _so.mo.Error();
            }

            return _so;
        }

        [HttpGet]
        [Route("[action]/{idUser}")]
        public ActionResult<SoUser> GetById(string idUser)
        {
            try
            {
                _so.dto = new QUser().getById(idUser);
                _so.mo.Success();
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add("Ocurrió un error inesperado. Estamos trabajando para resolverlo.");
                _so.mo.listMessage.Add("ERROR_EXCEPTION_-_-_" + ex.Message);
                _so.mo.Error();
            }

            return _so;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoUser> GetAll()
        {
            try
            {
                _so.listDto = new QUser().getAll();
                _so.mo.Success();
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add("Ocurrió un error inesperado. Estamos trabajando para resolverlo.");
                _so.mo.listMessage.Add("ERROR_EXCEPTION_-_-_" + ex.Message);
                _so.mo.Error();
            }

            return _so;
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult<SoUser> Update([FromForm] SoUser so)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _so.mo = ValidateDto(so.dtoUser, new List<string>()
                    {
                        //nameof(so.dto.name)
                    });

                    if (_so.mo.ExistsMessage())
                    {
                        return _so;
                    }

                    QUser qUser = new QUser();
                    so.dtoUser.modificationDate = DateTime.Now;

                    /*
                    if (qUser.ExistsByNameDiffId(so.dto.name, so.dto.idProfessional))
                    {
                        _so.mo.listMessage.Add("Este profesional ya se encuentra registrado en el sistema.");
                        _so.mo.Error();

                        return _so;
                    }*/


                    qUser.update(so.dtoUser);

                    _so.mo.listMessage.Add("Operación realizada correctamente.");
                    _so.mo.Success();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add("Ocurrió un error inesperado. Estamos trabajando para resolverlo.");
                _so.mo.listMessage.Add("ERROR_EXCEPTION_-_-_" + ex.Message);
                _so.mo.Error();
            }

            return _so;
        }

        [HttpDelete]
        [Route("[action]/{idUser}")]
        public ActionResult<SoUser> Delete(string idUser)
        {
            try
            {
                new QUser().delete(idUser);

                _so.mo.listMessage.Add("Operación realizada correctamente.");
                _so.mo.Success();
            }
            catch (Exception ex)
            {
                _so.mo.listMessage.Add("Ocurrió un error inesperado. Estamos trabajando para resolverlo.");
                _so.mo.listMessage.Add("ERROR_EXCEPTION_-_-_" + ex.Message);
                _so.mo.Error();
            }

            return _so;
        }
    }
}
