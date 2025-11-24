using Aplication.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Services
{
    public class MatchService : IMatchService
    {
        public Task ProcessMatchEvent(int playerId,int matchId, string matchEvent)
        {
            throw new NotImplementedException();
        }
    }
}
