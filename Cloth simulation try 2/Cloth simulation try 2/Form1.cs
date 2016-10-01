using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cloth_simulation_try_2
{
    public partial class Form1 : Form
    {

        private int[] clothDimentions = { 20, 20 }; //size of cloth in points
        private clothPoint[][] clothpoints;            //Array of points on cloth
        private static double gravityY = 1;             //downward force of gravity. On earth it is 1
        private static double gravityX = 0;             //force of gravity to the right. On earth it is 0
        private const int UPI = 20;                     //Units per inch
        public static int PPU = 200 / UPI;              //Pixels per unit
        private static int padding = 60;                //Extra space from corners
        double stretch = 2;
        Timer drawTimer = new Timer();
        Timer clickTimer = new Timer();
        private int[] closestpoint;
        Point mouse;
        Color backgroundColor = Color.Black;
        Color clothColor = Color.White;
        public Form1()
        {
            InitializeComponent();
            clickTimer.Interval = 1;
            clickTimer.Tick += ClickTimer_Tick;
            drawTimer.Interval = 1;
            drawTimer.Enabled = true;
            drawTimer.Tick += DrawTimer_Tick;
            gravityY /= 2;
            gravityX /= 2;
            clothDimentions[0]++;
            clothDimentions[1]++;
            Make();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            splitContainer1.Panel1, new object[] { true });
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            clothPoint p = clothpoints[closestpoint[0]][closestpoint[1]];
                p.prevX = p.X;
                p.prevY = p.Y;
                p.X = mouse.X;
                p.Y = mouse.Y;
                clothpoints[closestpoint[0]][closestpoint[1]] = p;
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            splitContainer1.Panel1.Invalidate();
        }

        private void Make()
        {
            clothpoints = new clothPoint[clothDimentions[1]][];
            for (int i = 0; i < clothDimentions[1]; i++)
            {
                clothpoints[i] = new clothPoint[clothDimentions[0]];
                for (int j = 0; j < clothDimentions[0]; j++)
                {
                    bool isstatic = j == 0;
                    clothpoints[i][j] = new clothPoint(i * (PPU + (isstatic ? stretch : 0)) + padding, j * (PPU + (isstatic ? stretch : 0)) + padding, padding, isstatic);
                }
            }
        }
        private void updatePoints()
        {
            for (int i = 0; i < clothDimentions[1]; i++)
            {
                for (int j = 0; j < clothDimentions[0]; j++)
                {
                    var point = clothpoints[i][j];
                    if (point.isStatic)
                        continue;
                    double velX = point.X - point.prevX;
                    double velY = point.Y - point.prevY;
                    point.prevX = point.X;
                    point.prevY = point.Y;
                    point.X += (velX + gravityX) * 0.955;
                    point.Y += (velY + gravityY) * 0.955;
                    //var abovePoint = clothpoints[(i - 1) * clothDimentions[0] + j];
                    //var rightPoint = clothpoints[i * clothDimentions[0] + j + 1];
                    //var belowPoint = clothpoints[(i + 1) * clothDimentions[0] + j];
                    //var leftPoint = clothpoints[i * clothDimentions[0] + j - 1];
                    List<clothPoint> nearbyPoints = new List<clothPoint>(4)
                    { null, null, null, null};
                    if (i > 0)
                    {
                        nearbyPoints[0] = clothpoints[i - 1][j];
                    }
                    if (j + 1 < clothDimentions[0])
                    {
                        nearbyPoints[1] = clothpoints[i][j + 1];
                    }
                    if (i + 1 < clothDimentions[1])
                    {
                        nearbyPoints[2] = clothpoints[i + 1][j];
                    }
                    if (j > 0)
                    {
                        nearbyPoints[3] = clothpoints[i][j - 1];
                    }
                    for (int k = 0; k < nearbyPoints.Count; k++)
                    {
                        if (nearbyPoints[k] == null)
                            continue;
                        double diffX = point.X - nearbyPoints[k].X;
                        double diffY = point.Y - nearbyPoints[k].Y;
                        var sqrDist = diffX * diffX + diffY * diffY;
                        if (sqrDist > PPU * PPU)
                        {
                            double diff = Math.Sqrt(sqrDist);
                            double difference = diff != 0 ? (PPU - diff) / diff : 0;
                            double translateX = diffX * 0.48 * difference;
                            double translateY = diffY * 0.48 * difference;
                            if (!nearbyPoints[k].isStatic)
                            {
                                point.X += translateX;
                                point.Y += translateY;
                                nearbyPoints[k].X -= translateX;
                                nearbyPoints[k].Y -= translateY;
                            }
                            else
                            {
                                point.X += 2 * translateX;
                                point.Y += 2 * translateY;
                            }
                        }
                    }
                    clothpoints[i][j] = point;
                    if (nearbyPoints[0] != null)
                        clothpoints[i - 1][j] = nearbyPoints[0];
                    if (nearbyPoints[1] != null)
                        clothpoints[i][j + 1] = nearbyPoints[1];
                    if (nearbyPoints[2] != null)
                        clothpoints[i + 1][j] = nearbyPoints[2];
                    if (nearbyPoints[3] != null)
                        clothpoints[i][j - 1] = nearbyPoints[3];
                }
            }
        }
        //private void draw()
        //{
        //    canvas.Dispose();
        //    canvas = new Bitmap(10000, 10000);
        //    for (int i = 0; i < clothDimentions[1]; i++)
        //    {
        //        for (int j = 0; j < clothDimentions[0]; j++)
        //        {
        //            clothPoint t = clothpoints[i * clothDimentions[0] + j];

        //            //if (t.X > 0 && t.Y > 0)
        //            //    canvas.SetPixel((int)Math.Abs(t.X), (int)Math.Abs(t.Y), Color.Black);
        //        }
        //    }
        //}

        private void _Paint(object sender, PaintEventArgs e)
        {
            updatePoints();
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), ClientRectangle);
            for (int i = 0; i < clothDimentions[1]; i++)
            {
                for (int j = 0; j < clothDimentions[0]; j++)
                {
                    clothPoint t = clothpoints[i][j];
                    if (gridCheckbox.Checked)
                    {
                        if (j + 1 < clothDimentions[0])
                        {
                            e.Graphics.DrawLine(new Pen(clothColor), (int)t.X, (int)t.Y, (int)clothpoints[i][j + 1].X, (int)clothpoints[i][j + 1].Y);
                        }
                        if (i + 1 < clothDimentions[1])
                        {
                            e.Graphics.DrawLine(new Pen(clothColor), (int)t.X, (int)t.Y, (int)clothpoints[i + 1][j].X, (int)clothpoints[i + 1][j].Y);
                        }
                    }
                    else if (pointsCheckbox.Checked)
                    {
                            e.Graphics.FillEllipse(new SolidBrush(clothColor), t.getPointF().X, t.getPointF().Y/*(int)clothpoints[i][j].X, (int)clothpoints[i][j].Y*/, 2, 2);
                    }
                }
            }
        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            clickTimer.Enabled = true;
            mouse = e.Location;

            double distance = 100000;
            for (int i = 0; i < clothDimentions[1]; i++)
            {
                for (int j = 0; j < clothDimentions[0]; j++)
                {
                    clothPoint t = clothpoints[i][j];
                    if (t.distanceFrom(mouse) < distance && !t.isStatic)
                    {
                        distance = t.distanceFrom(mouse);
                        closestpoint = new[] { i, j };
                    }
                }
            }
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            clickTimer.Enabled = false;
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
            mouse = e.Location;
        }

        private void lengthChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(widthTextbox.Text, out value))
            {
                widthTextbox.Text = string.Empty;
                widthTextbox.Focus();
                return;
            }
            clothDimentions[1] = value + 1;
            Make();
        }

        private void widthChanged(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(heightTextbox.Text, out value))
            {
                heightTextbox.Text = string.Empty;
                heightTextbox.Focus();
                return;
            }
            clothDimentions[0] = value + 1;
            Make();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            clothColor = colorDialog1.Color;
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            backgroundColor = colorDialog1.Color;
        }

        private void pointsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (pointsCheckbox.Checked)
            {
                gridCheckbox.Checked = false;
            }
        }

        private void gridCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (gridCheckbox.Checked)
            {
                pointsCheckbox.Checked = false;
            }
        }

        private void gravitySlider_Scroll(object sender, EventArgs e)
        {
            gravityY = gravitySlider.Value / 8.0;
        }
        
        }
    }
    public class clothPoint
    {
        public double X;
        public double Y;
        public double prevX;
        public double prevY;
        public bool isStatic;
        public clothPoint(double x, double y, double z, bool isStatic)
        {
            this.isStatic = isStatic;
            X = prevX = x;
            Y = prevY = y;
        }
        public double distanceFrom(clothPoint other_point)
        {
            return Math.Sqrt(Math.Pow(other_point.X - this.X, 2) + Math.Pow(other_point.Y - this.Y, 2));
        }
        public double distanceFrom(Point other_point)
        {
            return Math.Sqrt(Math.Pow(other_point.X - this.X, 2) + Math.Pow(other_point.Y - this.Y, 2));
        }
        public PointF getPointF()
        {
            return new PointF((int)X, (int)Y);
        }

    }
