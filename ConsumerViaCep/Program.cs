using static System.Console;

WriteLine("Digite o seu CEP: "); 
var cep = ReadLine(); /** Definição de que o que foi inserido será lido pelo console */

var url = $@"https://viacep.com.br/ws/{cep}/json/"; /**Fazer com que a requisição utilize como base o cep inserido */

WriteLine($"Realizando a requisição para {url}...");

var cliente = new HttpClient(); /**Classe que realiza requisições para a web por meio do protocolo HTTP*/

try {
    HttpResponseMessage? response = await cliente.GetAsync(url); /** Função que capta a resposta da requisição para a web, */
    response.EnsureSuccessStatusCode(); /* Lançar uma exceção caso a resposta seja false. **/

    string respostaAPI = await response.Content.ReadAsStringAsync(); /**Conversão da resposta obtida para String */

    WriteLine(respostaAPI);
}

catch (Exception e) { /** Retorno caso não consiga fazer a requisição*/
    WriteLine("Ocorreu um erro na sua requisição!");
    WriteLine($"Erro: {e.Message}");
}
