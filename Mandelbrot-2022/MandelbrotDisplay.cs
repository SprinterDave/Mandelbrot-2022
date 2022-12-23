using System.Data;
using System.Drawing.Imaging;
using System.Numerics;

namespace Mandelbrot_2022
{
  public partial class MandelbrotDisplay : Form
  {
    SemaphoreSlim semaphore = new SemaphoreSlim(1);
    Point startPoint = Point.Empty;
    Point mouseLocation = Point.Empty;
    Rectangle dragRectangle = Rectangle.Empty;
    Rectangle lockRectangle = Rectangle.Empty;
    bool drag = false;
    double widthToHeightRatio;
    Parameters parameters;
    Bitmap bitmap;
    Font font = new Font("Arial", 10, FontStyle.Bold);
    int[,] mandelbrotValues;
    List<ToolStripItem> toolstripControls = new List<ToolStripItem>();
    Brush textBackgroundBrush = new SolidBrush(Color.FromArgb(128, Color.Black));

    public MandelbrotDisplay(Parameters parameters)
    {
      InitializeComponent();
      toolstripControls.AddRange(new ToolStripItem[] { toolStripLabel1, toolStripLabel2, toolStripComboBox1 });
      toolStripComboBox1.Items.AddRange(Enum.GetValues(parameters.ColorMode.GetType()).Cast<object>().ToArray());
      toolStripComboBox1.SelectedItem = parameters.ColorMode;

      ShowItemsWhenRenderChanges(false);

      this.parameters = parameters;
      bitmap = new Bitmap(parameters.WidthPixels, parameters.HeightPixels);
    }

    internal void Colorize(int[,] mandelbrotValues)
    {
      CheckAndInvoke(() =>
      {
        toolStripProgressBar1.Visible = true;
        this.Text = $"Mandelbrot: ({parameters.XMin:F3},{-parameters.YMin:F3}) - ({parameters.XMax:F3},{-parameters.YMax:F3}) : ({parameters.WidthPixels} x {parameters.HeightPixels}) : {parameters.ColorMode}";
      });
      this.mandelbrotValues = mandelbrotValues;
      // Iterate over each pixel
      Parallel.For(0, parameters.HeightPixels, y =>
      {
        for (int x = 0; x < parameters.WidthPixels; x++)
        {
          semaphore.Wait();
          bitmap.SetPixel(x, y, colorFunc[parameters.ColorMode](x, y, parameters.WidthPixels, parameters.HeightPixels, mandelbrotValues[x, y]));
          semaphore.Release();
        }
      });

      SetImage(bitmap);
      SetIcon(bitmap);
      ShowItemsWhenRenderChanges(true);
    }

    internal void CheckAndInvoke(Action action)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(action);
      }
      else
      {
        action();
      }
    }

    internal void ShowItemsWhenRenderChanges(bool show)
    {
      CheckAndInvoke(() =>
      {
        foreach (var item in toolstripControls)
        {
          item.Visible = show;
        }
      });
    }

    internal void SetImage(Bitmap bitmap)
    {
      CheckAndInvoke(() =>
      {
        toolStripProgressBar1.Visible = false;
        picturebox.Width = bitmap.Width;
        picturebox.Height = bitmap.Height;
        picturebox.Image = bitmap;
        widthToHeightRatio = (double)bitmap.Width / (double)bitmap.Height;
      });
    }

    internal void SetIcon(Bitmap bitmap)
    {
      CheckAndInvoke(() =>
      {
        var clone = (bitmap.Clone() as Bitmap).GetThumbnailImage(64, 64, null, IntPtr.Zero) as Bitmap;
        {
          Icon icon = Icon.FromHandle(clone.GetHicon());
          this.Icon = icon;
        }
      });
    }

    private void mandelbrot_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
      {
        return;
      }

      startPoint = e.Location;
      drag = true;
      lockRectangle = Rectangle.Empty;
    }

    private void mandelbrot_MouseMove(object sender, MouseEventArgs e)
    {
      mouseLocation = e.Location;
      if (drag)
      {
        int diffX = Math.Abs(e.X - startPoint.X);
        int diffY = (int)Math.Round(diffX / widthToHeightRatio);

        // Update the rubber band box as the mouse moves
        int x = startPoint.X - diffX;
        int y = startPoint.Y - diffY;
        int width = 2 * diffX;
        int height = 2 * diffY;
        dragRectangle = new Rectangle(x, y, width, height);
      }
      picturebox.Invalidate();
    }

    private void mandelbrot_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
      {
        return;
      }

      if (MessageBox.Show("Generate new mandelbrot with these coordinates?", "Generate?", MessageBoxButtons.OKCancel)
        == DialogResult.OK)
      {
        lockRectangle = dragRectangle;
        var newMandelbrot = new MandelbrotGeneration();
        newMandelbrot.Generate(GetNewParameters(lockRectangle));
      }
      drag = false;
    }

    private void DrawDragCoordinates(Graphics g, Pen linePen, Brush textBrush, Brush backBrush)
    {
      Parameters p = GetNewParameters(dragRectangle);
      string topLeft = $"({p.XMin:F3}, {-p.YMin:F3})";
      string bottomRight = $"({p.XMax:F3}, {-p.YMax:F3})";
      Size topLeftStringSize = g.MeasureString(topLeft, font, 0, StringFormat.GenericTypographic).ToSize();
      Size bottomRightStringSize = g.MeasureString(bottomRight, font, 0, StringFormat.GenericTypographic).ToSize();
      Point topLeftPos = dragRectangle.Location;
      if (topLeftStringSize.Width > dragRectangle.Width)
      {
        topLeftPos.X -= topLeftStringSize.Width;
        topLeftPos.Y -= topLeftStringSize.Height;
      }
      Point bottomRightPos = dragRectangle.Location + (dragRectangle.Size - bottomRightStringSize);
      if (bottomRightStringSize.Width > dragRectangle.Width)
      {
        bottomRightPos.X += bottomRightStringSize.Width;
        bottomRightPos.Y += bottomRightStringSize.Height;
      }
      Rectangle r = new Rectangle(topLeftPos, topLeftStringSize);
      g.FillRectangle(backBrush, r);
      g.DrawString(topLeft, font, textBrush, topLeftPos, StringFormat.GenericTypographic);
      r = new Rectangle(bottomRightPos, bottomRightStringSize);
      g.FillRectangle(backBrush, r);
      g.DrawString(bottomRight, font, textBrush, bottomRightPos, StringFormat.GenericTypographic);
      g.DrawRectangle(linePen, dragRectangle);
    }

    private void DrawMouseCoordinates(Graphics g, Pen linePen, Brush textBrush, Brush backBrush)
    {
      (double x, double y) = parameters.PixelPointToMandelbrotPoint(mouseLocation);
      string str = $"({x:F4}, {-y:F4})";
      Size stringSize = g.MeasureString(str, font, 0, StringFormat.GenericTypographic).ToSize();
      Point where = mouseLocation - stringSize;
      where.X = Math.Clamp(where.X, 0, picturebox.Width);
      where.Y = Math.Clamp(where.Y, 0, picturebox.Height);
      Rectangle r = new Rectangle(where, stringSize);
      g.FillRectangle(backBrush, r);
      g.DrawString(str, font, Brushes.White, where, StringFormat.GenericTypographic);
    }

    private void mandelbrot_Paint(object sender, PaintEventArgs e)
    {
      if (drag)
      {
        DrawDragCoordinates(e.Graphics, Pens.White, Brushes.White, textBackgroundBrush);
      }
      else if (lockRectangle != Rectangle.Empty)
      {
        DrawDragCoordinates(e.Graphics, Pens.Green, Brushes.Green, textBackgroundBrush);
      }
      else if (picturebox.ClientRectangle.Contains(picturebox.PointToClient(Control.MousePosition)))
      {
        DrawMouseCoordinates(e.Graphics, Pens.White, Brushes.White, textBackgroundBrush);
      }
    }

    private Parameters GetNewParameters(Rectangle rectangle)
    {
      Parameters newParameters = new Parameters(parameters);
      (double xmin, double ymin) = parameters.PixelPointToMandelbrotPoint(rectangle.Location);
      (double xmax, double ymax) = parameters.PixelPointToMandelbrotPoint(rectangle.Location + rectangle.Size);

      newParameters.XMin = xmin;
      newParameters.XMax = xmax;
      newParameters.YMin = ymin;
      newParameters.YMax = ymax;

      return newParameters;
    }

    private void mandelbrot_MouseLeave(object sender, EventArgs e)
    {
      picturebox.Invalidate();
    }

    private Dictionary<ColorModes, Func<int, int, int, int, int, Color>> colorFunc = new Dictionary<ColorModes, Func<int, int, int, int, int, Color>>
    {
      [ColorModes.Intensity] = GenerateIntensityColor,
      [ColorModes.Smooth] = GenerateSmoothColor,
      [ColorModes.ThreeDimension] = Generate3DColor,
      [ColorModes.Banded] = GenerateColorCyclingColor,
      [ColorModes.Rainbow] = GenerateRainbowColor,
    };

    private static Color GenerateIntensityColor(int x, int y, int width, int height, int iterations)
    {
      int intensity = (int)(255 * iterations / (double)MandelbrotGeneration.maxIterations);
      return Color.FromArgb(intensity, intensity, intensity);
    }

    private static Color GenerateSmoothColor(int x, int y, int width, int height, int iterations)
    {
      if (iterations == MandelbrotGeneration.maxIterations)
      {
        return Color.Black;
      }

      double t = (double)iterations / MandelbrotGeneration.maxIterations;
      return Color.FromArgb(255, (int)(9 * (1 - t) * t * t * t * 255), (int)(15 * (1 - t) * (1 - t) * t * t * 255), (int)(8.5 * (1 - t) * (1 - t) * (1 - t) * t * 255));
    }

    private static Color GenerateColorCyclingColor(int x, int y, int width, int height, int iterations)
    {
      Color[] palette = new Color[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
      // Calculate the color for this pixel
      Color color;
      if (iterations == MandelbrotGeneration.maxIterations)
      {
        // Color points that do not escape black
        color = Color.Black;
      }
      else
      {
        // Choose the color from the palette based on the number of iterations
        int index = iterations % palette.Length;
        color = palette[index];
      }
      return color;
    }

    private static Color GenerateRainbowColor(int x, int y, int width, int height, int iterations)
    {
      Color color;
      if (iterations == MandelbrotGeneration.maxIterations)
      {
        // Color points that do not escape black
        color = Color.Black;
      }
      else
      {
        // Calculate the rainbow color based on the number of iterations
        double t = (double)iterations / MandelbrotGeneration.maxIterations;
        color = Color.FromArgb(255, (int)(Math.Sin(t * 2 * Math.PI) * 127 + 128), (int)(Math.Sin(t * 2 * Math.PI + 2 * Math.PI / 3) * 127 + 128), (int)(Math.Sin(t * 2 * Math.PI + 4 * Math.PI / 3) * 127 + 128));
      }
      return color;
    }

    private static Color Generate3DColor(int x, int y, int width, int height, int iterations)
    {
      // Calculate the color for this pixel
      Color color;
      if (iterations == MandelbrotGeneration.maxIterations)
      {
        // Color points that do not escape black
        color = Color.Black;
      }
      else
      {
        // Calculate the 3D color based on the number of iterations
        double t = (double)iterations / MandelbrotGeneration.maxIterations;
        int r = (int)(Math.Sin(t * 2 * Math.PI) * 127 + 128);
        int g = (int)(Math.Sin(t * 2 * Math.PI + 2 * Math.PI / 3) * 127 + 128);
        int b = (int)(Math.Sin(t * 2 * Math.PI + 4 * Math.PI / 3) * 127 + 128);

        // Add shading and highlights to create the illusion of depth
        double z = (double)iterations / MandelbrotGeneration.maxIterations;
        double nx = (double)x / width - 0.5;
        double ny = (double)y / height - 0.5;
        double L = Math.Sqrt(nx * nx + ny * ny) / Math.Sqrt(2);
        double z1 = z + 1 - L;
        double k = z1 / (z1 + 1);
        r = (int)(r * k);
        g = (int)(g * k);
        b = (int)(b * k);

        color = Color.FromArgb(255, r, g, b);
      }
      return color;
    }

    private static Color GenerateFractalDimensionColor(int x, int y, int width, int height, int iterations)
    {
      // Calculate the color for this pixel
      Color color;
      if (iterations == MandelbrotGeneration.maxIterations)
      {
        // Color points that do not escape black
        color = Color.Black;
      }
      else
      {
        // Calculate the fractal dimension at this point
        Complex c = new Complex((x - width / 2) * 4.0 / width, (y - height / 2) * 4.0 / width);
        Complex z = Complex.Zero;
        double r2 = 0;
        int i;
        for (i = 0; i < MandelbrotGeneration.maxIterations; i++)
        {
          z = z * z + c;
          r2 = z.Magnitude;
          if (r2 > 2)
            break;
        }

        // Calculate the color based on the fractal dimension
        double t = Math.Log(Math.Log(r2) / Math.Log(2)) / Math.Log(2);
        t = (t - i) / MandelbrotGeneration.maxIterations;
        int r = (int)(t * 255);
        int g = (int)((1 - t) * 255);
        int b = 0;
        color = Color.FromArgb(255, r, g, b);
      }
      return color;
    }

    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.parameters == null)
      {
        return;
      }

      this.parameters.ColorMode = Enum.Parse<ColorModes>(toolStripComboBox1.SelectedItem.ToString());
      Colorize(mandelbrotValues);
    }

    private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        bitmap.Save(stream, ImageFormat.Png);
        using (Image image = Image.FromStream(stream))
        {
          Clipboard.SetImage(image);
        }
      }
    }

    private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "PNG Files|*.png|JPG Files|*.jpg";
      sfd.DefaultExt = "png";
      sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
      if (sfd.ShowDialog() == DialogResult.OK)
      {
        string path = sfd.FileName;
        if (File.Exists(path))
        {
          if (MessageBox.Show($"{Path.GetFileName(path)} already exists. Overwrite?",
            "Overwrie?",
            MessageBoxButtons.OKCancel) != DialogResult.OK)
          {
            return;
          }
        }
        if (Path.GetExtension(path).ToLower() == ".png")
        {
          bitmap.Save(path, ImageFormat.Png);
        }
        else if (Path.GetExtension(path).ToLower() == ".jpg" ||
          Path.GetExtension(path).ToLower() == ".jpeg")
        {
          bitmap.Save(path, ImageFormat.Jpeg);
        }
      }
    }
  }
}
