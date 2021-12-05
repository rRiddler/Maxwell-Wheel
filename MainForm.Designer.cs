
namespace Maxwell_Wheel
{
    partial class MainForm
    {
        public const float pi = 3.1415926f;
        public const float g = 9.80665f;
        static public float flag = 1;
        static public float k = momentInert / (wheelRad * wheelRad) + wheelMass;
        static public float a = -wheelMass * g / (k * 60);

        static public float hingeLength = 0.1f;
        static public float hingeRad = 0.005f;
        static public float hingeDense = aluminumDense;
        static public float hingeMass = hingeDense * pi * hingeRad * hingeRad * hingeLength;

        static public bool toWork = false;

        static public float plasticDense = 1800;
        static public float steelDense = 7700;
        static public float aluminumDense = 2800;
        static public float height = stringLength - stringLengthMin;
        static public float heightMax = stringLengthMax;
        static public float stringLength = 0;
        static public float stringLengthMax = 1; //most low point
        static public float stringLengthMin = wheelRad + 0.01f; //top point
        static public float wheelRad = 0.05f;
        static public float wheelWidth = 0.02f;
        static public float wheelDense = 7700f;
        static public float wheelMass = pi * wheelRad * wheelRad * wheelDense * wheelWidth;
        static public float momentInert = wheelMass * (wheelRad * wheelRad / 4 + wheelWidth * wheelWidth / 12) + hingeMass * (hingeRad * hingeRad / 4 + hingeLength * hingeLength / 12);
        static public float energyFull = wheelMass * g * heightMax;
        static public float energyPotential = wheelMass * g * height;
        static public float energyKinetic = energyFull - energyPotential;
        static public float velocity = 0;
        static public float w = velocity * 180 / (wheelRad * pi);
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSheetSidePanel = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericUpDownWheelRad = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWheelWidth = new System.Windows.Forms.NumericUpDown();
            this.numericStringLength = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.sidePanelButton = new System.Windows.Forms.Button();
            this.mainScene = new SharpGL.SceneControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tabSheetSidePanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWheelRad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWheelWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStringLength)).BeginInit();
            this.sidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainScene)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSheetSidePanel
            // 
            this.tabSheetSidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSheetSidePanel.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabSheetSidePanel.Controls.Add(this.tabPage1);
            this.tabSheetSidePanel.Controls.Add(this.tabPage2);
            this.tabSheetSidePanel.Location = new System.Drawing.Point(12, 8);
            this.tabSheetSidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.tabSheetSidePanel.Name = "tabSheetSidePanel";
            this.tabSheetSidePanel.SelectedIndex = 0;
            this.tabSheetSidePanel.Size = new System.Drawing.Size(150, 670);
            this.tabSheetSidePanel.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonStop);
            this.tabPage1.Controls.Add(this.buttonStart);
            this.tabPage1.Controls.Add(this.numericUpDownWheelRad);
            this.tabPage1.Controls.Add(this.numericUpDownWheelWidth);
            this.tabPage1.Controls.Add(this.numericStringLength);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(142, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(33, 360);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(33, 234);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericUpDownWheelRad
            // 
            this.numericUpDownWheelRad.DecimalPlaces = 2;
            this.numericUpDownWheelRad.Increment = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            this.numericUpDownWheelRad.Location = new System.Drawing.Point(12, 67);
            this.numericUpDownWheelRad.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            this.numericUpDownWheelRad.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            this.numericUpDownWheelRad.Name = "numericUpDownWheelRad";
            this.numericUpDownWheelRad.Size = new System.Drawing.Size(104, 20);
            this.numericUpDownWheelRad.TabIndex = 2;
            this.numericUpDownWheelRad.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            this.numericUpDownWheelRad.ValueChanged += new System.EventHandler(this.numericUpDownWheelRad_ValueChanged);
            // 
            // numericUpDownWheelWidth
            // 
            this.numericUpDownWheelWidth.DecimalPlaces = 2;
            this.numericUpDownWheelWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            196608});
            this.numericUpDownWheelWidth.Location = new System.Drawing.Point(12, 125);
            this.numericUpDownWheelWidth.Maximum = new decimal(new int[] {
            0,
            8,
            0,
            65536});
            this.numericUpDownWheelWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownWheelWidth.Name = "numericUpDownWheelWidth";
            this.numericUpDownWheelWidth.Size = new System.Drawing.Size(104, 20);
            this.numericUpDownWheelWidth.TabIndex = 1;
            this.numericUpDownWheelWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownWheelWidth.ValueChanged += new System.EventHandler(this.numericUpDownWheelWidth_ValueChanged);
            // 
            // numericStringLength
            // 
            this.numericStringLength.DecimalPlaces = 2;
            this.numericStringLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericStringLength.Location = new System.Drawing.Point(12, 23);
            this.numericStringLength.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            65536});
            this.numericStringLength.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numericStringLength.Name = "numericStringLength";
            this.numericStringLength.Size = new System.Drawing.Size(104, 20);
            this.numericStringLength.TabIndex = 0;
            this.numericStringLength.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numericStringLength.ValueChanged += new System.EventHandler(this.numericStringLength_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(142, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sidePanel
            // 
            this.sidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sidePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.sidePanel.Controls.Add(this.sidePanelButton);
            this.sidePanel.Controls.Add(this.tabSheetSidePanel);
            this.sidePanel.Location = new System.Drawing.Point(1102, -1);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(2);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(164, 680);
            this.sidePanel.TabIndex = 1;
            // 
            // sidePanelButton
            // 
            this.sidePanelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sidePanelButton.Location = new System.Drawing.Point(-5, 360);
            this.sidePanelButton.Margin = new System.Windows.Forms.Padding(2);
            this.sidePanelButton.Name = "sidePanelButton";
            this.sidePanelButton.Size = new System.Drawing.Size(25, 19);
            this.sidePanelButton.TabIndex = 1;
            this.sidePanelButton.Text = ">>";
            this.sidePanelButton.UseVisualStyleBackColor = true;
            this.sidePanelButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainScene
            // 
            this.mainScene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainScene.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainScene.DrawFPS = true;
            this.mainScene.FrameRate = 120;
            this.mainScene.Location = new System.Drawing.Point(0, -1);
            this.mainScene.Name = "mainScene";
            this.mainScene.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.mainScene.RenderContextType = SharpGL.RenderContextType.FBO;
            this.mainScene.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.mainScene.Size = new System.Drawing.Size(1266, 680);
            this.mainScene.TabIndex = 2;
            this.mainScene.OpenGLDraw += new SharpGL.RenderEventHandler(this.mainScene_Draw);
            this.mainScene.Load += new System.EventHandler(this.mainScene_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.mainScene);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Maxwell\'s Wheel Virtual Laboratory";
            this.tabSheetSidePanel.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWheelRad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWheelWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStringLength)).EndInit();
            this.sidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainScene)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSheetSidePanel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button sidePanelButton;
        private SharpGL.SceneControl mainScene;
        private System.Windows.Forms.NumericUpDown numericUpDownWheelWidth;
        private System.Windows.Forms.NumericUpDown numericStringLength;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.NumericUpDown numericUpDownWheelRad;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
    }
}

