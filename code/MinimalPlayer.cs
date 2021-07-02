using Sandbox;

partial class MinimalPlayer : Player {
	public override void Respawn() {
		SetModel("models/citizen/citizen.vmdl");

		Controller = new WalkController();

		Animator = new StandardPlayerAnimator();

		Camera = new ThirdPersonCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		base.Respawn();
	}
}
