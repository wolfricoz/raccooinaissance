using Godot;

namespace Raccoonnaissance.scenes;

public partial class pause_sceen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_resume_button_pressed()
	{
		GetTree().Paused = false;
		GameManager.Singleton.IsPaused = false;
		GD.Print("Resume button pressed");
		this.Hide();
	}
}
