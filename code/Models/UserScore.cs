namespace ConnectionProblem {
    public class UserScore : Score {
        public string steamid { get; private set; }
        public string name { get; private set; }
        public string avatarUrl { get; private set; }

        public UserScore(float score, string steamid, string name, string avatarUrl) : base(score){
            this.steamid = steamid;
            this.name = name;
            this.avatarUrl = avatarUrl;
        }
    }
}