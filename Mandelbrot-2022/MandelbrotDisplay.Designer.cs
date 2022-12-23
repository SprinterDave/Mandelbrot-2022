namespace Mandelbrot_2022
{
  partial class MandelbrotDisplay
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MandelbrotDisplay));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
      this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.picturebox = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStrip1
      // 
      this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
      this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.toolStripProgressBar1,
            this.toolStripSeparator1,
            this.toolStripLabel2});
      this.toolStrip1.Location = new System.Drawing.Point(0, 117);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(332, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripLabel1
      // 
      this.toolStripLabel1.Name = "toolStripLabel1";
      this.toolStripLabel1.Size = new System.Drawing.Size(70, 22);
      this.toolStripLabel1.Text = "Color Mode";
      // 
      // toolStripComboBox1
      // 
      this.toolStripComboBox1.Name = "toolStripComboBox1";
      this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
      this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
      // 
      // toolStripProgressBar1
      // 
      this.toolStripProgressBar1.Name = "toolStripProgressBar1";
      this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
      this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(270, 22);
      this.toolStripLabel2.Text = "Click and drag from the center of an area to zoom";
      // 
      // picturebox
      // 
      this.picturebox.ContextMenuStrip = this.contextMenuStrip1;
      this.picturebox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.picturebox.Location = new System.Drawing.Point(0, 0);
      this.picturebox.Margin = new System.Windows.Forms.Padding(0);
      this.picturebox.Name = "picturebox";
      this.picturebox.Size = new System.Drawing.Size(332, 117);
      this.picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picturebox.TabIndex = 0;
      this.picturebox.TabStop = false;
      this.picturebox.Paint += new System.Windows.Forms.PaintEventHandler(this.mandelbrot_Paint);
      this.picturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mandelbrot_MouseDown);
      this.picturebox.MouseLeave += new System.EventHandler(this.mandelbrot_MouseLeave);
      this.picturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mandelbrot_MouseMove);
      this.picturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mandelbrot_MouseUp);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
      // 
      // copyToClipboardToolStripMenuItem
      // 
      this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
      this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.copyToClipboardToolStripMenuItem.Text = "Copy To Clipboard";
      this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
      // 
      // saveToFileToolStripMenuItem
      // 
      this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
      this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
      this.saveToFileToolStripMenuItem.Text = "Save To File...";
      this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
      // 
      // MandelbrotDisplay
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(332, 142);
      this.Controls.Add(this.picturebox);
      this.Controls.Add(this.toolStrip1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "MandelbrotDisplay";
      this.Text = "MandelbrotDisplay";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private ToolStrip toolStrip1;
    private ToolStripLabel toolStripLabel1;
    private ToolStripComboBox toolStripComboBox1;
    private ToolStripProgressBar toolStripProgressBar1;
    private PictureBox picturebox;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripLabel toolStripLabel2;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem copyToClipboardToolStripMenuItem;
    private ToolStripMenuItem saveToFileToolStripMenuItem;
  }
}