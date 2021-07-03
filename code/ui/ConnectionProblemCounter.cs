using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace ConnectionProblem {
    public class ConnectionProblemCounter : Panel {
        public Label label;
        public float counter = 0;

        public ConnectionProblemCounter() {
            label = Add.Label("WARNING: Connection Problem\nAuto-disconnect in 0.0 seconds", "connection-problem-text");
        }

        public override void Tick() {
            label.Text = $"WARNING: Connection Problem\nAuto-disconnect in {counter:0.0} seconds";
            counter += RealTime.Delta;
        }
    }
}