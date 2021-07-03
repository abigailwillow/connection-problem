using Sandbox;
using Sandbox.UI;

namespace ConnectionProblem {
	public partial class ConnectionProblemUI : HudEntity<RootPanel> {
		public ConnectionProblemUI() {
			if (!IsClient) { return; }

			RootPanel.StyleSheet.Load("ui/ConnectionProblemUI.scss");
			RootPanel.AddChild<ConnectionProblemCounter>();
		}
	}
}
