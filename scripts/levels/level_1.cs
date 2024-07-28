using Godot;

namespace Raccoonnaissance.scripts.levels;

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
		GD.Print("Level One Ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}




}
