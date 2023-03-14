using System;
using System.Threading.Tasks;

namespace Servidor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new MyServer("http://localhost:5003/");
            await server.IniciateAsync();
        }
    }
}
