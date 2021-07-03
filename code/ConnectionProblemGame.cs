using Sandbox;

namespace ConnectionProblem {
	public partial class ConnectionProblemGame : Sandbox.Game {
		public ConnectionProblemGame() {
			if (IsServer) {
				new ConnectionProblemUI();
			}
		}
	}
}
