using Godot;

namespace Raccoonnaissance.scripts.levels;

public partial class level_2 : Node2D
{
	private int _levelNumber = 2;
	private CustomSignals _customSignals;
	private CharacterBody2D _human1;
	private float _speed = GameManager.Singleton.HumanSpeed;
	private float _rotate = 30f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_human1 = GetNode<CharacterBody2D>("human_1");
		GD.Print("Level One Loading");
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
		if (_human1.RotationDegrees >= 160)
		{
			_rotate = -30;
		}

		if (_human1.RotationDegrees <= 20)
		{
			_rotate = 30;
		}
	}

	private void FollowPath(PathFollow2D path, double delta)
	{
		path.ProgressRatio += _speed * (float)delta;
	}
}
