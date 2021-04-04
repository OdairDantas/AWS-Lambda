using fipe.Contracts;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace fipe
{
    public class App
    {
        private readonly IHttpClientFactory _httpHandler;

        public App(IHttpClientFactory httpHandler)
        {
            _httpHandler = httpHandler;
        }

        public async Task<ResponseRequest> Run()
        {
            
            var client = _httpHandler.CreateClient("https://parallelum.com.br/fipe/api/v1/");
            var response = await client.GetAsync("carros/marcas");

            if(response.StatusCode == HttpStatusCode.NotFound) 
               return new ResponseRequest(null, HttpStatusCode.NotFound);
            
            if (!response.IsSuccessStatusCode)
                return new ResponseRequest("Ops, algo errado aconteceu.",HttpStatusCode.BadRequest);

            var body = await response.Content.ReadAsStringAsync();

            return new ResponseRequest(body, HttpStatusCode.OK);
        }
    }
}
