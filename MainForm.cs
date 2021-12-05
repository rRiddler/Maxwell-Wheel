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
using System.Runtime;

namespace Maxwell_Wheel
{
    public partial class MainForm : Form
    {
        private readonly ArcBallEffect arcBallEffect = new ArcBallEffect();




        public MainForm()
        {
            height = stringLength - stringLengthMin;
            heightMax = stringLengthMax;
            stringLength = 0;
            stringLengthMax = 1; //most low point
            stringLengthMin = wheelRad + 0.01f; //top point
            wheelRad = 0.004f;
            wheelWidth = 0.04f;
            wheelDense = plasticDense;
            wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
            momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
            energyFull = wheelMass * g * heightMax;
            energyPotential = wheelMass * g * height;
            energyKinetic = energyFull - energyPotential;
            velocity = 0;
            w = velocity * 180 / (wheelRad * pi);


            k = momentInert / (wheelRad * wheelRad) + wheelMass;
            a = -wheelMass * g / (k * 360);

            InitializeComponent();
            InitializeScene();
            this.CenterToScreen();
        }

        private void InitializeScene()
        {
            mainScene.Scene.RenderBoundingVolumes = false;
            mainScene.MouseDown += new MouseEventHandler(sceneControl_MouseDown);
            mainScene.MouseMove += new MouseEventHandler(sceneControl_MouseMove);
            mainScene.MouseUp += new MouseEventHandler(sceneControl_MouseUp);

            // Let's load project
            var obj = new ObjFileFormat();
            var objWheel = obj.LoadData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "Wheel.obj"));
            var objBase = obj.LoadData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "Only base.obj"));
            var objStrings = obj.LoadData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "Strings.obj"));
            // Add the materials to the scene
            foreach (var asset in objWheel.Assets)
                mainScene.Scene.Assets.Add(asset);
            foreach (var asset in objBase.Assets)
                mainScene.Scene.Assets.Add(asset);
            foreach (var asset in objStrings.Assets)
                mainScene.Scene.Assets.Add(asset);

            // Get the polygons
            var polygonsWheel = objWheel.SceneContainer.Traverse<Polygon>().ToList();
            var polygonsBase = objBase.SceneContainer.Traverse<Polygon>().ToList();
            var polygonsStrings = objStrings.SceneContainer.Traverse<Polygon>().ToList();

            // Add each polygon (There is only one in ducky.obj)
            foreach (var polygon in polygonsWheel)
            {
                polygon.Name = "Wheel";
                polygon.Transformation.RotateX = 90f; // So that Ducky appears in the right orientation

                // Scale so that we are at most 10 units in size.
                var scaleFactor = 0.2f;

                polygon.Parent.RemoveChild(polygon);
                polygon.Transformation.TranslateZ = 8f;
                polygon.Transformation.ScaleX = scaleFactor;
                polygon.Transformation.ScaleY = scaleFactor;
                polygon.Transformation.ScaleZ = scaleFactor;
                polygon.Freeze(mainScene.OpenGL);
                mainScene.Scene.SceneContainer.AddChild(polygon);

                // Add effects.
                polygon.AddEffect(new OpenGLAttributesEffect());
                polygon.AddEffect(arcBallEffect);
            }

            foreach (var polygon in polygonsBase)
            {
                polygon.Name = "Base";
                polygon.Transformation.RotateX = 90; // So that Ducky appears in the right orientation

                // Scale so that we are at most 10 units in size.
                var scaleFactor = 0.2f;

                polygon.Parent.RemoveChild(polygon);
                polygon.Transformation.TranslateX = -0;
                polygon.Transformation.TranslateY = -0;
                polygon.Transformation.TranslateZ = 4f;
                polygon.Transformation.ScaleX = scaleFactor;
                polygon.Transformation.ScaleY = scaleFactor;
                polygon.Transformation.ScaleZ = scaleFactor;
                polygon.Freeze(mainScene.OpenGL);
                mainScene.Scene.SceneContainer.AddChild(polygon);
                float alf = polygon.Transformation.ScaleZ;
                SharpGL.SceneGraph.Vertex bet = polygon.Transformation.TranslationVertex;
                // Add effects.
                polygon.AddEffect(new OpenGLAttributesEffect());
                polygon.AddEffect(arcBallEffect);
            }

            foreach (var polygon in polygonsStrings)
            {
                polygon.Name = "Strings";
                polygon.Transformation.RotateX = 90f; // So that Ducky appears in the right orientation

                // Scale so that we are at most 10 units in size.
                var scaleFactor = 0.2f;

                polygon.Parent.RemoveChild(polygon);
                polygon.Transformation.TranslateZ = 8f;
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

        private void mainScene_Draw(object sender, SharpGL.RenderEventArgs args)
        {
            if (toWork)
            {
                var polygonsWheel = mainScene.Scene.SceneContainer.Traverse<Polygon>().Where<Polygon>(x => x.Name == "Wheel").ToList();
                var polygonsStrings = mainScene.Scene.SceneContainer.Traverse<Polygon>().Where<Polygon>(x => x.Name == "Strings").ToList();
                bool skip = false;
                energyPotential = wheelMass * height * g;
                energyKinetic = energyFull - energyPotential;
                velocity += a;
                stringLength -= velocity;
                height = stringLengthMax - stringLength;
                if (stringLength >= stringLengthMax)
                {
                    
                    foreach (var polygon in polygonsWheel)
                    {
                        //polygon.Transformation.TranslateZ += ((velocity  + (stringLength - stringLengthMax)) * 6 + (stringLength - stringLengthMax)) * 0.95f;
                        polygon.Transformation.TranslateZ += ((velocity + (stringLength - stringLengthMax)) + (stringLength - stringLengthMax))*6; //ITWORKS DONT TOUCH
                    }
                    foreach (var polygon in polygonsStrings)
                    {
                        polygon.Transformation.TranslateZ += ((velocity + (stringLength - stringLengthMax)) + (stringLength - stringLengthMax) * 0.95f)*6; //ITWORKS DONT TOUCH
                    }
                    flag *= -1;
                    velocity *= -0.95f;
                    //velocity += a*()
                    skip = true;
                    if (velocity < 0.002f && velocity > -0.002f)
                    {
                        velocity = 0;
                        a = 0;
                    }
                    stringLength = 2 * stringLengthMax - stringLength;
                }
                w = 180f * flag * velocity / wheelRad / pi;

                //wheel
                foreach (var polygon in polygonsWheel)
                {
                    polygon.Transformation.RotateX += w / 60;
                    if (!skip)
                        polygon.Transformation.TranslateZ += velocity*6;
                }

                //strings
                foreach (var polygon in polygonsStrings)
                {
                    if (!skip)
                        polygon.Transformation.TranslateZ += velocity*6;
                }
            }
        }

        private void mainScene_Load(object sender, EventArgs e)
        {

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

        private void numericStringLength_ValueChanged(object sender, EventArgs e)
        {
            stringLengthMax = (float)numericStringLength.Value;

            height = stringLength - stringLengthMin;
            heightMax = stringLengthMax;
            stringLengthMin = wheelRad + 0.01f; //top point
            wheelDense = plasticDense;
            wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
            momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
            energyFull = wheelMass * g * heightMax;
            energyPotential = wheelMass * g * height;
            energyKinetic = energyFull - energyPotential;
            velocity = 0;
            w = velocity * 180 / (wheelRad * pi);


            k = momentInert / (wheelRad * wheelRad) + wheelMass;
            a = -wheelMass * g / (k * 360);
        }

        private void numericUpDownWheelWidth_ValueChanged(object sender, EventArgs e)
        {
            wheelWidth = (float)numericUpDownWheelWidth.Value;

            height = stringLength - stringLengthMin;
            heightMax = stringLengthMax;
            stringLengthMin = wheelRad + 0.01f; //top point
            wheelDense = plasticDense;
            wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
            momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
            energyFull = wheelMass * g * heightMax;
            energyPotential = wheelMass * g * height;
            energyKinetic = energyFull - energyPotential;
            velocity = 0;
            w = velocity * 180 / (wheelRad * pi);


            k = momentInert / (wheelRad * wheelRad) + wheelMass;
            a = -wheelMass * g / (k * 360);
        }

        private void numericUpDownWheelRad_ValueChanged(object sender, EventArgs e)
        {
            wheelRad = (float)numericUpDownWheelRad.Value;

            height = stringLength - stringLengthMin;
            heightMax = stringLengthMax;
            stringLengthMin = wheelRad + 0.01f; //top point
            wheelDense = plasticDense;
            wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
            momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
            energyFull = wheelMass * g * heightMax;
            energyPotential = wheelMass * g * height;
            energyKinetic = energyFull - energyPotential;
            velocity = 0;
            w = velocity * 180 / (wheelRad * pi);


            k = momentInert / (wheelRad * wheelRad) + wheelMass;
            a = -wheelMass * g / (k * 360);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (toWork) { buttonStart.Text = "Start"; toWork = false; }
            else { buttonStart.Text = "Pause"; toWork = true; }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            toWork = false;

            stringLengthMax = (float)numericStringLength.Value;
            wheelWidth = (float)numericUpDownWheelWidth.Value;
            wheelRad = (float)numericUpDownWheelRad.Value;

            height = stringLength - stringLengthMin;
            heightMax = stringLengthMax;
            stringLength = 0;
            stringLengthMin = wheelRad + 0.01f; //top point
            wheelDense = plasticDense;
            wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
            momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
            energyFull = wheelMass * g * heightMax;
            energyPotential = wheelMass * g * height;
            energyKinetic = energyFull - energyPotential;
            velocity = 0;
            w = velocity * 180 / (wheelRad * pi);


            k = momentInert / (wheelRad * wheelRad) + wheelMass;
            a = -wheelMass * g / (k * 360);

            var polygonsWheel = mainScene.Scene.SceneContainer.Traverse<Polygon>().Where<Polygon>(x => x.Name == "Wheel").ToList();
            var polygonsStrings = mainScene.Scene.SceneContainer.Traverse<Polygon>().Where<Polygon>(x => x.Name == "Strings").ToList();

            foreach (var polygon in polygonsWheel)
            {
                polygon.Transformation.TranslateZ = 8f;
            }

            //strings
            foreach (var polygon in polygonsStrings)
            {
                polygon.Transformation.TranslateZ = 8f;
            }

        }
    }


}
