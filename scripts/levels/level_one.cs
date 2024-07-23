using Godot;
using System;

public partial class level_one : Node2D
{
	private CustomSignals _customSignals;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		var dumpster = this.GetNode("dumpster");
		var dumpster2 = this.GetNode("dumpster2");
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "trash", dumpster.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "bomb", dumpster.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "trash", dumpster2.Name);
		_customSignals.EmitSignal(nameof(CustomSignals.AddToDumpster), "knife", dumpster2.Name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
