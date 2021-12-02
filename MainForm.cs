using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Maxwell_Wheel
{

    public partial class MainForm : Form
    {

        float rtri = 0;
        float rtry = 0.0f;
        bool flag = false;
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Width - this.sidePanel.Location.X == constants.side_Panel_Size)
            {
                this.sidePanel.Left = this.Width - this.Width / 4;
                this.sidePanel.Size = new Size(this.Width / 4, this.Height);
                this.sidePanelButton.Location = new Point(this.sidePanelButton.Location.X, this.Height / 2);
                this.sidePanelButton.Text = ">>";

            }
            else if (this.Width - this.sidePanel.Location.X != constants.side_Panel_Size)
            {
                this.sidePanel.Left = this.Width - constants.side_Panel_Size;
                this.sidePanel.Size = new Size(this.Width / 4, this.Height);
                this.sidePanelButton.Location = new Point(this.sidePanelButton.Location.X, this.Height / 2);
                this.sidePanelButton.Text = "<<";
            }
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs e)
        {
            //  Get the OpenGL object, just to clean up the code.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(SharpGL.OpenGL.GL_COLOR_BUFFER_BIT | SharpGL.OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            gl.LoadIdentity();                  // Reset The View

            // gl.Color(1.0f, 1.0f, 1.0f);
            // gl.FontBitmaps.DrawText(gl, 0, 0, "Arial", "Argh");



            gl.Translate(-1.5f, 0.0f, -6.0f);				// Move Left And Into The Screen

            gl.Rotate(rtri, 0.0f, 1.0f, 0.0f);				// Rotate The Pyramid On It's Y Axis

            gl.Begin(SharpGL.OpenGL.GL_TRIANGLES);					// Start Drawing The Pyramid

            gl.Color(1.0f, 0.0f, 0.0f);			// Red
            gl.Vertex(0.0f, 1.0f + rtry, 0.0f);			// Top Of Triangle (Front)
            gl.Color(0.0f, 1.0f, 0.0f);			// Green
            gl.Vertex(-1.0f, -1.0f + rtry, 1.0f);			// Left Of Triangle (Front)
            gl.Color(0.0f, 0.0f, 1.0f);			// Blue
            gl.Vertex(1.0f, -1.0f + rtry, 1.0f);			// Right Of Triangle (Front)

            gl.Color(1.0f, 0.0f, 0.0f);			// Red
            gl.Vertex(0.0f, 1.0f + rtry, 0.0f);			// Top Of Triangle (Right)
            gl.Color(0.0f, 0.0f, 1.0f);			// Blue
            gl.Vertex(1.0f, -1.0f + rtry, 1.0f);			// Left Of Triangle (Right)
            gl.Color(0.0f, 1.0f, 0.0f);			// Green
            gl.Vertex(1.0f, -1.0f + rtry, -1.0f);			// Right Of Triangle (Right)

            gl.Color(1.0f, 0.0f, 0.0f);			// Red
            gl.Vertex(0.0f, 1.0f + rtry, 0.0f);			// Top Of Triangle (Back)
            gl.Color(0.0f, 1.0f, 0.0f);			// Green
            gl.Vertex(1.0f, -1.0f + rtry, -1.0f);			// Left Of Triangle (Back)
            gl.Color(0.0f, 0.0f, 1.0f);			// Blue
            gl.Vertex(-1.0f, -1.0f + rtry, -1.0f);			// Right Of Triangle (Back)

            gl.Color(1.0f, 0.0f, 0.0f);			// Red
            gl.Vertex(0.0f, 1.0f + rtry, 0.0f);			// Top Of Triangle (Left)
            gl.Color(0.0f, 0.0f, 1.0f);			// Blue
            gl.Vertex(-1.0f, -1.0f + rtry, -1.0f);			// Left Of Triangle (Left)
            gl.Color(0.0f, 1.0f, 0.0f);			// Green
            gl.Vertex(-1.0f, -1.0f + rtry, 1.0f);			// Right Of Triangle (Left)
            gl.End();                       // Done Drawing The Pyramid



            gl.Flush();

            rtri += 3.0f;// 0.2f;						// Increase The Rotation Variable For The Triangle  
            if (flag) rtry += 0.1f; else rtry -= 0.1f;
            if (rtry >= 0.5f) flag = false;
            if (rtry <= -0.5f) flag = true;
        }



        //private void openGLControl1_Render(object sender, EventArgs e)
        //{

        //}
    }
}
