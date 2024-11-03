using Godot;
using System;

public partial class GameManager : Node
{
    public int score = 0;
    Label scoreLabel;

    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("ScoreLabel");
    }

    public void AddPoint(){
        score += 1;
        scoreLabel.Text = $"The End!\nYou collected {score} coins!";
    }
}
