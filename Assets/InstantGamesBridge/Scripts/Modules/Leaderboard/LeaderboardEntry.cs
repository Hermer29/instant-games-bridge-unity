using System.Collections.Generic;

namespace InstantGamesBridge.Modules.Leaderboard
{
    public class LeaderboardEntry
    {
        public readonly string id;

        public readonly string name;

        public readonly List<string> photos;

        public readonly int score;

        public readonly int rank;

        public LeaderboardEntry(string id, string name, List<string> photos, int score, int rank)
        {
            this.id = id;
            this.name = name;
            this.photos = photos;
            this.score = score;
            this.rank = rank;
        }
    }
}