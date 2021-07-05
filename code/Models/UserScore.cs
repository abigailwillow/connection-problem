namespace ConnectionProblem {
    public class UserScore {
        public string steamid { get; set; }
        public string name { get; set; }
        public float score { get; set; }

        public UserScore(string steamid, string name, float score) {
            this.steamid = steamid;
            this.name = name;
            this.score = score;
        }
    }
}