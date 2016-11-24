namespace batAlgorithm
{
    partial class greedyCoin
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.terminatedPictureBox = new System.Windows.Forms.PictureBox();
            this.runningPictureBox = new System.Windows.Forms.PictureBox();
            this.waitPictureBox = new System.Windows.Forms.PictureBox();
            this.readyPictureBox = new System.Windows.Forms.PictureBox();
            this.newPictureBox = new System.Windows.Forms.PictureBox();
            this.admittedPictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.schedularPictureBox = new System.Windows.Forms.PictureBox();
            this.interruptPictureBox = new System.Windows.Forms.PictureBox();
            this.waitingPictureBox = new System.Windows.Forms.PictureBox();
            this.exitPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.terminatedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admittedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedularPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interruptPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Coin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(169, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // terminatedPictureBox
            // 
            this.terminatedPictureBox.Location = new System.Drawing.Point(580, 85);
            this.terminatedPictureBox.Name = "terminatedPictureBox";
            this.terminatedPictureBox.Size = new System.Drawing.Size(100, 50);
            this.terminatedPictureBox.TabIndex = 5;
            this.terminatedPictureBox.TabStop = false;
            // 
            // runningPictureBox
            // 
            this.runningPictureBox.Location = new System.Drawing.Point(472, 211);
            this.runningPictureBox.Name = "runningPictureBox";
            this.runningPictureBox.Size = new System.Drawing.Size(100, 50);
            this.runningPictureBox.TabIndex = 4;
            this.runningPictureBox.TabStop = false;
            // 
            // waitPictureBox
            // 
            this.waitPictureBox.Location = new System.Drawing.Point(379, 343);
            this.waitPictureBox.Name = "waitPictureBox";
            this.waitPictureBox.Size = new System.Drawing.Size(100, 50);
            this.waitPictureBox.TabIndex = 3;
            this.waitPictureBox.TabStop = false;
            // 
            // readyPictureBox
            // 
            this.readyPictureBox.Location = new System.Drawing.Point(282, 211);
            this.readyPictureBox.Name = "readyPictureBox";
            this.readyPictureBox.Size = new System.Drawing.Size(100, 50);
            this.readyPictureBox.TabIndex = 2;
            this.readyPictureBox.TabStop = false;
            // 
            // newPictureBox
            // 
            this.newPictureBox.Location = new System.Drawing.Point(112, 103);
            this.newPictureBox.Name = "newPictureBox";
            this.newPictureBox.Size = new System.Drawing.Size(100, 50);
            this.newPictureBox.TabIndex = 1;
            this.newPictureBox.TabStop = false;
            // 
            // admittedPictureBox
            // 
            this.admittedPictureBox.Location = new System.Drawing.Point(252, 126);
            this.admittedPictureBox.Name = "admittedPictureBox";
            this.admittedPictureBox.Size = new System.Drawing.Size(100, 50);
            this.admittedPictureBox.TabIndex = 7;
            this.admittedPictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(252, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 8;
            // 
            // schedularPictureBox
            // 
            this.schedularPictureBox.Location = new System.Drawing.Point(379, 257);
            this.schedularPictureBox.Name = "schedularPictureBox";
            this.schedularPictureBox.Size = new System.Drawing.Size(100, 50);
            this.schedularPictureBox.TabIndex = 9;
            this.schedularPictureBox.TabStop = false;
            // 
            // interruptPictureBox
            // 
            this.interruptPictureBox.Location = new System.Drawing.Point(379, 142);
            this.interruptPictureBox.Name = "interruptPictureBox";
            this.interruptPictureBox.Size = new System.Drawing.Size(100, 50);
            this.interruptPictureBox.TabIndex = 10;
            this.interruptPictureBox.TabStop = false;
            // 
            // waitingPictureBox
            // 
            this.waitingPictureBox.Location = new System.Drawing.Point(485, 295);
            this.waitingPictureBox.Name = "waitingPictureBox";
            this.waitingPictureBox.Size = new System.Drawing.Size(100, 50);
            this.waitingPictureBox.TabIndex = 11;
            this.waitingPictureBox.TabStop = false;
            // 
            // exitPictureBox
            // 
            this.exitPictureBox.Location = new System.Drawing.Point(526, 142);
            this.exitPictureBox.Name = "exitPictureBox";
            this.exitPictureBox.Size = new System.Drawing.Size(100, 50);
            this.exitPictureBox.TabIndex = 12;
            this.exitPictureBox.TabStop = false;
            // 
            // greedyCoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 405);
            this.Controls.Add(this.exitPictureBox);
            this.Controls.Add(this.waitingPictureBox);
            this.Controls.Add(this.interruptPictureBox);
            this.Controls.Add(this.schedularPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.admittedPictureBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.terminatedPictureBox);
            this.Controls.Add(this.runningPictureBox);
            this.Controls.Add(this.waitPictureBox);
            this.Controls.Add(this.readyPictureBox);
            this.Controls.Add(this.newPictureBox);
            this.Controls.Add(this.button1);
            this.Name = "greedyCoin";
            this.Text = "greedyCoin";
            this.Load += new System.EventHandler(this.greedyCoin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.terminatedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runningPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admittedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedularPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interruptPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox newPictureBox;
        private System.Windows.Forms.PictureBox readyPictureBox;
        private System.Windows.Forms.PictureBox waitPictureBox;
        private System.Windows.Forms.PictureBox runningPictureBox;
        private System.Windows.Forms.PictureBox terminatedPictureBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox admittedPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox schedularPictureBox;
        private System.Windows.Forms.PictureBox interruptPictureBox;
        private System.Windows.Forms.PictureBox waitingPictureBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
    }
}