using Aplication.DTOs.MatchEvent;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Services
{
    public class MatchEventPublisher
    {
        private IBus _bus;

        public MatchEventPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishMatchEvent(int matchId, int leagueId, int playerId)
        {
            var message = new MatchEventMessage { MatchId = matchId, LeagueId = leagueId, PlayerId = playerId };
            await _bus.Publish(message);
        }
    }
}
