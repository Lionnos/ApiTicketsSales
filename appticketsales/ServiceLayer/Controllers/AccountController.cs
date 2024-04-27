using DataAccessLayer.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ServiceLayer.Generic;
using ServiceLayer.Helper;
using ServiceLayer.ServiceObject;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Controllers
{
    public class AccountController : ControllerGeneric<SoAuthentication>
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoAuthentication> Login(SoAuthentication so)
        {
            try
            {
                _so.dto = new QAuthentication().getByUsername(so.dto.username);

                if (_so.dto != null && _so.dto.password == so.dto.password)
                {
                    _so.dto.password = null;

                    #region protection jwt
                    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.GetJwtSecret()));
                    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    Claim[] claimAccount = new[]
                    {
                        new Claim("DtoAuthentication", JsonConvert.SerializeObject(_so.dto))
                    };

                    SecurityToken token = new JwtSecurityToken
                    (
                        issuer: AppSettings.GetOriginIssuer(),
                        audience: AppSettings.GetOriginAudience(),
                        claims: claimAccount,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: credentials
                    );

                    _so.token = new JwtSecurityTokenHandler().WriteToken(token);
                    #endregion

                    _so.mo.listMessage.Add("Bienvenido al sistema.");
                    _so.mo.Success();
                }
                else
                {
                    _so.dto = null;
                    _so.mo.listMessage.Add("Usuario o contraseña incorrecta.");
                    _so.mo.Error();
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
    }
}
