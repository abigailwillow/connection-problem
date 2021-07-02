using Sandbox.UI;

public partial class ConnectionErrorHud : Sandbox.HudEntity<RootPanel> {
	public ConnectionErrorHud() {
		if (IsClient) {
			RootPanel.SetTemplate("/ConnectionErrorHud.html");
		}
	}
}
