using Godot;
using System;

public partial class vent : Node2D
{
    private Sprite2D _ventSprite;
    private bool _inVent;
    private bool _enteredVent;

    public override void _Process(double delta)
    {
        if (_enteredVent)
        {
            GameManager.Singleton.IsHidden = true;
        }

        if (_enteredVent && !_inVent)
        {
            _enteredVent = false;
            GameManager.Singleton.IsHidden = false;
        }
    }


    private void _on_area_2d_body_entered(Node2D body)
    {
        _enteredVent = true;
        _inVent = true;
        _ventSprite = this.GetNode<Sprite2D>("ventsprite");
        _ventSprite.Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, 0.5f);
    }


    private void _on_area_2d_body_exited(Node2D body)
    {
        _inVent = false;
        _ventSprite = this.GetNode<Sprite2D>("ventsprite");
        _ventSprite.Modulate = new Color(Modulate.R, Modulate.G, Modulate.B, 1);
    }
}