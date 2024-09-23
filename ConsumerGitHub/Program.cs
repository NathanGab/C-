using static System.Console;
using System.Net.Http;
using System.Text.Json;

WriteLine("Digite o ID do usuário: "); 
var id = ReadLine(); 

var url = $@"https://api.github.com/user/{id}"; 

WriteLine($"Realizando a requisição para {url}...");

var cliente = new HttpClient(); 
cliente.DefaultRequestHeaders.Add("User-Agent", "IntegracaoViacep");

try {
    HttpResponseMessage? response = await cliente.GetAsync(url); 
    response.EnsureSuccessStatusCode(); 

    string respostaAPI = await response.Content.ReadAsStringAsync();

    /**Transformação do JSON em um objeto, podendo acessar seus atributos: */
    var usuario = JsonSerializer.Deserialize<GithubUser>(respostaAPI, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    WriteLine("ID do usuario: " + usuario.id);
    WriteLine("Nome: " + usuario.name);
    WriteLine("Empresa " + usuario.company);
    WriteLine("Localização: " + usuario.location);
    WriteLine("Login: " + usuario.login);

}

catch (HttpRequestException ex) /**Exceção da requisição web */
{
    Console.WriteLine($"Ocorreu um erro ao fazer a requisição para {url}:");
    Console.WriteLine($"Erro: {ex.Message}");
}
catch (Exception ex) /**Exceção do código: */
{
    Console.WriteLine("Ocorreu um erro inesperado:");
    Console.WriteLine($"Erro: {ex.Message}");
}
