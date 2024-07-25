using Godot;
using System;

public partial class level_1 : Node2D
{
	private int _levelNumber = 1;
	private CustomSignals _customSignals;

	private float _speed = 0.05f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		var dumpster = this.GetNode("dumpster");
		var dumpster2 = this.GetNode("dumpster2");
		GD.Print(dumpster);
		GD.Print(dumpster.IsInsideTree());
		GameManager.Singleton.AddToInventory("acid");
		GameManager.Singleton.StartPosition = this.GetNode<Node2D>("start").GlobalPosition;
		GD.Print("Level One Ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var path = GetNode<PathFollow2D>("Path2D/PathFollow2D");
		path.ProgressRatio += _speed * (float)delta;

	}




}
