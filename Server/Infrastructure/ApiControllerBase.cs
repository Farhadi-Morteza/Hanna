
namespace Infrastructure
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ApiControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        //protected Guid UserId => FindUserId();
        //private Guid FindUserId()
        //{
        //    var ss =
        //        this.User.Identity?.Name;

        //    var result =
        //        Guid.Parse(this.User.Claims.First(c => c.Type == "UserId").Value);
        //    return result;
        //}

        protected Guid UserId => FindClaim("UserId") == string.Empty? Guid.Empty : Guid.Parse( FindClaim("UserId"));
        protected Guid CompanyId => Guid.Parse(FindClaim("CompanyId"));

        private string FindClaim(string claimName)
        {
            var claim = this.User.Claims.FirstOrDefault(c => c.Type == claimName);
            if (claim == null)
            {
                return string.Empty;
            }
            return claim.Value;
        }
    }
}
