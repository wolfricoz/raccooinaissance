using Godot;
using System;

public partial class human : CharacterBody2D
{
	private player _player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Human preparing");
		_player = GetNode<player>("/root/Game/player");
		GD.Print("Human Ready: " + _player.Name);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_vision_body_entered(Node2D body)
	{
		if (body is player && !GameManager.Singleton.IsHidden)
		{

			SightCheck();
		}
	}

	private void SightCheck()
	{
		var spaceState = GetWorld2D().DirectSpaceState;
		var query = PhysicsRayQueryParameters2D.Create(this.GlobalPosition, _player.GlobalPosition, 1,
			new Godot.Collections.Array<Rid> { GetRid() });
		var sightcheck = spaceState.IntersectRay(query);
		var collider = (Node2D) sightcheck["collider"];
		if (collider.Name == _player.Name)
		{
			GD.Print("Player seen");
		}
		else {
			GD.Print("Player not seen, line of sight blocked by: " + collider.Name);
		}
	}
}
