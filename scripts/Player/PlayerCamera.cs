using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
    private Node2D parentNode;
    public override void _Ready()
    {
        parentNode = GetParent() as Node2D;
        if (parentNode == null)  // Make sure the parent node exists
        {
            GD.PushError("The node with the PlayerFollow script must have a parent node");
        }
    }
    public override void _PhysicsProcess(double delta)
	{
        Vector2 position = GlobalPosition;
        Vector2 parentPosition = parentNode.GlobalPosition;
	}

}
