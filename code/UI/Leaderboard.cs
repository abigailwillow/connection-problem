using System;
using System.Linq;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class Leaderboard : Panel {
        private Label leaderboard;
        private double lastLeaderboardUpdate = 0;

        public Leaderboard() {
            Add.Label("🏆 Leaderboard", "leaderboard-title");
            leaderboard = Add.Label("", "leaderboard-text");
            LoadLeaderboardAsync();
        }

        public async void LoadLeaderboardAsync() {
            UserScore[] scores = await APIClient.getScoresAsync();
            leaderboard.Text = "";
            scores = scores.OrderByDescending(score => score.Score).ToArray();
            for (int i = 0; i < scores.Length; i++) {
                UserScore score = scores[i];
                leaderboard.Text += $"{i + 1}. {score.Name} - {score.Score:0.0} seconds\n";
                Log.Info("Updated leaderboard");
            }
        }

        public override void Tick() {
            double runTimeRounded = Math.Round(RealTime.Now);
            if (runTimeRounded % 30 == 0 && runTimeRounded != lastLeaderboardUpdate) {
                LoadLeaderboardAsync();
                lastLeaderboardUpdate = runTimeRounded;
            }
        }
    }
}