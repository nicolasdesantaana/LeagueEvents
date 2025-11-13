using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class League
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
