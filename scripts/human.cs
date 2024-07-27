using Godot;
using System;
using System.Collections.Generic;

public partial class human : CharacterBody2D
{
	private player _player;
	private CustomSignals _customSignals;

	private HashSet<Node2D> _bodiesInside = new HashSet<Node2D>();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Human preparing");
		GD.Print("Human Ready: " + this.Name);
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_player != null && _bodiesInside.Contains(_player) && !GameManager.Singleton.IsHidden)
		{
			SightCheck();
		}
	}

	private void _on_vision_body_entered(Node2D body)
	{
		if (body is player && !GameManager.Singleton.IsHidden)
		{
			_player = (player)body;
			SightCheck();
		}

		_bodiesInside.Add(body);
	}

	private void _on_vision_body_exited(Node2D body)
	{
		_bodiesInside.Remove(body);
	}

	private void SightCheck()
	{
		var spaceState = GetWorld2D().DirectSpaceState;
		var query = PhysicsRayQueryParameters2D.Create(this.GlobalPosition, _player.GlobalPosition, 1,
			new Godot.Collections.Array<Rid> { GetRid() });
		var sightcheck = spaceState.IntersectRay(query);
		var collider = (Node2D)sightcheck["collider"];
		if (collider.Name == _player.Name)
		{
			GD.Print("Player seen");
			GameManager.Singleton.GameOver = true;
		}
		else
		{
			GD.Print("Player not seen, line of sight blocked by: " + collider.Name);
		}
	}
}
