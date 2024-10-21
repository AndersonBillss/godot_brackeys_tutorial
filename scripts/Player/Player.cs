using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -350.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		if (Input.IsActionJustReleased("ui_accept") && Velocity.Y < 0)
		{
			velocity.Y *= (float).25;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		if (velocity.X > 0){
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
		}
		if (velocity.X < 0){
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	// public bool isCloseToGround(){
		
	// }

}
