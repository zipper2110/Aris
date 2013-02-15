using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Aris_app
{
    public partial class Form1 : Form
    {
        private decimal t1 = 0;
        private decimal t2 = 0;
        private decimal t3 = 0;
        private decimal t4 = 0;
        private decimal ts = 0;

        int box1Width = 0;
        int box2Width = 0;
        int box3Width = 0;
        int box4Width = 0;

        Graphics canvas;
        Brush brush;

        int boxWidth = 450;
        int boxHeight = 50;
        Point box1Point = new Point(30, 50);
        Point box2Point = new Point(30, 150);
        Point box3Point = new Point(30, 250);
        Point box4Point = new Point(30, 350);
        Point box5Point = new Point(30, 450);

        DateTime startTime;
        Decimal periodTime;
        TimeSpan timeDif = new TimeSpan();

        int runningState = 3;
        int timeInPeriod = 0;
        Thread runningThread = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runningState = 1;

            if (runningThread != null && runningThread.ThreadState == ThreadState.Suspended)
            {
                runningState = 1;
                startTime = new DateTime(DateTime.Now.Ticks - timeDif.Ticks);
                redrawTemplate(this, null);
                runningThread.Resume();
            }
            else
            {
                startTime = DateTime.Now;
                periodTime = (numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value + numericUpDown4.Value) * 1000;
                runningThread = new Thread(new ThreadStart(refreshThread));
                runningThread.Start();
            }
        }

        private void pause_Click(object sender, EventArgs e)
        {
            pause();
        }

        private void redrawTemplate(object sender, EventArgs e)
        {
            brush = new SolidBrush(Color.FromArgb(40, 160, 255));
            t1 = numericUpDown1.Value;
            t2 = numericUpDown2.Value;
            t3 = numericUpDown3.Value;
            t4 = numericUpDown4.Value;
            ts = numericUpDown5.Value;
            Pen pen = new Pen(Color.FromArgb(0, 0, 0), 2);
            canvas = splitContainer1.Panel2.CreateGraphics();
            /*canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;*/
            canvas.Clear(Color.White);
            /* box1 */
            if (t1 == 0)
            {
                pen.Color = Color.LightGray;
            }
            else
            {
                pen.Color = Color.Black;
            }
            canvas.DrawRectangle(pen, box1Point.X, box1Point.Y, boxWidth, boxHeight);
            for (int i = 0; i < t1 - 1; i++)
            {
                canvas.DrawLine(pen, (float)(box1Point.X + ((boxWidth / t1) * (i + 1))), box1Point.Y, (float)(box1Point.X + ((boxWidth / t1) * (i + 1))), box1Point.Y + boxHeight);
            }
            /* box2 */
            if (t2 == 0)
            {
                pen.Color = Color.LightGray;
            }
            else
            {
                pen.Color = Color.Black;
            }
            canvas.DrawRectangle(pen, box2Point.X, box2Point.Y, boxWidth, boxHeight);
            for (int i = 0; i < t2 - 1; i++)
            {
                canvas.DrawLine(pen, (float)(box2Point.X + ((boxWidth / t2) * (i + 1))), box2Point.Y, (float)(box2Point.X + ((boxWidth / t2) * (i + 1))), box2Point.Y + boxHeight);
            }
            /* box3 */
            if (t3 == 0)
            {
                pen.Color = Color.LightGray;
            }
            else
            {
                pen.Color = Color.Black;
            }
            canvas.DrawRectangle(pen, box3Point.X, box3Point.Y, boxWidth, boxHeight);
            for (int i = 0; i < t3 - 1; i++)
            {
                canvas.DrawLine(pen, (float)(box3Point.X + ((boxWidth / t3) * (i + 1))), box3Point.Y, (float)(box3Point.X + ((boxWidth / t3) * (i + 1))), box3Point.Y + boxHeight);
            }
            /* box4 */
            if (t4 == 0)
            {
                pen.Color = Color.LightGray;
            }
            else
            {
                pen.Color = Color.Black;
            }
            canvas.DrawRectangle(pen, box4Point.X, box4Point.Y, boxWidth, boxHeight);
            for (int i = 0; i < t4 - 1; i++)
            {
                canvas.DrawLine(pen, (float)(box4Point.X + ((boxWidth / t4) * (i + 1))), box4Point.Y, (float)(box4Point.X + ((boxWidth / t4) * (i + 1))), box4Point.Y + boxHeight);
            }
            /* box5 */
            if (ts == 0)
            {
                pen.Color = Color.LightGray;
            }
            else
            {
                pen.Color = Color.Black;
            }
            canvas.DrawRectangle(pen, box5Point.X, box5Point.Y, boxWidth, boxHeight);
        }

        private void refreshThread() 
        {
            while (runningState == 1)
            {
                refresh();
            }
        }

        private void refresh()
        {
            int w1 = 0;
            int w2 = 0;
            int w3 = 0;
            int w4 = 0;
            int w5 = 0;
            timeDif = DateTime.Now - startTime;
            if ((int)timeDif.TotalMilliseconds == 0) return;
            
            int currentPeriodTime = (int) ((int) timeDif.TotalMilliseconds % periodTime);
            int currentPeriodTime2 = currentPeriodTime;
            //Console.WriteLine(currentPeriodTime);
            if (currentPeriodTime < (int) (t1 * 1000))
            {
                w1 = (int)(boxWidth * currentPeriodTime / (t1 * 1000));
            }
            else
            {
                w1 = boxWidth;
                currentPeriodTime -= (int)(t1 * 1000);
                if (currentPeriodTime < (int)(t2 * 1000))
                {
                    w2 = (int)(boxWidth * currentPeriodTime / (t2 * 1000));
                }
                else
                {
                    w2 = boxWidth;
                    currentPeriodTime -= (int)(t2 * 1000);
                    if (currentPeriodTime < (int)(t3 * 1000))
                    {
                        w3 = (int)(boxWidth * currentPeriodTime / (t3 * 1000));
                    }
                    else
                    {
                        w3 = boxWidth;
                        currentPeriodTime -= (int)(t3 * 1000);
                        if (currentPeriodTime < (int)(t4 * 1000))
                        {
                            w4 = (int)(boxWidth * currentPeriodTime / (t4 * 1000));
                        }
                        else
                        {
                            Console.WriteLine("error, time more than period");
                            Console.WriteLine((int)((int)timeDif.TotalMilliseconds % periodTime));
                        }
                    }
                }
            }
            if (w1 != box1Width && t1 > 0)
            {
                canvas.FillRectangle(brush, box1Point.X, box1Point.Y, w1, boxHeight);
                box1Width = w1;
            }
            if (w2 != box2Width && t2 > 0)
            {
                canvas.FillRectangle(brush, box2Point.X, box2Point.Y, w2, boxHeight);
                box1Width = w2;
            }
            if (w3 != box3Width && t3 > 0)
            {
                canvas.FillRectangle(brush, box3Point.X, box3Point.Y, w3, boxHeight);
                box1Width = w3;
            }
            if (w4 != box4Width && t4 > 0)
            {
                canvas.FillRectangle(brush, box4Point.X, box4Point.Y, w4, boxHeight);
                box1Width = w4;
            }
            if ((decimal)timeDif.TotalMilliseconds > ts * 1000)
            {
                stop();
            }
            else
            {
                canvas.FillRectangle(brush, box5Point.X, box5Point.Y, (int) (boxWidth * (int) timeDif.TotalMilliseconds / (ts * 1000)), boxHeight);
            }
            if (currentPeriodTime2 < timeInPeriod)
            {
                reset();
            }
            timeInPeriod = currentPeriodTime2;
            System.Threading.Thread.Sleep(10);
        }

        private void pause()
        {
            runningThread.Suspend();
            runningState = 2;
        }

        private void stop()
        {
            runningState = 3;
            reset();
            redrawTemplate(this, null);
        }

        private void reset() 
        {
            redrawTemplate(this, null);
            box1Width = 0;
            box2Width = 0;
            box3Width = 0;
            box4Width = 0;
            timeDif = new TimeSpan();
            timeInPeriod = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop();
        }
    }
}
