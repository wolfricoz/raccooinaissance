using Godot;
using System;

public partial class CustomSignals : Node
{

	[Signal]
	public delegate void AddToDumpsterEventHandler(string item, string name);
	// Called when the node enters the scene tree for the first time.

	[Signal]
	public delegate void TestEventHandler(string item);
}
