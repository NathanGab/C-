using static System.Console;
using System.Net.Http;
using System.Text.Json;
using ConsumerPokeApi.Models;

public class Program
{
    public static async Task Main()
    {
        WriteLine("Digite o nome do pokemon: ");
        var nome = ReadLine()?.ToLower(); 

        var url = $@"https://pokeapi.co/api/v2/pokemon/{nome}";

        WriteLine($"Realizando a requisição para {url}...");

        
        var cliente = new HttpClient();
        cliente.DefaultRequestHeaders.Add("User-Agent", "ConsumerPokeApi");

        try
        {
            HttpResponseMessage response = await cliente.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string respostaAPI = await response.Content.ReadAsStringAsync();

            var pokemon = JsonSerializer.Deserialize<Pokemon>(respostaAPI, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (pokemon != null)
            {
                WriteLine($"ID: {pokemon.Id}");
                WriteLine($"Nome: {pokemon.Name}");
                WriteLine($"Altura(metros): {pokemon.HeightInMeters}");
                WriteLine($"Peso(kg): {pokemon.WeightInKg}");
            }
            else
            {
                WriteLine("Pokémon não encontrado.");
            }
        }
        catch (HttpRequestException ex)
        {
            WriteLine($"Ocorreu um erro ao fazer a requisição para {url}:");
            WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            WriteLine("Ocorreu um erro inesperado:");
            WriteLine($"Erro: {ex.Message}");
        }
    }
}
