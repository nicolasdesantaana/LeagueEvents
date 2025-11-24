using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interfaces
{
    public interface IMatchService
    {
        Task ProcessMatchEvent(int playerId, int matchId, string matchEvent);
    }
}
