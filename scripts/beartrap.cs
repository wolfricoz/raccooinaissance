using Godot;
using System;

public partial class beartrap : Node2D
{
	private void _on_area_2d_body_entered(Node2D body)
	{
		GameManager.Singleton.GameOver = true;
	}
}



