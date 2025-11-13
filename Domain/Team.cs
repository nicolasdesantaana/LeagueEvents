using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LeagueId { get; set; }
    }
}
