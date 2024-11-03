using Godot;

public partial class Coin : Area2D
{
	// Called when the node enters the scene tree for the first time.
	private GameManager GameManager;
	public override void _Ready()
	{
		GameManager = (GameManager)GetNode<Node>("%GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(CollisionObject2D body){
		GD.Print("+1 coin!");
		GameManager.AddPoint();
		QueueFree();
	}
}
