using System.Threading;
using System.Windows.Forms;
namespace Maxwell_Wheel
{
    partial class SplashScreen
    {
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static SplashScreen splashForm;

        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.    
            if (splashForm != null) return;
            splashForm = new SplashScreen();
            splashForm.FormBorderStyle = FormBorderStyle.None;
            Thread thread = new Thread(new ThreadStart(SplashScreen.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static public void ProgressTime()
        {
            for(int i = 0; i < 100; i += 10)
            {
                System.Threading.Thread.Sleep(500);
                splashForm.progressBar1.Invoke((MethodInvoker)delegate {
                    // Running on the UI thread
                    splashForm.progressBar1.Value = i;
                });
            }
        }

        static private void ShowForm()
        {
            if (splashForm != null) Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            splashForm?.Invoke(new CloseDelegate(SplashScreen.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            if (splashForm != null)
            {
                splashForm.Close();
                splashForm = null;
            };
        }
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Maxwell_Wheel.Properties.Resources.CityHerb_thing;
            this.pictureBox4.Location = new System.Drawing.Point(12, 157);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(179, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Maxwell_Wheel.Properties.Resources.FPMI_thing;
            this.pictureBox1.Location = new System.Drawing.Point(669, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Maxwell_Wheel.Properties.Resources.NSTU_thing;
            this.pictureBox2.Location = new System.Drawing.Point(143, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(564, 148);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Maxwell_Wheel.Properties.Resources.RussianHerb_thing;
            this.pictureBox3.Location = new System.Drawing.Point(197, 157);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(164, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 153);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сделано студентами \r\n2 курса ФПМИ НГТУ:\r\nМихайлов В.И.\r\nМищенко Д.А.\r\nБожков Е.С." +
    "\r\n\r\nНаучные руководители:\r\nБаранов X.X.\r\nТракимус Ю.В.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loading";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(345, 396);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Name = "SplashScreen";
            this.Text = "SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private ProgressBar progressBar1;
    }


}