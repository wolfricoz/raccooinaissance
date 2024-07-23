using Godot;
using System;

public partial class overlay : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_inventory_button_mouse_entered()
	{
		this.GetNode<Sprite2D>("inventoryButton/closed").Hide();
		this.GetNode<Sprite2D>("inventoryButton/open").Show();
		this.GetNode<Label>("Label").Show();
	}


	private void _on_inventory_button_mouse_exited()
	{
		this.GetNode<Sprite2D>("inventoryButton/open").Hide();
		this.GetNode<Sprite2D>("inventoryButton/closed").Show();
		this.GetNode<Label>("Label").Hide();
	}

	private void _on_inventory_button_pressed()
	{
	GameManager.Singleton.IsInventoryOpen = !GameManager.Singleton.IsInventoryOpen;
	}


	private void _on_pausebutton_mouse_entered()
	{
	//change color to white
		 this.GetNode<Sprite2D>("pausebutton/Pause").Modulate = new Color(1,1,1);
	}


	private void _on_pausebutton_mouse_exited()
	{
		// Replace with function body.
		this.GetNode<Sprite2D>("pausebutton/Pause").Modulate = new Color(0,0,0);
	}


	private void _on_pausebutton_pressed()
	{
		GameManager.Singleton.IsPaused = true;
	}
}
