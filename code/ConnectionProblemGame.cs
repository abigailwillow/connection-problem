using Sandbox;

namespace ConnectionProblem {
	public partial class ConnectionProblemGame : Sandbox.Game {
		public ConnectionProblemGame() {
			if (IsServer) {
				new ConnectionProblemUI();
			}
		}

		public override void ClientJoined(Client client) {
			client.Pawn = new ConnectionProblemPlayer();
		}
	}
}
