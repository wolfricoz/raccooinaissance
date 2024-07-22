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
}
