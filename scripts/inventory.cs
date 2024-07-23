using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;


public partial class inventory : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Inventory Ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	private void _on_visibility_changed()
	{
		if (!this.Visible)
		{
			DeleteChildren();
			return;
		}
		updateInventory();
	}

	private void updateInventory()
	{
		DeleteChildren();
		foreach (KeyValuePair<string, int> item in GameManager.Singleton.Inventory)
		{
			var label = new Label();
			label.Name = item.Key;
			label.Text = item.Key + ": " + item.Value;
			this.GetNode<GridContainer>("GridContainer").AddChild(label);
		}
	}

	private void DeleteChildren()
	{
		foreach (Node child in this.GetNode<GridContainer>("GridContainer").GetChildren())
		{
			this.GetNode<GridContainer>("GridContainer").RemoveChild(child);
		}
	}
	
private void _on_button_pressed()
{
	// Replace with function body.
}
}


