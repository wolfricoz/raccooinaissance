using Godot;
using System;

public partial class dumpster : Node2D
{
	public bool IsLooted = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_area_2d_body_entered(Node2D body)
	{
		this.GetNode<Sprite2D>("closed").Hide();
		this.GetNode<Sprite2D>("open").Show();
		// When the player enters the dumpster, the player is hidden
		GameManager.Singleton.IsHidden = true;
		// The dumpsters inventory is added to the players inventory
		// TODO: show a pop up with the items that were added.
		if (IsLooted)
		{
			return;
		}
		GameManager.Singleton.Inventory.Add("Trash", 1);
		IsLooted = true;
		GD.Print(GameManager.Singleton.Inventory);
	}

	private void _on_area_2d_body_exited(Node2D body)
	{
		GameManager.Singleton.IsHidden = false;
	}
}
