using Godot;
using System;

public partial class wood_barrier : Node2D
{
	private double _timer;
	private Label _label;

	private AudioStreamPlayer2D _breakSound;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_label = this.GetNode<Label>("demolition/warning");
		_breakSound = this.GetNode<AudioStreamPlayer2D>("break");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!_label.Visible)
		{
			return;
		}

		_timer += delta;
		if (_timer > 3)
		{
			_label.Visible = false;
			_timer = 0;
		}
	}

	private void _on_demolition_body_entered(Node2D body)
	{
		var boxsprite = this.GetNode<AnimatedSprite2D>("boxsprite");
		if (boxsprite.Animation == "broken")
		{
			return;
		}

		if (!GameManager.Singleton.CheckIfItemInInventory("acid"))
		{
			_label.Visible = true;
			return;
		}

		GameManager.Singleton.RemoveFromInventory("acid");
		boxsprite.Animation = "broken";
		_breakSound.Play();

		this.GetNode<CollisionShape2D>("demolition/interaction").CallDeferred("set_disabled", true);
		this.GetNode<CollisionShape2D>("StaticBody2D/block").CallDeferred("set_disabled", true);
	}
}
