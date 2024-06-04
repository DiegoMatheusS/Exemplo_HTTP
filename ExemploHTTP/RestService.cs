using ExemploHTTP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExemploHTTP
{
    public class RestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public ObservableCollection<Postagem> Postagens { get; set; }

        public RestService()
        {
            Postagens = null;
            _client = new HttpClient(); //instanciando
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, //primeira letra minuscula (CamelCase)
                WriteIndented = true //identação
            };
        }
        public async Task<ObservableCollection<Postagem>> GetPostagemsAsync() //Faz o get para visualizar
        {
            Postagens = new ObservableCollection<Postagem>(); // ira fazer nova lista de postagem, pega o que tem na model Postagem

            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            //tentar buscar a informcao da Uri /\


            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri); //pega resposta do uri
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync(); //pega conteudo e le como string
                    Postagens = JsonSerializer.Deserialize<ObservableCollection<Postagem>>(content, _serializerOptions);
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Postagens ??[];
        }
     }
}
