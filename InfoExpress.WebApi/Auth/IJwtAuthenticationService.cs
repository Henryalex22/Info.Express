using InfoExpress.EntidadesDeNegocio;

namespace InfoExpress.WebAPI.Auth
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(Usuario pUsuario);
    }
}
