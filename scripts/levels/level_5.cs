using Godot;
using System;

public partial class level_5 : Node2D
{
	private int _levelNumber = 3;
	private CustomSignals _customSignals;
	private CharacterBody2D _human;
	private PathFollow2D _bigpath;
	private PathFollow2D _smallpath;
	private float _speed = 0.03f;
	private float _rotate = 50f;


	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		GD.Print("Level One Ready");
		_human = GetNode<CharacterBody2D>("Human_3");
		_bigpath = GetNode<PathFollow2D>("bigroompath/PathFollow2D");
		_smallpath = GetNode<PathFollow2D>("smallpath/PathFollow2D");
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		FollowPath(_bigpath, _speed, delta);
		FollowPath(_smallpath, _speed, delta);
		RotateHuman(_human, delta, 120, 280);
	}

	private void RotateHuman(CharacterBody2D human,double delta, int min, int max)
	{
		// This code is currently fucked. Probably because human isn't being found
		human.RotationDegrees += _rotate * (float)delta;
		if (human.RotationDegrees >= max)
		{
			_rotate = -30;
		}

		if (human.RotationDegrees <= min)
		{
			_rotate = 30;
		}
	}

	private void FollowPath(PathFollow2D path, float speed, double delta)
	{
		path.ProgressRatio += speed * (float)delta;
	}
}
