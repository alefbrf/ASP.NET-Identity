using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Usuarios_API.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var dataNascimentoClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (dataNascimentoClaim == null) { return Task.CompletedTask; }

            var dataNascimineto = Convert.ToDateTime(dataNascimentoClaim.Value);

            var idadeUsuario = DateTime.Today.Year - dataNascimineto.Year;

            if (dataNascimineto > DateTime.Today.AddYears(-idadeUsuario)) { idadeUsuario--; };

            if (idadeUsuario >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
