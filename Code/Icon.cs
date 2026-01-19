using Godot;
using System;

namespace GA.GitWorkshop
{
	/// <summary>
	/// A class to manipulate the icon.
	/// </summary>
	public partial class Icon : Sprite2D
	{
		[Export] private float _moveSpeed = 50f;

		/// <summary>
		/// Introduce yourself!
		/// </summary>
		public override void _Ready()
		{
			GD.Print("I'm an icon, yay!");
		}

		/// <summary>
		/// Make the icon look alive.
		/// </summary>
		/// <param name="delta">Time passed since the last frame.</param>
		public override void _Process(double delta)
		{
			Position += new Vector2(_moveSpeed * (float)delta, 0);
		}
	}
}