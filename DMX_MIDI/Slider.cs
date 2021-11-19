using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_MIDI
{
	public class Slider
	{
		public enum Color
		{
			R,
			G,
			B
		}

		private Point currentLocation;
		public Point CurrentLocation
		{
			get { return currentLocation; }
			set
			{
				this.currentLocation = value;
				this.CurrentValue = (int)(255 * ((float)value.X / (float)this.LineElement.Size.Width));
			}
		}
		private int currentValue;
		public int CurrentValue
		{
			get { return currentValue; }
			set
			{
				this.currentValue = value;
				this.currentLocation = new Point((int)((float)value * (float)this.LineElement.Size.Width) / 255, this.currentLocation.Y);

				this.SliderElement.Location = new Point(this.LineElement.Location.X + this.CurrentLocation.X, this.SliderElement.Location.Y);
				this.SliderElement.Visible = true;
				switch(this.GetColor)
				{
					case Color.R:
						this.LineElement.BackColor = System.Drawing.Color.FromArgb(this.CurrentValue, 0, 0);
						break;
					case Color.G:
						this.LineElement.BackColor = System.Drawing.Color.FromArgb(0, this.CurrentValue, 0);
						break;
					case Color.B:
						this.LineElement.BackColor = System.Drawing.Color.FromArgb(0, 0, this.CurrentValue);
						break;
				}
			}
		}

		private Color GetColor { get; set; }
		Label SliderElement { get; set; }
		Label LineElement { get; set; }

		private Point StartPoint { get; set; }
		private int LineWidth { get; set; }
		public Slider(Color color, Label slider, Label line)
		{
			this.GetColor = color;
			this.SliderElement = slider;
			this.LineElement = line;

			this.CurrentLocation = new Point(0, line.Location.Y);
		}

		public Point ConstrainLocation(Point desiredLocation)
		{
			if (desiredLocation.X < this.StartPoint.X)
				desiredLocation.X = this.StartPoint.X;
			if (desiredLocation.X > (this.StartPoint.X + this.LineWidth))
				desiredLocation.X = (this.StartPoint.X + this.LineWidth);
			return desiredLocation;
		}
	}
}
