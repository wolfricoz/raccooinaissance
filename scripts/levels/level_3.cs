using Godot;
using System;


public partial class level_3 : Node2D
{
	private int _levelNumber = 3;
	private CustomSignals _customSignals;
	private CharacterBody2D _human1;
	private float _speed = GameManager.Singleton.HumanSpeed;
	private float _rotate = 30f;


	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_human1 = GetNode<CharacterBody2D>("human_1");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		GD.Print("Level One Ready");
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		FollowPath(GetNode<PathFollow2D>("Path2D/PathFollow2D"), delta);
		RotateHuman(delta);
	}

	private void RotateHuman(double delta)
	{
		_human1.RotationDegrees += _rotate * (float)delta;
		if (_human1.RotationDegrees >= 240)
		{
			_rotate = -30;
		}

		if (_human1.RotationDegrees <= 90)
		{
			_rotate = 30;
		}
	}

	private void FollowPath(PathFollow2D path, double delta)
	{
		path.ProgressRatio += _speed * (float)delta;
	}
}
