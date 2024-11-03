using Godot;
using System;

public partial class Slime : Node2D
{

	private RayCast2D rcBottomLeft;
	private RayCast2D rcBottomRight;
	private RayCast2D rcLeft;
	private RayCast2D rcRight;
	private AnimatedSprite2D sprite;

	public float speed = 20f;
	public int direction = 1; 
	
	public override void _Ready()
	{
		rcBottomLeft = GetNode<RayCast2D>("RcBottomLeft");
		rcBottomRight = GetNode<RayCast2D>("RcBottomRight");
		rcLeft = GetNode<RayCast2D>("RcLeft");
		rcRight = GetNode<RayCast2D>("RcRight");
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CalculateDirection();

		//this is the displacement of the enemy multiplied by delta and dirction
		float distanceX = speed * (float)delta * direction;
		float newPosionX = Position.X + distanceX;
		Vector2 newPosition = new(newPosionX, Position.Y);
		Position = newPosition;
	}

	private void CalculateDirection(){
		bool leftCheck = !rcBottomLeft.IsColliding() || rcLeft.IsColliding();
		bool rightCheck = !rcBottomRight.IsColliding() || rcRight.IsColliding();

		if(leftCheck && rightCheck){
			direction = 0;
		} else if (leftCheck){
			direction = 1;
			sprite.FlipH = false;
		} else if (rightCheck) {
			direction = -1;
			sprite.FlipH = true;
		}
	}
}
