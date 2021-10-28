using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MacawSitecoreProject.Models;

namespace MacawSitecoreProject.Clients
{
    public interface INetNixClient
    {
        Task<IEnumerable<NetNixMoveModel>> GetAllSoonMovesAsync();
        Task<MoveLikeReadModel> GetMoveLikeAsync(Guid? id);
        Task<NetNixMoveModel> GetMoveAsync(Guid? id);
        Task<Director> GetDirectorAsync(Guid? id);
        Task<string> AddLike(MoveLikeWriteModel move);
    }
}