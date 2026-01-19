using Godot;
using System;

namespace GA.GitWorkshop
{
	/// <summary>
	/// A class to manipulate the icon.
	/// </summary>
	public partial class Icon : Sprite2D
	{
		/// <summary>
		/// Introduce yourself!
		/// </summary>
		public override void _Ready()
		{
			GD.Print("I'm an icon, yay!");
		}
	}
}