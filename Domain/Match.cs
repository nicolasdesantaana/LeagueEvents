using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Match
    {
        public int Id {  get; set; }
        public int TeamId1 { get; set; }
        public int TeamId2 { get; set; }
        public required Score Score {  get; set; }

    }

    public class Score
    {
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
}
