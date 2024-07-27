using Godot;

namespace Raccoonnaissance.scripts.levels;

public partial class level_2 : Node2D
{
	private int _levelNumber = 2;
	private CustomSignals _customSignals;
	private CharacterBody2D _human1;
	private float _speed = 0.05f;
	private float _rotate = 25f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_human1 = GetNode<CharacterBody2D>("human_1");
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		var dumpster = this.GetNode("dumpster");
		var dumpster2 = this.GetNode("dumpster2");
		GD.Print(dumpster);
		GD.Print(dumpster.IsInsideTree());
		GameManager.Singleton.StartPosition = this.GetNode<Node2D>("start").GlobalPosition;
		GD.Print("Level One Ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var path = GetNode<PathFollow2D>("Path2D/PathFollow2D");
		path.ProgressRatio += _speed * (float)delta;


		_human1.RotationDegrees += _rotate * (float) delta;
		if (_human1.RotationDegrees >= 160)
			{
			_rotate = -25;
			}
		if (_human1.RotationDegrees <= 20)
			{
			_rotate = 25;
			}
	}

	private void RotateHuman()
	{
		_human1.RotationDegrees += 1;
	}



}
