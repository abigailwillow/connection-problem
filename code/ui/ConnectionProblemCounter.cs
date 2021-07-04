using System;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class ConnectionProblemCounter : Panel {
        private Label label;
        private float counter = 0;
        double lastCounter = 0;
        private string message = "WARNING: Connection Problem\nAuto-disconnect in %seconds% seconds";

        public ConnectionProblemCounter() {
            label = Add.Label(message.Replace("%seconds%", "0.0"), "connection-problem-text");
            LoadUserScoreAsync();
        }

        public async void LoadUserScoreAsync() {
            UserScore userScore = await APIClient.getScoreAsync(Local.SteamId);
            counter = userScore.Score;
            Log.Info($"Retrieved score for SteamID {userScore.SteamId} and set score to {userScore.Score}");
        }

        public override void Tick() {
            label.Text = message.Replace("%seconds%", $"{counter:0.0}");
            counter += RealTime.Delta;

            double roundedTime = Math.Round(counter);
            if (roundedTime % 30 == 0 && roundedTime != lastCounter) {
                APIClient.setScoreAsync(new UserScore(Local.SteamId, counter));
                Log.Info($"Updated score for SteamID {Local.SteamId} to {counter}");
                lastCounter = roundedTime;
            }
        }
    }
}