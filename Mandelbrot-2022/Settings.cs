namespace Mandelbrot_2022
{
  public partial class Settings : Form
  {
    private readonly Parameters Parameters = new Parameters();

    public Settings()
    {
      InitializeComponent();

      xMin.DataBindings.Add("Text", Parameters, "XMin");
      xMax.DataBindings.Add("Text", Parameters, "XMax");
      yMin.DataBindings.Add("Text", Parameters, "YMin");
      yMax.DataBindings.Add("Text", Parameters, "YMax");
      imageWidth.DataBindings.Add("Text", Parameters, "WidthPixels");
      imageHeight.DataBindings.Add("Text", Parameters, "HeightPixels");
      colorMode.DataSource = Enum.GetValues(typeof(ColorModes));
      colorMode.DataBindings.Add("SelectedItem", Parameters, "ColorMode");
    }
    private void Generate_Click(object sender, EventArgs e)
    {
      var newMandelbrot = new MandelbrotGeneration();
      newMandelbrot.Generate(Parameters);
    }
  }
}