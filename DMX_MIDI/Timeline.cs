using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMX_MIDI
{
	public class Timeline
	{
		public class Frame
		{

		}

		private Point currentLocation;
		public Point CurrentLocation
		{
			get { return currentLocation; }
			set
			{
				currentLocation = value;
				this.CurrentFrame = (int)(Frames.Length * ((float)value.X / (float)this.LineWidth));
			}
		}
		public int CurrentFrame { get; set; }
		public Frame[] Frames { get; set; }

		Point StartPoint { get; set; }
		int LineWidth { get; set; }
		public Timeline(Point _startPoint, int _lineWidth)
		{
			this.StartPoint = _startPoint;
			this.LineWidth = _lineWidth;

			int nbrOfFrames = _lineWidth / 10; // 10px par frame
			this.Frames = new Frame[nbrOfFrames];
			this.CurrentLocation = this.StartPoint;
		}

		public Point ConstrainCurrentFrame(Point desiredLocation)
		{
			if (desiredLocation.X < this.StartPoint.X)
				desiredLocation.X = this.StartPoint.X;
			if (desiredLocation.X > (this.StartPoint.X + this.LineWidth))
				desiredLocation.X = (this.StartPoint.X + this.LineWidth);
			return desiredLocation;
		}
	}
}
