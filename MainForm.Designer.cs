
namespace Maxwell_Wheel
{
    partial class MainForm
    {
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.sidePanelButton = new System.Windows.Forms.Button();
            this.mainScene = new SharpGL.SceneControl();
            this.tabSheetSidePanel.SuspendLayout();
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
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(142, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.mainScene.FrameRate = 144;
            this.mainScene.Location = new System.Drawing.Point(0, 0);
            this.mainScene.Name = "mainScene";
            this.mainScene.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.mainScene.RenderContextType = SharpGL.RenderContextType.FBO;
            this.mainScene.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.mainScene.Size = new System.Drawing.Size(1280, 720);
            this.mainScene.TabIndex = 2;
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
    }
}

