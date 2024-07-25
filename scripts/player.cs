using Godot;
using Vector2 = Godot.Vector2;

public partial class player : CharacterBody2D
{
	public const float BaseSpeed = 50.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	//public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready()
	{
	}


	public override void _PhysicsProcess(double delta)
	{
		var animatedSprite = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		Vector2 velocity = Velocity;

		// Add the gravity.
		//if (!IsOnFloor())
		//velocity.Y += gravity * (float)delta;
		var speed = BaseSpeed;
		// Handle Jump.


		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		if (Input.IsActionPressed("Run"))
		{
			speed = BaseSpeed * 3;
		}
		else
		{
			speed = BaseSpeed;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("Move_left", "Move_right", "Move_up", "Move_down");
		if (direction != Vector2.Zero)
		{
			velocity.Y = direction.Y * speed;
			velocity.X = direction.X * speed;
			// velocity.Y = direction.Y * Speed;
			this.Rotation = velocity.Angle();
			animatedSprite.Play("Move");
		}

		else
		{
			// If the player is not pressing any keys, decelerate the player or they might slide forever
			velocity.X = Mathf.MoveToward(Velocity.X, 0, speed);
			velocity.Y = Mathf.MoveToward(Velocity.X, 0, speed);
			animatedSprite.Play("Idle");
		}

		Velocity = velocity;
		MoveAndSlide();
	}




}
