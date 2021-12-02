using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL.SceneGraph.Effects;
using SharpGL.SceneGraph.Primitives;
using SharpGL.Serialization.Wavefront;


namespace Maxwell_Wheel
{

    public partial class MainForm : Form
    {

        private readonly ArcBallEffect arcBallEffect = new ArcBallEffect();

        public MainForm()
        {
            InitializeComponent();
            InitializeScene();
            this.CenterToScreen();
        }

        private void InitializeScene()
        {
            mainScene.MouseDown += new MouseEventHandler(sceneControl_MouseDown);
            mainScene.MouseMove += new MouseEventHandler(sceneControl_MouseMove);
            mainScene.MouseUp += new MouseEventHandler(sceneControl_MouseUp);
            // Let's load ducky
            var obj = new ObjFileFormat();
            var objScene = obj.LoadData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "Wheel.obj"));

            // Add the materials to the scene
            foreach (var asset in objScene.Assets)
                mainScene.Scene.Assets.Add(asset);

            // Get the polygons
            var polygons = objScene.SceneContainer.Traverse<Polygon>().ToList();

            // Add each polygon (There is only one in ducky.obj)
            foreach (var polygon in polygons)
            {
                polygon.Name = "Qube";
                polygon.Transformation.RotateX = 90f; // So that Ducky appears in the right orientation

                //  Get the bounds of the polygon.
                var boundingVolume = polygon.BoundingVolume;
                var extent = new float[3];
                polygon.BoundingVolume.GetBoundDimensions(out extent[0], out extent[1], out extent[2]);

                // Get the max extent.
                var maxExtent = extent.Max();

                // Scale so that we are at most 10 units in size.
                var scaleFactor = maxExtent > 10 ? 10.0f / maxExtent : 1;

                polygon.Parent.RemoveChild(polygon);
                polygon.Transformation.ScaleX = scaleFactor;
                polygon.Transformation.ScaleY = scaleFactor;
                polygon.Transformation.ScaleZ = scaleFactor;
                polygon.Freeze(mainScene.OpenGL);
                mainScene.Scene.SceneContainer.AddChild(polygon);

                // Add effects.
                polygon.AddEffect(new OpenGLAttributesEffect());
                polygon.AddEffect(arcBallEffect);
            }

        }

        private void sceneControl_MouseDown(object sender, MouseEventArgs e)
        {
            arcBallEffect.ArcBall.SetBounds(mainScene.Width, mainScene.Height);
            arcBallEffect.ArcBall.MouseDown(e.X, e.Y);
        }

        private void sceneControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                arcBallEffect.ArcBall.MouseMove(e.X, e.Y);
        }

        private void sceneControl_MouseUp(object sender, MouseEventArgs e)
        {
            arcBallEffect.ArcBall.MouseUp(e.X, e.Y);
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


    }
}
