using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;


public partial class inventory : CanvasLayer
{
	private AudioStreamPlayer2D _craftingSound;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Inventory Ready");
		_craftingSound = GetNode<AudioStreamPlayer2D>("CraftingSound");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		OnInventoryButtonPressed();
		if (GameManager.Singleton.IsInventoryOpen != this.Visible)
		{
			GD.Print("Inventory State Changed");
			this.Visible = GameManager.Singleton.IsInventoryOpen;
			GetTree().Paused = GameManager.Singleton.IsInventoryOpen;
		}
	}

	public void OnInventoryButtonPressed()
	{
		if (Input.IsActionJustPressed("inventory"))
		{
			GameManager.Singleton.IsInventoryOpen = !GameManager.Singleton.IsInventoryOpen;
		}
	}

	private void _on_visibility_changed()
	{
		if (!this.Visible)
		{
			DeleteChildren();
			return;
		}

		UpdateInventory();
	}

	private void UpdateInventory()
	{
		GD.Print(GameManager.Singleton.Inventory);
		DeleteChildren();
		var craftacid = this.GetNode<Button>("GridContainer2/acidbutton");
		var crafttranquilizer = this.GetNode<Button>("GridContainer2/TranquilizerButton");

		Theme theme = new Theme();
		StyleBoxFlat disabledbutton = new StyleBoxFlat();
		disabledbutton.BgColor = new Color(0.5f, 0.5f, 0.5f); // Grey color
		StyleBoxFlat enabledbutton = new StyleBoxFlat();
		enabledbutton.BgColor = new Color(0, 1, 0); // green color

		theme.SetStylebox("panel", "CanvasLayer", disabledbutton);
		craftacid.Disabled = true;
		craftacid.Theme = theme;
		crafttranquilizer.Disabled = true;
		crafttranquilizer.Theme = theme;
		foreach (KeyValuePair<string, int> item in GameManager.Singleton.Inventory)
		{
			var label = new Label();
			label.Name = item.Key;
			label.Text = item.Key + ": " + item.Value;
			this.GetNode<GridContainer>("GridContainer").AddChild(label);
		}

		if (GameManager.Singleton.Inventory.ContainsKey("acid a") &&
			GameManager.Singleton.Inventory.ContainsKey("acid b"))
		{
			craftacid.Disabled = false;

			theme.SetStylebox("panel", "CanvasLayer", enabledbutton);
			craftacid.Theme = theme;
		}

		if (GameManager.Singleton.Inventory.ContainsKey("diazepam") &&
			GameManager.Singleton.Inventory.ContainsKey("saline"))
		{
			crafttranquilizer.Disabled = false;
			theme.SetStylebox("panel", "CanvasLayer", enabledbutton);
			crafttranquilizer.Theme = theme;
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
		GameManager.Singleton.IsInventoryOpen = false;
	}

	private void _on_acidbutton_pressed()
	{
		if (GameManager.Singleton.Inventory.ContainsKey("acid a") &&
			GameManager.Singleton.Inventory.ContainsKey("acid b"))
		{
			GameManager.Singleton.RemoveFromInventory("acid a");
			GameManager.Singleton.RemoveFromInventory("acid b");
			GameManager.Singleton.AddToInventory("acid");
			_craftingSound.Play();
			UpdateInventory();
		}
	}

	private void _on_tranquilizer_button_pressed()
	{
		if (GameManager.Singleton.Inventory.ContainsKey("diazepam") &&
			GameManager.Singleton.Inventory.ContainsKey("saline"))
		{
			GameManager.Singleton.RemoveFromInventory("Diazepam");
			GameManager.Singleton.RemoveFromInventory("Saline");
			GameManager.Singleton.AddToInventory("Tranquilizer");
			_craftingSound.Play();
			UpdateInventory();
		}
	}
}
