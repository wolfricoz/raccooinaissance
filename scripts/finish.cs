using Godot;
using System;

public partial class finish : Node2D
{
	private Label _label;
	private AudioStreamPlayer2D _victorySound;

	public override void _Ready()
	{
		_label = GetNode<Label>("Label");
		_victorySound = GetNode<AudioStreamPlayer2D>("victorysound");
		_label.Visible = false;
	}

	public override void _Process(double delta)
	{
	}

	private void _on_plate_of_cookies_body_entered(Node2D body)
	{
		GD.Print("Cookies Eaten");
		GameManager.Singleton.IsHidden = true;
		_label.Visible = true;
		_victorySound.Play();
	}

	private void _on_victorysound_finished()
	{
		GameManager.Singleton.LoadNextLevel();
	}
}
