using System.ComponentModel;

namespace Mandelbrot_2022
{
  public class Parameters : INotifyPropertyChanged
  {
    double xMin = -2.0;
    double xMax = 1.0;
    double yMin = -1.0;
    double yMax = 1.0;
    int widthPixels = 1024;
    int heightPixels = 768;
    ColorModes colorMode = ColorModes.Banded;

    public Parameters()
    {
    }

    public Parameters(Parameters toCopy)
    {
      XMax = toCopy.XMax;
      YMax = toCopy.YMax;
      WidthPixels = toCopy.WidthPixels;
      HeightPixels = toCopy.HeightPixels;
      XMin = toCopy.XMin;
      YMin = toCopy.YMin;
      ColorMode = toCopy.ColorMode;
    }

    public double XMin
    {
      get { return xMin; }
      set
      {
        xMin = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(XMin)));
      }
    }

    public double XMax
    {
      get { return xMax; }
      set
      {
        xMax = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(XMax)));
      }
    }

    public double YMin
    {
      get { return yMin; }
      set
      {
        yMin = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(YMin)));
      }
    }

    public double YMax
    {
      get { return yMax; }
      set
      {
        yMax = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(YMax)));
      }
    }

    public int WidthPixels
    {
      get { return widthPixels; }
      set
      {
        widthPixels = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(WidthPixels)));
      }
    }
    public int HeightPixels
    {
      get { return heightPixels; }
      set
      {
        heightPixels = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(HeightPixels)));
      }
    }

    public double XRange
    {
      get { return XMax - XMin; }
    }

    public double YRange
    {
      get { return YMax - YMin; }
    }

    public ColorModes ColorMode
    {
      get { return colorMode; }
      set
      {
        colorMode = value;
        InvokePropertyChanged(new PropertyChangedEventArgs(nameof(ColorMode)));
      }
    }

    public (double, double) PixelPointToMandelbrotPoint(Point point)
    {
      double percentOfWidth = (double)point.X / widthPixels;
      double x = XMin + XRange * percentOfWidth;
      double percentOfHeight = (double)point.Y / heightPixels;
      double y = YMin + YRange * percentOfHeight;
      return (x, y);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void InvokePropertyChanged(PropertyChangedEventArgs e)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) handler(this, e);
    }
  }
}
