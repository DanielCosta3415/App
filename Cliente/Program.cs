using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8080/");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var book = JsonConvert.DeserializeObject<MyBook>(json);

                Console.WriteLine($"Id: {book.Id}, Author: {book.Author}, Description: {book.Description}, Title: {book.Title}");
            }
            
            else
            {
                Console.WriteLine($"Erro ao obter dados: {response.StatusCode}");
            }
        }
    }
}
