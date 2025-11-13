using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? TeamId { get; set; }

    }
}
