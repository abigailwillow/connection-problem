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
            Add.Label("🏆 Leaderboard", "leaderboard-title");
            leaderboard = Add.Label("", "leaderboard-text");
            InitializeWebsocket();
        }

        public async void InitializeWebsocket() {
            client.OnMessageReceived += json => UpdateLeaderboard(JsonSerializer.Deserialize<UserScore[]>(json));
            await client.Connect($"ws://abbydiode.com:6969/leaderboard");
        }

        public void UpdateLeaderboard(UserScore[] scores) {
            leaderboard.Text = "";
            scores = scores.OrderByDescending(score => score.score).ToArray();
            for (int i = 0; i < scores.Length; i++) {
                UserScore score = scores[i];
                leaderboard.Text += $"{i + 1}. {score.name} - {score.score:0.0} seconds\n";
                Log.Info("Updated leaderboard");
            }
        }
    }
}