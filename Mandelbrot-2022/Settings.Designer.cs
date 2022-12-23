namespace Mandelbrot_2022
{
  partial class Settings
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
      this.Generate = new System.Windows.Forms.Button();
      this.xMin = new System.Windows.Forms.TextBox();
      this.xMax = new System.Windows.Forms.TextBox();
      this.yMin = new System.Windows.Forms.TextBox();
      this.yMax = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.imageWidth = new System.Windows.Forms.TextBox();
      this.imageHeight = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.colorMode = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // Generate
      // 
      this.Generate.Location = new System.Drawing.Point(97, 256);
      this.Generate.Name = "Generate";
      this.Generate.Size = new System.Drawing.Size(100, 23);
      this.Generate.TabIndex = 0;
      this.Generate.Text = "Generate";
      this.Generate.UseVisualStyleBackColor = true;
      this.Generate.Click += new System.EventHandler(this.Generate_Click);
      // 
      // xMin
      // 
      this.xMin.Location = new System.Drawing.Point(97, 53);
      this.xMin.Name = "xMin";
      this.xMin.Size = new System.Drawing.Size(100, 23);
      this.xMin.TabIndex = 1;
      // 
      // xMax
      // 
      this.xMax.Location = new System.Drawing.Point(97, 82);
      this.xMax.Name = "xMax";
      this.xMax.Size = new System.Drawing.Size(100, 23);
      this.xMax.TabIndex = 2;
      // 
      // yMin
      // 
      this.yMin.Location = new System.Drawing.Point(97, 111);
      this.yMin.Name = "yMin";
      this.yMin.Size = new System.Drawing.Size(100, 23);
      this.yMin.TabIndex = 3;
      // 
      // yMax
      // 
      this.yMax.Location = new System.Drawing.Point(97, 140);
      this.yMax.Name = "yMax";
      this.yMax.Size = new System.Drawing.Size(100, 23);
      this.yMax.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(53, 56);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(40, 15);
      this.label1.TabIndex = 5;
      this.label1.Text = "X-Min";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(49, 85);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(42, 15);
      this.label2.TabIndex = 6;
      this.label2.Text = "X-Max";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(51, 114);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(40, 15);
      this.label3.TabIndex = 7;
      this.label3.Text = "Y-Min";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(49, 143);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(42, 15);
      this.label4.TabIndex = 8;
      this.label4.Text = "Y-Max";
      // 
      // imageWidth
      // 
      this.imageWidth.Location = new System.Drawing.Point(97, 169);
      this.imageWidth.Name = "imageWidth";
      this.imageWidth.Size = new System.Drawing.Size(100, 23);
      this.imageWidth.TabIndex = 9;
      // 
      // imageHeight
      // 
      this.imageHeight.Location = new System.Drawing.Point(97, 198);
      this.imageHeight.Name = "imageHeight";
      this.imageHeight.Size = new System.Drawing.Size(100, 23);
      this.imageHeight.TabIndex = 10;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 172);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(75, 15);
      this.label5.TabIndex = 11;
      this.label5.Text = "Image Width";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 201);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(79, 15);
      this.label6.TabIndex = 12;
      this.label6.Text = "Image Height";
      // 
      // colorMode
      // 
      this.colorMode.FormattingEnabled = true;
      this.colorMode.Location = new System.Drawing.Point(97, 227);
      this.colorMode.Name = "colorMode";
      this.colorMode.Size = new System.Drawing.Size(100, 23);
      this.colorMode.TabIndex = 13;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 230);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(70, 15);
      this.label7.TabIndex = 14;
      this.label7.Text = "Color Mode";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(12, 9);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(201, 25);
      this.label8.TabIndex = 15;
      this.label8.Text = "Mandelbrot Generator";
      this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(219, 295);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.colorMode);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.imageHeight);
      this.Controls.Add(this.imageWidth);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.yMax);
      this.Controls.Add(this.yMin);
      this.Controls.Add(this.xMax);
      this.Controls.Add(this.xMin);
      this.Controls.Add(this.Generate);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Settings";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Button Generate;
    private TextBox xMin;
    private TextBox xMax;
    private TextBox yMin;
    private TextBox yMax;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox imageWidth;
    private TextBox imageHeight;
    private Label label5;
    private Label label6;
    private ComboBox colorMode;
    private Label label7;
    private Label label8;
  }
}