using Godot;
using System;

public partial class level_9 : CanvasLayer
{

		
	private void _on_main_menu_pressed()
	{
		GameManager.Singleton.ChangeScene("res://start_screen.tscn");
	}


	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}
}


