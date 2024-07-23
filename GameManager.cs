using Godot;
using System;
using Godot.Collections;


public partial class GameManager : Node2D
{
	public static GameManager Singleton { get; private set; }
	public string PreviousScene = "";
	public bool IsPaused;
	public bool IsInventoryOpen = false;
	public string CurrentScene = "res://scenes/ui.tscn";
	public PackedScene GameScene = GD.Load<PackedScene>("res://game.tscn");
	public Dictionary<string, int> Inventory = new Dictionary<string, int>();
	public bool IsHidden;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		if (Singleton != null)
		{
			QueueFree();
			return;
		}

		Singleton = this;


		GD.Print("GameManager Ready");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


	public void ChangeScene(string scene, bool savePrevious = true)
	{
		if (savePrevious)
		{
			GD.Print("Saving previous scene: " + CurrentScene);
			PreviousScene = CurrentScene;
		}

		CurrentScene = scene;
		GD.Print("Changing to scene: " + CurrentScene);
		this.GetTree().ChangeSceneToFile(CurrentScene);
	}

	public void ChangePreviousScene()
	{
		var temporaryOld = CurrentScene;
		CurrentScene = PreviousScene;
		GD.Print("Changing to previous scene: " + PreviousScene);
		this.GetTree().ChangeSceneToFile(PreviousScene);
		PreviousScene = temporaryOld;
	}
}
