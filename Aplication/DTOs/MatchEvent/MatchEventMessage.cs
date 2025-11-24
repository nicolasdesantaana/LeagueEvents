using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.DTOs.MatchEvent
{
    public class MatchEventMessage
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public string MatchEventType { get; set; }
        public int LeagueId { get; set; }
        public DateTime Time { get; set; }
    }
}
