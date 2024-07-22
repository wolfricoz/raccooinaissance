using Godot;
using System;

public partial class vent : Node2D
{
	private Sprite2D _ventSprite;
	private bool _inVent = false;

	private void _on_area_2d_body_entered(Node2D body)
	{
		_ventSprite = this.GetNode<Sprite2D>("ventsprite");
		GameManager.Singleton.IsHidden = true;
		_ventSprite.Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, 0.5f);
		_inVent = true;
	}


	private void _on_area_2d_body_exited(Node2D body)
	{
		// Replace with function body.
		if (!_inVent){
			return;
		}
		_ventSprite = this.GetNode<Sprite2D>("ventsprite");
		GameManager.Singleton.IsHidden = false;
		_ventSprite.Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, 1);
		_inVent = false;
	}
}
