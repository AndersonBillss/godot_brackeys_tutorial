using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float JumpVelocity = -350.0f;
	private AnimatedSprite2D sprite;
	
	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}
		if (Input.IsActionJustReleased("jump") && Velocity.Y < 0)
		{
			velocity.Y *= (float).25;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 direction = Input.GetVector("move_left", "move_right","_","_");
		Vector2 direction = Input.GetVector("move_left", "move_right","move_right","move_right");

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		if (velocity.X > 0){
			sprite.FlipH = false;
		}
		if (velocity.X < 0){
			sprite.FlipH = true;
		}

		// Handle animations
		if(IsOnFloor()){	
			if(velocity.X == 0){
				sprite.Play("idle");
			} else {
				sprite.Play("run");
			}
		} else {
			sprite.Play("jump");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
