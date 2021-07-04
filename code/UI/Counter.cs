using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class Counter : Panel {
        private Label label;
        private float counter = 0;
        double lastCounter = 0;
        private string message = "WARNING: Connection Problem\nAuto-disconnect in %seconds% seconds";

        public Counter() {
            label = Add.Label(message.Replace("%seconds%", "0.0"), "counter-text");
            LoadUserScoreAsync();
        }

        public async void LoadUserScoreAsync() {
            UserScore userScore = await APIClient.getScoreAsync(Local.SteamId);
            counter = userScore.Score;
            Log.Info($"Retrieved score for SteamID {userScore.SteamId} and set score to {userScore.Score}");
        }

        public override void Tick() {
            label.Text = $"WARNING: Connection Problem\nAuto-disconnect in {counter:0.0} seconds";
            counter += RealTime.Delta;
            
            double counterRounded = Math.Round(counter);
            if (counterRounded % 30 == 0 && counterRounded != lastCounter) {
                UserScore userScore = new UserScore(Local.SteamId, counter);
                APIClient.setScoreAsync(userScore);
                Log.Info($"Updated score for SteamID {userScore.SteamId} to {userScore.Score}");
                lastCounter = counterRounded;
            }
        }
    }
}