namespace ConnectionProblem {
    public class UserScore : Score {
        public string steamid { get; private set; }
        public string name { get; private set; }
        public string avatar { get; private set; }

        public UserScore(float score, string steamid, string name, string avatar) : base(score){
            this.steamid = steamid;
            this.name = name;
            this.avatar = avatar;
        }
    }
}