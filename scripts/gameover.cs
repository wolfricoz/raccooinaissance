using Godot;
using System;

public partial class gameover : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_retry_pressed()
	{
		GameManager.Singleton.ChangeScene("res://scenes/levels/level_" + GameManager.Singleton.CurrentLevel.ToString() + ".tscn");
	}


	private void _on_menu_pressed()
	{
		GameManager.Singleton.ChangeScene("res://start_screen.tscn");
	}


	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}
