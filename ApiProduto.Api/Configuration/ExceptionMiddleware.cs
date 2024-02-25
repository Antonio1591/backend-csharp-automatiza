using ApiProduto.Aplicattion;
using ApiProduto.Domain;

namespace ApiProduto.Api.Configuration
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainException ex)
            {

                HandleDomainExceptionAsync(httpContext, ex.Message);
            }
        }

        private void HandleDomainExceptionAsync(HttpContext context, string message)
        {


            var response = new RespostaApi<object>
            {
                Erro = true,
                MensagemErro = new List<string>() { message }
            };

            context.Response.StatusCode = 400;
            context.Response.WriteAsJsonAsync(response);
            return;
        }
    }
}
