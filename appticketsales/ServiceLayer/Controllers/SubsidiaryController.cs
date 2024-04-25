using DataAccessLayer.Query;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Generic;
using ServiceLayer.ServiceObject;
using System.Transactions;

namespace ServiceLayer.Controllers
{
    public class SubsidiaryController : ControllerGeneric<SoSubsidiary>
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoSubsidiary> Insert([FromForm] SoSubsidiary so)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    so.dto.idSubsidiary = Guid.NewGuid().ToString();

                    //  validacion de datos
                    //  ===================
                    _so.mo = ValidateDto(so.dto, new List<string>()
                    {
                        //nameof(so.dto.name)
                    });

                    if (_so.mo.ExistsMessage())
                    {
                        return _so;
                    }

                    QSubsidiary qSubsidiary = new QSubsidiary();

                    qSubsidiary.create(so.dto);

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
        [Route("[action]/{idSubsidiary}")]
        public ActionResult<SoSubsidiary> GetById(string idSubsidiary)
        {
            try
            {
                _so.dto = new QSubsidiary().getById(idSubsidiary);
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
        public ActionResult<SoSubsidiary> GetAll()
        {
            try
            {
                _so.listDto = new QSubsidiary().getAll();
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
        public ActionResult<SoSubsidiary> Update([FromForm] SoSubsidiary so)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _so.mo = ValidateDto(so.dto, new List<string>()
                    {
                        //nameof(so.dto.name)
                    });

                    if (_so.mo.ExistsMessage())
                    {
                        return _so;
                    }

                    QSubsidiary qUser = new QSubsidiary();

                    /*
                    if (qUser.ExistsByNameDiffId(so.dto.name, so.dto.idProfessional))
                    {
                        _so.mo.listMessage.Add("Este profesional ya se encuentra registrado en el sistema.");
                        _so.mo.Error();

                        return _so;
                    }*/

                    qUser.update(so.dto);

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
        [Route("[action]/{idSubsidiary}")]
        public ActionResult<SoSubsidiary> Delete(string idSubsidiary)
        {
            try
            {
                new QSubsidiary().delete(idSubsidiary);

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
