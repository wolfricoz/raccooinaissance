using Godot;
using System;

public partial class ui : CanvasLayer
{
	private Node2D _levelSelect;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// this.Show();
		Input.MouseMode = Input.MouseModeEnum.Visible;
		_levelSelect = GetNode<Node2D>("LevelSelectNode");
		_levelSelect.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_start_button_pressed()
	{
		// this.Hide();
		GD.Print("Start Button Pressed");
		GameManager.Singleton.LoadLevel(1);
	}


	private void _on_levelselect_pressed()
	{
		_levelSelect.Visible = !_levelSelect.Visible;
	}


	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}


	private void _on_button_pressed()
	{
		GameManager.Singleton.LoadLevel(1);
	}


	private void _on_button_2_pressed()
	{
		GameManager.Singleton.LoadLevel(2);
	}


	private void _on_button_3_pressed()
	{
		GameManager.Singleton.LoadLevel(3);
	}


	private void _on_button_4_pressed()
	{
		GameManager.Singleton.LoadLevel(4);
	}


	private void _on_level_5_pressed()
	{
		GameManager.Singleton.LoadLevel(5);
	}


	private void _on_level_6_pressed()
	{
		GameManager.Singleton.LoadLevel(6);
	}


	private void _on_level_7_pressed()
	{
		GameManager.Singleton.LoadLevel(7);
	}


	private void _on_level_8_pressed()
	{
		GameManager.Singleton.LoadLevel(8);
	}

	private void _on_back_pressed()
	{
		_levelSelect.Visible = false;
	}
}
