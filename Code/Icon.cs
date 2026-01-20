using Godot;
using System;

namespace GA.GitWorkshop
{
	/// <summary>
	/// A class to manipulate the icon.
	/// </summary>
	public partial class Icon : Sprite2D
	{
		// The rotation speed of the icon. Degrees per second.
		[Export] private float _rotationSpeed = 45f;

		/// <summary>
		/// Introduce yourself!
		/// </summary>
		public override void _Ready()
		{
			GD.Print("I'm an icon, yay!");
		}

		/// <summary>
		/// Functionality for the icon. Make it lively!
		/// </summary>
		/// <param name="delta"></param>
		override public void _Process(double delta)
		{
			RotationDegrees += _rotationSpeed * (float)delta;
		}
	}
}