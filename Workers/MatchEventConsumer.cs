using Aplication.DTOs.MatchEvent;
using Aplication.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workers
{
    public class MatchEventConsumer : IConsumer<MatchEventMessage>
    {
        private readonly IMatchService _matchService;

        public MatchEventConsumer(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public async Task Consume(ConsumeContext<MatchEventMessage> context)
        {
            var ev = context.Message;
            await _matchService.ProcessMatchEvent(ev.PlayerId,ev.MatchId,"goal");
        }
    }
}
