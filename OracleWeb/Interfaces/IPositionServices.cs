using OracleWeb.Request;
using OracleWeb.Response;

namespace OracleWeb.Interfaces
{
    public interface IPositionServices
    {
        Task<List<PositionResponse>> GetAllPositionAsync();
        Task<PositionResponse> GetPositionAsync(decimal id);
        Task CreatePositionAsync(PositionRequest position);
        Task UpdatePositionAsync(decimal id,PositionRequest position);
        Task DeletePositionAsync(decimal id);
    }
}
