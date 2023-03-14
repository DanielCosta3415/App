using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class MyServer
    {
        private readonly HttpListener _listener;

        public MyServer(string uri)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(uri);
            _listener.Start();
        }

        public async Task IniciateAsync()
        {
            while (true)
            {
                var context = await _listener.GetContextAsync();
                var response = context.Response;
                var request = context.Request;

                var book = new MyBook {Id = 1, Author = "Daniel Costa", Description = "Programação I", Title = "Programando em C#"};
                var json = JsonConvert.SerializeObject(book);

                var buffer = Encoding.UTF8.GetBytes(json);

                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
}
