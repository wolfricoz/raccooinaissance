using Godot;
using System;

public partial class level_7 : Node2D
{
	private int _levelNumber = 7;
	private CustomSignals _customSignals;
	private PathFollow2D _human;
	private PathFollow2D _slowHuman;
	private PathFollow2D _car;
	private float _speed = 0.5f;
	private float _rotate = 50f;


	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		GD.Print("Level One Ready");
		_human = GetNode<PathFollow2D>("human/PathFollow2D");
		_slowHuman = GetNode<PathFollow2D>("humanslow/PathFollow2D");
		_car = GetNode<PathFollow2D>("car/PathFollow2D");
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		FollowPath(_human, 0.1f, delta);
		FollowPath(_slowHuman, 0.05f, delta);
		FollowPath(_car, _speed, delta);
	}

	private void RotateHuman(CharacterBody2D human, double delta, int min, int max)
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

	private void _on_world_borders_body_entered(Node2D body)
	{
		if (body is not player)
		{
			return;
		}

		// GameManager.Singleton.LoadLevel();
		GD.Print("Border touched");
	}
}
