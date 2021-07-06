using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class LeaderboardEntry : Panel {
        private WebSocket client = new WebSocket();

        public LeaderboardEntry(UserScore userScore, int place) {
            this.Add.Image(userScore.avatar, "leaderboard-entry-image");
            this.Add.Label($"{place}. {userScore.name} - {userScore.score} seconds", "leaderboard-entry-text");
        }
    }
}