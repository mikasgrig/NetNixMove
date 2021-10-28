using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MacawSitecoreProject.Models;
using System.Text.Json;

namespace MacawSitecoreProject.Clients
{
    public class NetNixClient : INetNixClient
    {
        private readonly HttpClient _httpClient;

        public NetNixClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<NetNixMoveModel>> GetAllSoonMovesAsync()
        {
            string url = $"/BartvdPost/NetNix/0.2.0/soon";
            
            return await _httpClient.GetFromJsonAsync<IEnumerable<NetNixMoveModel>>(url);
        }
        public async Task<MoveLikeReadModel> GetMoveLikeAsync(Guid? id)
        {
            string url = $"/BartvdPost/NetNix/0.2.0/like/{id}";
            
            return await _httpClient.GetFromJsonAsync<MoveLikeReadModel>(url);
        }
        public async Task<NetNixMoveModel> GetMoveAsync(Guid? id)
        {
            string url = $"/BartvdPost/NetNix/0.2.0/movie/{id}";
            
            return await _httpClient.GetFromJsonAsync<NetNixMoveModel>(url);
        }
        public async Task<Director> GetDirectorAsync(Guid? id)
        {
            string url = $"/BartvdPost/NetNix/0.2.0/director/{id}";
            
            return await _httpClient.GetFromJsonAsync<Director>(url);
        }
        public async Task<string> AddLike(MoveLikeWriteModel move)
        {
            var moveJson = JsonSerializer.Serialize(move);
            string url = $"/BartvdPost/NetNix/0.2.0/like/{move.MovieId}";
            var response = await _httpClient.PostAsJsonAsync(url, moveJson);
            
            return await response.Content.ReadAsStringAsync() ;
        }
    }
}