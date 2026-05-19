using System.Drawing.Drawing2D;

namespace DronePidTuningAssistant.WinForms.Controls;

public sealed class AttitudeIndicatorControl : Control
{
    private double _rollDeg;
    private double _pitchDeg;

    public double RollDeg
    {
        get => _rollDeg;
        set
        {
            _rollDeg = Math.Clamp(value, -180.0, 180.0);
            Invalidate();
        }
    }

    public double PitchDeg
    {
        get => _pitchDeg;
        set
        {
            _pitchDeg = Math.Clamp(value, -90.0, 90.0);
            Invalidate();
        }
    }

    public AttitudeIndicatorControl()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        BackColor = Color.FromArgb(175, 175, 175);
        Size = new Size(220, 220);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(BackColor);

        var size = Math.Min(Width, Height);
        var radius = (size / 2f) - 8f;
        var center = new PointF(Width / 2f, Height / 2f);
        var clip = new RectangleF(center.X - radius, center.Y - radius, radius * 2f, radius * 2f);

        using var clipPath = new GraphicsPath();
        clipPath.AddEllipse(clip);
        var previousClip = e.Graphics.Clip;
        e.Graphics.SetClip(clipPath);

        DrawHorizon(e.Graphics, center, radius);

        e.Graphics.Clip = previousClip;

        DrawOuterRing(e.Graphics, center, radius);
        DrawBankTicks(e.Graphics, center, radius);
        DrawAircraftSymbol(e.Graphics, center, radius);
        DrawReadout(e.Graphics, center, radius);
    }

    private void DrawHorizon(Graphics g, PointF center, float radius)
    {
        var pixelsPerPitchDeg = radius / 30f;
        g.TranslateTransform(center.X, center.Y);
        // Positive roll should bank the horizon left (aircraft right bank).
        g.RotateTransform((float)_rollDeg);
        // Positive pitch should move horizon down (nose up).
        g.TranslateTransform(0f, (float)(-_pitchDeg * pixelsPerPitchDeg));

        using var skyBrush = new SolidBrush(Color.FromArgb(66, 173, 255));
        using var groundBrush = new SolidBrush(Color.FromArgb(122, 80, 42));
        g.FillRectangle(skyBrush, -radius * 2f, -radius * 2f, radius * 4f, radius * 2f);
        g.FillRectangle(groundBrush, -radius * 2f, 0f, radius * 4f, radius * 2f);

        using var horizonPen = new Pen(Color.White, Math.Max(2f, radius * 0.015f));
        g.DrawLine(horizonPen, -radius * 2f, 0f, radius * 2f, 0f);

        using var pitchPen = new Pen(Color.White, Math.Max(1.5f, radius * 0.011f));
        for (var deg = -30; deg <= 30; deg += 5)
        {
            if (deg == 0)
            {
                continue;
            }

            var y = (float)(-deg * pixelsPerPitchDeg);
            var major = deg % 10 == 0;
            var halfWidth = major ? radius * 0.18f : radius * 0.1f;
            g.DrawLine(pitchPen, -halfWidth, y, halfWidth, y);
        }

        g.ResetTransform();
    }

    private static void DrawOuterRing(Graphics g, PointF center, float radius)
    {
        using var ringPen = new Pen(Color.Silver, Math.Max(3f, radius * 0.05f));
        g.DrawEllipse(ringPen, center.X - radius, center.Y - radius, radius * 2f, radius * 2f);
    }

    private static void DrawBankTicks(Graphics g, PointF center, float radius)
    {
        using var pen = new Pen(Color.White, Math.Max(1.5f, radius * 0.01f));
        var tickAngles = new[] { -60, -45, -30, -20, -10, 10, 20, 30, 45, 60 };
        foreach (var angleDeg in tickAngles)
        {
            var rad = (float)(Math.PI * angleDeg / 180.0);
            var outer = new PointF(center.X + (float)Math.Sin(rad) * radius * 0.94f, center.Y - (float)Math.Cos(rad) * radius * 0.94f);
            var inner = new PointF(center.X + (float)Math.Sin(rad) * radius * 0.84f, center.Y - (float)Math.Cos(rad) * radius * 0.84f);
            g.DrawLine(pen, inner, outer);
        }

        using var markerBrush = new SolidBrush(Color.Orange);
        var tri = new[]
        {
            new PointF(center.X, center.Y - radius * 0.97f),
            new PointF(center.X - radius * 0.05f, center.Y - radius * 0.84f),
            new PointF(center.X + radius * 0.05f, center.Y - radius * 0.84f),
        };
        g.FillPolygon(markerBrush, tri);
    }

    private static void DrawAircraftSymbol(Graphics g, PointF center, float radius)
    {
        using var pen = new Pen(Color.Orange, Math.Max(2f, radius * 0.016f));
        var wing = radius * 0.22f;
        var arm = radius * 0.08f;
        g.DrawLine(pen, center.X - wing, center.Y, center.X - arm, center.Y);
        g.DrawLine(pen, center.X + arm, center.Y, center.X + wing, center.Y);
        g.DrawLine(pen, center.X, center.Y - radius * 0.05f, center.X, center.Y + radius * 0.08f);
    }

    private void DrawReadout(Graphics g, PointF center, float radius)
    {
        var box = new RectangleF(center.X - radius * 0.35f, center.Y + radius * 0.28f, radius * 0.7f, radius * 0.28f);
        using var fill = new SolidBrush(Color.FromArgb(150, 0, 0, 0));
        using var border = new Pen(Color.Black, 1f);
        g.FillRectangle(fill, box);
        g.DrawRectangle(border, box.X, box.Y, box.Width, box.Height);

        using var font = new Font(Font.FontFamily, Math.Max(8f, radius * 0.11f), FontStyle.Regular, GraphicsUnit.Pixel);
        using var brush = new SolidBrush(Color.White);
        var text = $"Roll: {_rollDeg,6:000.0}{Environment.NewLine}Pitch:{_pitchDeg,6:000.0}";
        g.DrawString(text, font, brush, box, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
    }
}
