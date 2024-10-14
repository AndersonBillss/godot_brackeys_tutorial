using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
    private Node2D parentNode;
    private Vector2 prevParentPosition;
    public override void _Ready()
    {
        parentNode = GetParent() as Node2D;
        prevParentPosition = parentNode.GlobalPosition;
        if (parentNode == null)  // Make sure the parent node exists
        {
            GD.PushError("The node with the PlayerFollow script must have a parent node");
        }
    }
    public override void _PhysicsProcess(double delta)
	{
        Vector2 newPosition = Position;
        Vector2 parentPosition = parentNode.GlobalPosition;
        Vector2 parentVelocity = parentPosition - prevParentPosition;
        prevParentPosition = parentPosition;

        newPosition-=parentVelocity;
        newPosition/=(float)1.1;

        Position = newPosition;
	}

}
