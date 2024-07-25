using Godot;

namespace Raccoonnaissance.scenes;

public partial class pause_sceen : CanvasLayer
{
	private HSlider _volumeSlider;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_volumeSlider = GetNode<HSlider>("settings/GridContainer/VolumeSlider");
		_volumeSlider.Value = 0;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		OnPauseMenuButtonPressed();

		if (GameManager.Singleton.IsPaused != this.Visible)
		{
			GD.Print("Pause State Changed");
			this.Visible = GameManager.Singleton.IsPaused;
			GetTree().Paused = GameManager.Singleton.IsPaused;
		}
	}

	public void OnPauseMenuButtonPressed()
	{
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
	}

	private void _on_resume_button_pressed()
	{
		GetTree().Paused = false;
		GameManager.Singleton.IsPaused = false;
		GD.Print("Resume button pressed");
		this.Hide();
	}

	private void _on_main_menu_pressed()
	{
		GameManager.Singleton.ChangeScene("res://start_screen.tscn");
	}


	private void _on_quit_pressed()
	{
		GetTree().Quit();
	}


	private void _on_h_slider_value_changed(float value)
	{
		if ((int)value == -40)
		{
			// turn off main bus
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), true);
			return;
		}
		// turn on main bus
		AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), false);
		// Change the volume, the value is in decibels and 0 is the default, any higher
		// than 10 will HURT your ears.. ouch.
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), value);
	}
}
