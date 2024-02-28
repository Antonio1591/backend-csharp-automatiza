using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProduto.Infrastructure.ApiCatalogo
{
    public class ApiCatalagoException:Exception
    {
        public ApiCatalagoException() { }
        public ApiCatalagoException(string message) : base(message) { }
        public ApiCatalagoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
