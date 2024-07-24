using Godot;
using System;

public partial class level_one : Node2D
{
	private CustomSignals _customSignals;

	private float _speed = 0.05f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		var dumpster = this.GetNode("dumpster");
		var dumpster2 = this.GetNode("dumpster2");
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "acid a", dumpster.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "bomb", dumpster.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "acid b", dumpster2.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "knife", dumpster2.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "acid", dumpster2.Name);
		GameManager.Singleton.StartPosition = this.GetNode<Node2D>("start").GlobalPosition;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var path = GetNode<PathFollow2D>("Path2D/PathFollow2D");
		path.ProgressRatio += _speed * (float)delta;
	}


}
