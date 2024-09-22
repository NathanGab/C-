using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://api.github.com/user/1";
        
        using (HttpClient client = new HttpClient())
        {
            // Adiciona o User-Agent obrigatório para requisições na API do GitHub
            client.DefaultRequestHeaders.Add("User-Agent", "C# console app");

            try
            {
                // Fazendo a requisição GET
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lendo o conteúdo da resposta como string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializando o JSON para um objeto dinâmico
                dynamic user = JsonConvert.DeserializeObject(responseBody);

                // Exibindo os dados no console
                Console.WriteLine("Nome: " + user.name);
                Console.WriteLine("Empresa: " + user.company);
                Console.WriteLine("Localização: " + user.location);
                Console.WriteLine("Login: " + user.login);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nOcorreu um erro:");
                Console.WriteLine("Mensagem: {0} ", e.Message);
            }
        }
    }
}
