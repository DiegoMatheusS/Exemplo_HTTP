using ExemploHTTP.Models;
using Microsoft.Maui.Platform;
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

        public RestService() // construtor
        {
            Postagens = null;
            _client = new HttpClient();//instaciei  _client
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }
        //Método para buscar Informação
        public async Task<ObservableCollection<Postagem>> GetPostagensAsync()//Tarefa = 'Task'// É uma lista que devolve 
        {
            Postagens = new ObservableCollection<Postagem>();

            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");// onde vou buscar informação "endereço" 'URL'

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Postagens = JsonSerializer.Deserialize<ObservableCollection<Postagem>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Postagens ?? [];
        }
    }
}
