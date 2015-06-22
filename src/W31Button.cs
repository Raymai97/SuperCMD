using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

class W31Button : Button
{

	#region SuperCMD custom code

	bool beClassic;

	public W31Button()
	{
		beClassic = (SuperCMD.Program.beClassic);
		if (beClassic)
		{
			this.BackColor = Color.FromArgb(195, 199, 203);
			this.ForeColor = Color.Black;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	#endregion

	Pen penBorder = Pens.Black;
	Pen penInnerBorderTopLeft = Pens.White;
	Pen penInnerBorderBottomRight = new Pen(Color.FromArgb(134, 138, 142));
	Pen penBorder2 = new Pen(Color.Black,2);
	Pen penInnerBorderTopLeft2 = new Pen(Color.FromArgb(134, 138, 142));
	Color ParentBgColor = Color.White;
		
	bool mDown, mOver, mPress;
	int maxX, maxY;
	Rectangle contentRect;
	StringFormat sf = new StringFormat();

	public Bitmap toBmp()
	{
		Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
		Graphics g = Graphics.FromImage(bmp);
		if (this.Parent != null)
		{
			g.Clear(this.Parent.BackColor);
		}
		else
		{
			g.Clear(ParentBgColor);
		}
		// Prepare
		maxX = this.ClientSize.Width - 1;
		maxY = this.ClientSize.Height - 1;
		contentRect = new Rectangle(4, 4, maxX - 4 - 3, maxY - 4 - 3);
		contentRect.X += this.Padding.Left;
		contentRect.Y += this.Padding.Top;
		contentRect.Width -= this.Padding.Right;
		contentRect.Height -= this.Padding.Bottom;
		Int32 txtAgnNum = (Int32)Math.Log((Double)this.TextAlign, 2);
		sf.LineAlignment = (StringAlignment)(txtAgnNum / 4);
		sf.Alignment = (StringAlignment)(txtAgnNum % 4);
		sf.HotkeyPrefix = HotkeyPrefix.Show;
		// Fill button color
		g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(1, 1, maxX - 1, maxY - 1));
		if ((mDown & mOver) | mPress) g.TranslateTransform(1, 1);
		// Draw background image
		if (this.BackgroundImage != null)
		{
			int imgX = 0, imgY = 0;
			switch (this.BackgroundImageLayout)
			{
				case ImageLayout.Center:
					imgX = (int)(contentRect.Width - this.BackgroundImage.Width) / 2;
					imgY = (int)(contentRect.Height - this.BackgroundImage.Height) / 2;
					imgX += contentRect.X;
					imgY += contentRect.Y;
					g.DrawImageUnscaled(this.BackgroundImage, imgX, imgY);
					break;
				case ImageLayout.Stretch:
					g.DrawImage(this.BackgroundImage, contentRect);
					break;
				case ImageLayout.Tile:
					g.FillRectangle(new TextureBrush(this.BackgroundImage, WrapMode.Tile), contentRect);
					break;
				case ImageLayout.Zoom:
					this.BackgroundImageLayout = ImageLayout.Stretch;
					break;
				default: // assume as None
					break;
			}
		}
		// Draw image
		if (this.Image != null)
		{
			int imgX = 0, imgY = 0;
			switch (this.ImageAlign)
			{
				case ContentAlignment.BottomCenter:
					imgX = (int)(contentRect.Width - this.Image.Width) / 2;
					imgY = contentRect.Height - this.Image.Height;
					break;
				case ContentAlignment.BottomLeft:
					imgY = contentRect.Height - this.Image.Height;
					break;
				case ContentAlignment.BottomRight:
					imgX = contentRect.Width - this.Image.Width;
					imgY = contentRect.Height - this.Image.Height;
					break;
				case ContentAlignment.MiddleLeft:
					imgY = (int)(contentRect.Height - this.Image.Height) / 2;
					break;
				case ContentAlignment.MiddleRight:
					imgX = contentRect.Width - this.Image.Width;
					imgY = (int)(contentRect.Height - this.Image.Height) / 2;
					break;
				case ContentAlignment.TopCenter:
					imgX = (int)(contentRect.Width - this.Image.Width) / 2;
					break;
				case ContentAlignment.TopLeft:
					break;
				case ContentAlignment.TopRight:
					imgX = contentRect.Width - this.Image.Width;
					break;
				default: // assume as MiddleCenter
					imgX = (int)(contentRect.Width - this.Image.Width) / 2;
					imgY = (int)(contentRect.Height - this.Image.Height) / 2;
					break;
			}
			imgX += contentRect.X;
			imgY += contentRect.Y;
			g.DrawImageUnscaled(this.Image, imgX, imgY);
		}
		// Draw text
		Brush textBrush = new SolidBrush(this.ForeColor);
		if (!this.Enabled)
		{
			textBrush = new HatchBrush(HatchStyle.Percent50, this.ForeColor, this.BackColor);
		}
		g.DrawString(this.Text, this.Font, textBrush, contentRect, sf);
		g.ResetTransform();
		// Draw border
		if ((mDown & mOver) | mPress)
		{
			// Border (Top, Bottom, Left, Right)
			g.DrawLine(penBorder2, new Point(1, 1), new Point(maxX, 1));
			g.DrawLine(penBorder2, new Point(1, maxY), new Point(maxX, maxY));
			g.DrawLine(penBorder2, new Point(1, 1), new Point(1, maxY));
			g.DrawLine(penBorder2, new Point(maxX, 1), new Point(maxX, maxY));
			// Inner Border (Top)
			g.DrawLine(penInnerBorderTopLeft2, new Point(2, 2), new Point(this.ClientSize.Width - 3, 2));
			// Inner Border (Left)
			g.DrawLine(penInnerBorderTopLeft2, new Point(2, 2), new Point(2, this.ClientSize.Height - 3));
		}
		else if (this.Focused)
		{
			// Border (Top, Bottom, Left, Right)
			g.DrawLine(penBorder2, new Point(1, 1), new Point(maxX, 1));
			g.DrawLine(penBorder2, new Point(1, maxY), new Point(maxX, maxY));
			g.DrawLine(penBorder2, new Point(1, 1), new Point(1, maxY));
			g.DrawLine(penBorder2, new Point(maxX, 1), new Point(maxX, maxY));
			// Inner Border (Top)
			g.DrawLine(penInnerBorderTopLeft, new Point(2, 2), new Point(maxX - 2, 2));
			g.DrawLine(penInnerBorderTopLeft, new Point(2, 3), new Point(maxX - 3, 3));
			// Inner Border (Left)
			g.DrawLine(penInnerBorderTopLeft, new Point(2, 2), new Point(2, maxY - 2));
			g.DrawLine(penInnerBorderTopLeft, new Point(3, 2), new Point(3, maxY - 3));
			// Inner Border (Bottom)
			g.DrawLine(penInnerBorderBottomRight, new Point(3, maxY - 3), new Point(maxX - 3, maxY - 3));
			g.DrawLine(penInnerBorderBottomRight, new Point(2, maxY - 2), new Point(maxX - 2, maxY - 2));
			// Inner Border (Right)
			g.DrawLine(penInnerBorderBottomRight, new Point(maxX - 3, 4), new Point(maxX - 3, maxY - 3));
			g.DrawLine(penInnerBorderBottomRight, new Point(maxX - 2, 3), new Point(maxX - 2, maxY - 2));
		}
		else
		{
			// Border (Top, Bottom, Left, Right)
			g.DrawLine(penBorder, new Point(1, 0), new Point(maxX - 1, 0));
			g.DrawLine(penBorder, new Point(1, maxY), new Point(maxX - 1, maxY));
			g.DrawLine(penBorder, new Point(0, 1), new Point(0, maxY - 1));
			g.DrawLine(penBorder, new Point(maxX, 1), new Point(maxX, maxY - 1));
			// Inner Border (Top)
			g.DrawLine(penInnerBorderTopLeft, new Point(1, 1), new Point(maxX - 1, 1));
			g.DrawLine(penInnerBorderTopLeft, new Point(1, 2), new Point(maxX - 2, 2));
			// Inner Border (Left)
			g.DrawLine(penInnerBorderTopLeft, new Point(1, 1), new Point(1, maxY - 1));
			g.DrawLine(penInnerBorderTopLeft, new Point(2, 1), new Point(2, maxY - 2));
			// Inner Border (Bottom)
			g.DrawLine(penInnerBorderBottomRight, new Point(2, maxY - 2), new Point(maxX - 2, maxY - 2));
			g.DrawLine(penInnerBorderBottomRight, new Point(1, maxY - 1), new Point(maxX - 1, maxY - 1));
			// Inner Border (Right)
			g.DrawLine(penInnerBorderBottomRight, new Point(maxX - 2, 3), new Point(maxX - 2, maxY - 2));
			g.DrawLine(penInnerBorderBottomRight, new Point(maxX - 1, 2), new Point(maxX - 1, maxY - 1));
		}
		g.Dispose();
		return bmp;
	}

	protected override void OnPaint(PaintEventArgs pevent)
	{
		if (beClassic)
		{
			Bitmap bmp = this.toBmp();
			pevent.Graphics.DrawImageUnscaled(bmp, 0, 0);
			bmp.Dispose();
		}
		else
		{
			base.OnPaint(pevent);
		}
	}

	protected override void OnLostFocus(EventArgs e)
	{
		mDown = false;
		this.Refresh();
		base.OnLostFocus(e);
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		if (mevent.Button == MouseButtons.Left)
		{
			mDown = true;
			this.Refresh();
		}
		base.OnMouseDown(mevent);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		if (mevent.Button == MouseButtons.Left)
		{
			mDown = false;
			this.Refresh();
		}
		base.OnMouseUp(mevent);
	}

	protected override void OnMouseMove(MouseEventArgs mevent)
	{
		mOver = (this.ClientRectangle.Contains(PointToClient(MousePosition)));
		this.Refresh();
		base.OnMouseMove(mevent);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		// If pressed Spacebar...
		if (e.KeyChar == ' ')
		{
			mPress = true;
		}
		this.Refresh();
		base.OnKeyPress(e);
	}

	protected override void OnKeyUp(KeyEventArgs kevent)
	{
		mPress = false;
		this.Refresh();
		base.OnKeyUp(kevent);
	}

}
