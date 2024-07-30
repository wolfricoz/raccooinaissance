using Godot;
using System.Collections.Generic;

public partial class level_8 : Node2D
{
	private int _levelNumber = 8;
	private CustomSignals _customSignals;
	private PathFollow2D _human;
	private PathFollow2D _human2;
	private PathFollow2D _human3;
	private CharacterBody2D _rotatingHuman;
	private CharacterBody2D _rotatingHuman2;
	private PathFollow2D _car;
	private PathFollow2D _car2;

	private float _carSpeed = GameManager.Singleton.CarSpeed;
	private float _humanSpeed = GameManager.Singleton.HumanSpeed;
	private Dictionary<CharacterBody2D, float> _rotateDict = new Dictionary<CharacterBody2D, float>();

	public override void _Ready()
	{
		GD.Print("Level One Loading");
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
		GD.Print("Level One Ready");
		_human = GetNode<PathFollow2D>("humans/human/PathFollow2D");
		_human2 = GetNode<PathFollow2D>("humans/humanslow/PathFollow2D");
		_human3 = GetNode<PathFollow2D>("humans/insideguard/PathFollow2D");
		_car = GetNode<PathFollow2D>("car/PathFollow2D");
		_car2 = GetNode<PathFollow2D>("car2/PathFollow2D");
		_rotatingHuman = GetNode<CharacterBody2D>("Human");
		_rotatingHuman2 = GetNode<CharacterBody2D>("Human2");

		// Initialize rotation values for each human
		_rotateDict[_rotatingHuman] = 30f;
		_rotateDict[_rotatingHuman2] = 30f;
	}

	public override void _Process(double delta)
	{
		FollowPath(_human, _humanSpeed, delta);
		FollowPath(_human3, _humanSpeed, delta);
		FollowPath(_human2, _humanSpeed, delta);
		FollowPath(_car, _carSpeed, delta);
		FollowPath(_car2, _carSpeed, delta);
		RotateHuman(_rotatingHuman2, delta, -200, -90);
		RotateHuman(_rotatingHuman, delta, -100, 50);
	}

	private void RotateHuman(CharacterBody2D human, double delta, int min, int max)
	{
		if (!_rotateDict.ContainsKey(human))
		{
			return;
		}

		float rotate = _rotateDict[human];
		human.RotationDegrees += rotate * (float)delta;

		if (human.RotationDegrees >= max)
		{
			_rotateDict[human] = -30f;
		}

		if (human.RotationDegrees <= min)
		{
			_rotateDict[human] = 30f;
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

		GD.Print("Border touched");
	}
}
