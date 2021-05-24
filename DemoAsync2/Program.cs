using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoAsync2
{
    class Program
    {
        static readonly HttpClient cliente = new HttpClient();
        static async Task Main(string[] args)
        {
            string uri = "https://jsonplaceholder.typicode.com/posts";
            try
            {
                /*
                var resposta = await cliente.GetAsync(uri);
                Console.WriteLine(resposta.StatusCode);
                Console.WriteLine(await resposta.Content.ReadAsStringAsync());
                */
                var resposta = await cliente.GetFromJsonAsync<List<Post>>(uri);
                Console.WriteLine(resposta.Count);
                foreach(var p in resposta)
                {
                    Console.WriteLine(p.title);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
