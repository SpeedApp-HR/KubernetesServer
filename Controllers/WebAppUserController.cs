using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace CubirnatesDemoServer.SharedControllers
{
    public partial class WebAppUser
    {
        public WebAppUser()
        {
        }

        public WebAppUser(string loginName, string shortName, string roleList, string name)
        {
            LoginName = loginName;
            ShortName = shortName;
            RoleList = roleList;
            Name = name;
        }

        public int WebAppUserId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; } = string.Empty;
        public string RoleList { get; set; }
        public string WebAppRoleList { get; set; } = string.Empty;

        public DateTime? JwtExpiredOn { get; set; }
        public DateTime? LastLogin { get; set; }

        [NotMapped]
        public string Token { get; set; }

        public string ClientVersion { get; set; }
        [NotMapped]
        public int TimeZoneOffsetInMin { get; set; }
        [NotMapped]
        public string Culture { get; set; }

        public bool IsGermanCulture() => Culture?.Substring(0, 2).ToLower() == "de";

        //generic Id  
        public int GetEntityId() => WebAppUserId;
        //generic ToString()
        public override string ToString() => $"WebAppUserId: {GetEntityId()}; Name: {Name}";
        //generic EntityInfo()
        public string EntityInfo()
        {
            return $"WebAppUserId: {GetEntityId()}; Loginname:{LoginName}; JwtExpiredOn:{JwtExpiredOn}";

        }
    }


    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public partial class WebAppUserController : Controller
    {


        [HttpPost("LoginWithNameAndPassword"),]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public async Task<IActionResult> LoginWithNameAndPasswordAsync([FromBody] WebAppUser userFromClient)
        {
            try
            {
                userFromClient.ClientVersion = "0.0.1";
                userFromClient.Name = "Test Kubernate";
                userFromClient.RoleList = "Admin";
                userFromClient.ShortName = "KT";
                userFromClient.WebAppUserId = 1;
                userFromClient.Culture = "de-DE";
                return new OkObjectResult(userFromClient);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
