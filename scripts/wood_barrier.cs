using Godot;
using System;

public partial class wood_barrier : Node2D
{
	private double _timer;
	private Label _label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_label == null)
		{
			return;
		}
		_timer += delta;
		if (_timer > 3)
		{
			this.RemoveChild(_label);
			_label = null;
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
			_label = new Label();
			_label.Text = "You need acid to break this barrier";
			_label.Size = new Vector2(200, 50);
			this.AddChild(_label);
			GD.Print("No acid in inventory");
			return;
		}

		GameManager.Singleton.RemoveFromInventory("acid");
		boxsprite.Animation = "broken";
		this.GetNode<CollisionShape2D>("demolition/interaction").Disabled = true;
		this.GetNode<CollisionShape2D>("StaticBody2D/block").Disabled = true;
		this.RemoveChild(this.GetNode("StaticBody2D"));
		this.RemoveChild(this.GetNode("demolition"));
	}
}
