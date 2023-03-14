using System;
using System.Threading.Tasks;

namespace Servidor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new MyServer("http://localhost:8080/");
            await server.IniciateAsync();
        }
    }
}
