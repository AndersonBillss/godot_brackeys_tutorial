using Godot;
using System;

public partial class Killzone : Area2D
{
    public Timer respawnTimer;

    public override void _Ready()
    {
        respawnTimer = GetNode<Timer>("Timer");
        if(respawnTimer == null){
            GD.PushError("The killzone must have a timer!");
        }
    }


    public void OnBodyEntered(CollisionObject2D body){
        GD.Print("You Died");
        Engine.TimeScale = .5f;
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        respawnTimer.Start();
    }

    public void OnTimerTimeout(){
        Engine.TimeScale = 1f;
        GetTree().ReloadCurrentScene();
    }
}
