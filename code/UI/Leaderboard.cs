using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System.Linq;
using System.Text.Json;

namespace ConnectionProblem {
    public class Leaderboard : Panel {
        private Label leaderboard;
        private WebSocket client = new WebSocket();

        public Leaderboard() {
            InitializeWebsocket();
        }

        public async void InitializeWebsocket() {
            client.OnMessageReceived += json => UpdateLeaderboard(JsonSerializer.Deserialize<UserScore[]>(json));
            client.OnMessageReceived += json => Log.Info($"Received updated leaderboard {json}");;
            await client.Connect($"ws://abbydiode.com:6969/leaderboard");
        }

        public void UpdateLeaderboard(UserScore[] scores) {
            this.DeleteChildren(true);
            this.Add.Label("🏆 Leaderboard", "leaderboard-title");
            scores = scores.OrderByDescending(score => score.score).ToArray();
            for (int i = 0; i < scores.Length;) {
                this.AddChild(new LeaderboardEntry(scores[i], ++i));
            }
        }
    }
}