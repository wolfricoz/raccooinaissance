using Godot;
using System;

public partial class game : Node2D
{
	public CanvasLayer PauseMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Input.MouseMode = Input.MouseModeEnum.Hidden;
		GetTree().Paused = false;
		PauseMenu = GetNode<CanvasLayer>("ui/PauseSceen");
		PauseMenu.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Pause"))
		{

			GD.Print("Pause button pressed " + GameManager.Singleton.IsPaused);
			if (GameManager.Singleton.IsPaused)
			{
				GameManager.Singleton.IsPaused = false;
				PauseMenu.Hide();
				GD.Print("Unpausing");
				Input.MouseMode = Input.MouseModeEnum.Hidden;
				// GetTree().Paused = false;
			}
			else
			{
				GameManager.Singleton.IsPaused = true;
				PauseMenu.Show();
				GD.Print("Pausing");
				Input.MouseMode = Input.MouseModeEnum.Visible;
				// GetTree().Paused = true;
			}
		}
	}
}
