using Godot;
using System;

public partial class finish : Node2D
{

	public override void _Ready()
	{

	}

	public override void _Process(double delta)
	{

	}
	private void _on_plate_of_cookies_body_entered(Node2D body)
	{
		GD.Print("Cookies Eaten");
		GameManager.Singleton.LoadNextLevel();
	}
}





