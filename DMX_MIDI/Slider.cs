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
			None,
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
				this.currentValue = (int)(this.maxValue * ((float)value.X / (float)(this.LineElement.Width - this.SliderElement.Width)));
				Update();
			}
		}
		private int currentValue;
		public int CurrentValue
		{
			get { return currentValue; }
			set
			{
				this.currentValue = value;
				Update();
			}
		}

		private int maxValue;
		public int MaxValue
        {
			get { return maxValue; }
			set
			{
				this.maxValue = value;
				Update();
			}
        }

		private Color GetColor { get; set; }
		Label SliderElement { get; set; }
		Label LineElement { get; set; }
		public Slider(Label slider, Label line, int maxValue, Color color = Color.None)
		{
			this.SliderElement = slider;
			this.LineElement = line;
			this.maxValue = maxValue;
			this.GetColor = color;

			this.currentValue = 0;
			Update();
		}

		public Point ConstrainLocation(Point desiredLocation)
		{
			if (desiredLocation.X < this.LineElement.Location.X)
				desiredLocation.X = this.LineElement.Location.X;
			if (desiredLocation.X > (this.LineElement.Location.X + this.LineElement.Width - this.SliderElement.Width))
				desiredLocation.X = (this.LineElement.Location.X + this.LineElement.Width - this.SliderElement.Width);
			return desiredLocation;
		}

		public void Update()
        {
			if (this.SliderElement != null)
			{
				this.currentLocation = new Point((int)((float)this.currentValue * (float)(this.LineElement.Width - this.SliderElement.Width)) / this.maxValue, this.currentLocation.Y);
				this.SliderElement.Location = new Point(this.LineElement.Location.X + this.currentLocation.X, this.SliderElement.Location.Y);
				this.SliderElement.Visible = true;
				switch (this.GetColor)
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
					default:
						this.LineElement.BackColor = System.Drawing.Color.Black;
						break;
				}
			}
        }
	}
}
