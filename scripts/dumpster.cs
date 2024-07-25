using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class dumpster : Node2D
{
	public bool IsLooted;
	private double _time;
	private List<string> _inventory = new List<string>();
	private CustomSignals _customSignals;

	private Label _label;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_customSignals = GetNode<CustomSignals>("/root/CustomSignals");

		if (this.HasMeta("inventory"))
		{
			LoadInventory();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!IsLooted || _label == null)
		{
			return;
		}

		_time += 1 * delta;
		if (_time > 5)
		{
			this.RemoveChild(_label);
			_label = null;
			_time = 0;
			GD.Print("Label removed");
		}
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

		GD.Print("Looting");
		foreach (string item in _inventory)
		{
			if (GameManager.Singleton.Inventory.ContainsKey(item))
			{
				GameManager.Singleton.Inventory[item] += 1;
			}
			else
			{
				GameManager.Singleton.Inventory.Add(item, 1);
			}
		}

		IsLooted = true;
		GD.Print(GameManager.Singleton.Inventory);
		_label = new Label();
		_label.Text = "You found: " + string.Join(", ", _inventory);
		_label.Rotation = -this.Rotation;
		this.AddChild(_label);
	}

	private void _on_area_2d_body_exited(Node2D body)
	{
		GameManager.Singleton.IsHidden = false;
	}

	// public void AddToDumpsterInventory(string item, string name)
	// {
	// 	if (this.Name != name)
	// 	{
	// 		return;
	// 	}
	//
	// 	_inventory.Add(item.ToLower());
	// }

	public void LoadInventory()
	{
		var meta = (string)this.GetMeta("inventory");
		_inventory = meta.Split(", ").ToList();
	}
}
