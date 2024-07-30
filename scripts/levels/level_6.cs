using Godot;
using System;

public partial class level_6 : Node2D
{
	private int _levelNumber = 6;
	private CustomSignals _customSignals;
	private PathFollow2D _right;
	private PathFollow2D _left;
	private float _speed = GameManager.Singleton.CarSpeed;
	private float _rotate = 30f;


	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		GD.Print("Level One Ready");
		_right = GetNode<PathFollow2D>("right/PathFollow2D");
		_left = GetNode<PathFollow2D>("left/PathFollow2D");
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		FollowPath(_left, _speed, delta);
		FollowPath(_right, _speed, delta);
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
