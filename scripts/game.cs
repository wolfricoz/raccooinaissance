using Godot;
using System;

public partial class game : Node2D
{
	public CanvasLayer PauseMenu;
	public CanvasLayer InventoryMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Input.MouseMode = Input.MouseModeEnum.Hidden;
		GetTree().Paused = false;
		PauseMenu = GetNode<CanvasLayer>("ui/PauseSceen");
		InventoryMenu = GetNode<CanvasLayer>("ui/inventory");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("inventory"))
		{
			GameManager.Singleton.IsInventoryOpen = !GameManager.Singleton.IsInventoryOpen;
		}

		if (Input.IsActionJustPressed("Pause"))
		{
			if (GameManager.Singleton.IsInventoryOpen)
			{
				GD.Print("Closing Inventory");
				GameManager.Singleton.IsInventoryOpen = false;
				return;
			}

			GD.Print("Pause button pressed " + GameManager.Singleton.IsPaused);
			GameManager.Singleton.IsPaused = !GameManager.Singleton.IsPaused;
		}
		if (GameManager.Singleton.IsInventoryOpen != InventoryMenu.Visible)
		{
			GD.Print("Inventory State Changed");
			InventoryMenu.Visible = GameManager.Singleton.IsInventoryOpen;
			// GetTree().Paused = GameManager.Singleton.IsInventoryOpen;
		}


		if (GameManager.Singleton.IsPaused != PauseMenu.Visible)
		{
			GD.Print("Pause State Changed");
			PauseMenu.Visible = GameManager.Singleton.IsPaused;
			GetTree().Paused = GameManager.Singleton.IsPaused;
		}
	}
}
