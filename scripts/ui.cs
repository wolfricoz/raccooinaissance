using Godot;
using System;

public partial class ui : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// this.Show();
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_start_button_pressed()
	{

		// this.Hide();
		GD.Print("Start Button Pressed");
		GameManager.Singleton.LoadLevel();
	}
}
