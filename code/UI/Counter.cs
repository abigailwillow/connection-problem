using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class Counter : Panel {
        private Label label;
        private float score = 0;
        double lastScoreUpdate = 0;
        private string message = "WARNING: Connection Problem\nAuto-disconnect in %seconds% seconds";

        public Counter() {
            label = Add.Label(message.Replace("%seconds%", "0.0"), "counter-text");
            LoadUserScoreAsync();
        }

        public async void LoadUserScoreAsync() {
            UserScore userScore = await APIClient.getScoreAsync(Local.SteamId);
            score = userScore.Score;
            Log.Info($"Retrieved score for SteamID {userScore.SteamId} and set score to {userScore.Score}");
        }

        public override void Tick() {
            label.Text = $"WARNING: Connection Problem\nAuto-disconnect in {score:0.0} seconds";
            score += RealTime.Delta;
            
            double runTimeRounded = Math.Round(RealTime.Now);
            if (runTimeRounded % 30 == 0 && runTimeRounded != lastScoreUpdate) {
                UserScore userScore = new UserScore(Local.SteamId, Local.DisplayName, score);
                APIClient.setScoreAsync(userScore);
                Log.Info($"Updated score for SteamID {userScore.SteamId} to {userScore.Score}");
                lastScoreUpdate = runTimeRounded;
            }
        }
    }
}