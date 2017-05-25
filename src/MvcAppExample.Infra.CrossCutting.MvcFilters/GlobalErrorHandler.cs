using System.Web.Mvc;

namespace MvcAppExample.Infra.CrossCutting.MvcFilters
{
    public class GlobalErrorHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // MUITO CUIDADO AQUI - VOCÊ ESTÁ ENTRANDO NO MEIO DO PIPELINE DO ASP.NET, PODE IMPACTAR EM PERFORMANCE
            // FAÇA SEMPRE DE FORMA ASYNC
            // filterContext -> possui toda a informação do request

            //TODO: aqui você pode fazer um log de auditoria --> Tal usuario gravou X info na model Y

            if (filterContext.Exception != null)
            {
                // TODO: Manipular a EX
                // Injetar alguma LIB de tratamento de erro
                //  -> Gravar log do erro no BD
                //  -> Email para o admin
                //  -> Retornar cod de erro amigavel

                filterContext.Controller.TempData["ErrorMessage"] = filterContext.Exception.Message;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
