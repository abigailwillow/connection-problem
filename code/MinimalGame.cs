using Sandbox;

public partial class MinimalGame : Sandbox.Game {
	public MinimalGame() {
		if (IsServer) {
			Log.Info("Shit has loaded");

			new ConnectionErrorHud();
		}

		if (IsClient) {
			Log.Info("asdfsd");
		}
	}

	public override void ClientJoined(Client client) {
		base.ClientJoined(client);
	}
}
