using System.Windows.Forms;

namespace Cloth_simulation_try_2
{
    partial class Form1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pointsCheckbox = new System.Windows.Forms.RadioButton();
            this.gridCheckbox = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthTextbox = new System.Windows.Forms.TextBox();
            this.heightTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gravitySlider = new System.Windows.Forms.TrackBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gravitySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this._Paint);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MouseDown);
            this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this._MouseMove);
            this.splitContainer1.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this._MouseUp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.pointsCheckbox);
            this.splitContainer1.Panel2.Controls.Add(this.gridCheckbox);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.widthTextbox);
            this.splitContainer1.Panel2.Controls.Add(this.heightTextbox);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.gravitySlider);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(764, 612);
            this.splitContainer1.SplitterDistance = 534;
            this.splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Change background color...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Change color...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // pointsCheckbox
            // 
            this.pointsCheckbox.AutoSize = true;
            this.pointsCheckbox.Location = new System.Drawing.Point(11, 146);
            this.pointsCheckbox.Name = "pointsCheckbox";
            this.pointsCheckbox.Size = new System.Drawing.Size(54, 17);
            this.pointsCheckbox.TabIndex = 8;
            this.pointsCheckbox.Text = "Points";
            this.pointsCheckbox.UseVisualStyleBackColor = true;
            this.pointsCheckbox.CheckedChanged += new System.EventHandler(this.pointsCheckbox_CheckedChanged);
            // 
            // gridCheckbox
            // 
            this.gridCheckbox.AutoSize = true;
            this.gridCheckbox.Checked = true;
            this.gridCheckbox.Location = new System.Drawing.Point(11, 169);
            this.gridCheckbox.Name = "gridCheckbox";
            this.gridCheckbox.Size = new System.Drawing.Size(65, 17);
            this.gridCheckbox.TabIndex = 7;
            this.gridCheckbox.TabStop = true;
            this.gridCheckbox.Text = "Gridlines";
            this.gridCheckbox.UseVisualStyleBackColor = true;
            this.gridCheckbox.CheckedChanged += new System.EventHandler(this.gridCheckbox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // widthTextbox
            // 
            this.widthTextbox.Location = new System.Drawing.Point(112, 110);
            this.widthTextbox.Name = "widthTextbox";
            this.widthTextbox.Size = new System.Drawing.Size(100, 20);
            this.widthTextbox.TabIndex = 4;
            this.widthTextbox.TextChanged += new System.EventHandler(this.lengthChanged);
            // 
            // heightTextbox
            // 
            this.heightTextbox.Location = new System.Drawing.Point(6, 110);
            this.heightTextbox.Name = "heightTextbox";
            this.heightTextbox.Size = new System.Drawing.Size(100, 20);
            this.heightTextbox.TabIndex = 3;
            this.heightTextbox.TextChanged += new System.EventHandler(this.widthChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gravity";
            // 
            // gravitySlider
            // 
            this.gravitySlider.LargeChange = 1;
            this.gravitySlider.Location = new System.Drawing.Point(6, 25);
            this.gravitySlider.Maximum = 40;
            this.gravitySlider.Name = "gravitySlider";
            this.gravitySlider.Size = new System.Drawing.Size(206, 45);
            this.gravitySlider.TabIndex = 0;
            this.gravitySlider.Value = 4;
            this.gravitySlider.Scroll += new System.EventHandler(this.gravitySlider_Scroll);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 612);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this._Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this._MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this._MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this._MouseUp);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gravitySlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar gravitySlider;
        private Label label3;
        private Label label2;
        private TextBox widthTextbox;
        private TextBox heightTextbox;
        private RadioButton pointsCheckbox;
        private RadioButton gridCheckbox;
        private ColorDialog colorDialog1;
        private Button button1;
        private Button button2;
    }
}

