namespace ConnectionProblem {
    public class UserScore {
        public ulong SteamId { get; set; }
        public string Name { get; set; }
        public float Score { get; set; }

        public UserScore(ulong steamid, string name, float score) {
            this.SteamId = steamid;
            this.Name = name;
            this.Score = score;
        }
    }
}