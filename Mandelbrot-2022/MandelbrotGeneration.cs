using System.Numerics;

namespace Mandelbrot_2022
{
  public class MandelbrotGeneration
  {
    public static int maxIterations = 256;

    private int[,] mandelbrot;

    private Parameters parameters;

    public void Generate(Parameters parameters)
    {
      this.parameters = parameters;
      mandelbrot = new int[parameters.WidthPixels, parameters.HeightPixels];
      MandelbrotDisplay mandelbrotDisplay = new MandelbrotDisplay(parameters);
      mandelbrotDisplay.Show();
      Task.Run(() =>
      {
        Calculate();
        mandelbrotDisplay.Colorize(mandelbrot);
      });
    }

    private void Calculate()
    {
      int width = parameters.WidthPixels;
      int height = parameters.HeightPixels;

      // Set the initial bounds of the Mandelbrot set
      double xMin = parameters.XMin;
      double xMax = parameters.XMax;
      double yMin = parameters.YMin;
      double yMax = parameters.YMax;

      // Calculate the step size for each pixel
      double xStep = (xMax - xMin) / width;
      double yStep = (yMax - yMin) / height;

      // Iterate over each pixel
      Parallel.For(0, height, y =>
      {
        for (int x = 0; x < width; x++)
        {
          // Calculate the complex number for the current pixel
          double cReal = xMin + x * xStep;
          double cImag = yMin + y * yStep;
          Complex c = new Complex(cReal, cImag);

          // Iterate the Mandelbrot function until it diverges or the maximum number of iterations is reached
          int iterations = 0;
          Complex z = new Complex(0, 0);
          while (iterations < maxIterations && z.Magnitude <= 2.0)
          {
            z = z * z + c;
            iterations++;
          }

          mandelbrot[x, y] = iterations;
        }
      });
    }
  }
}
