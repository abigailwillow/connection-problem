namespace ConnectionProblem {
    public class UserScore {
        public ulong SteamId { get; set; }
        public float Score { get; set; }

        public UserScore(ulong steamid, float score) {
            this.SteamId = steamid;
            this.Score = score;
        }
    }
}