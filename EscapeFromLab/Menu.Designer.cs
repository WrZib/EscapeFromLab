namespace EscapeFromLab
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            trackBar1 = new TrackBar();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Vtks Escape", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(53, 56);
            label1.Name = "label1";
            label1.Size = new Size(384, 41);
            label1.TabIndex = 0;
            label1.Text = "Escape from";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Vtks Escape", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(137, 97);
            label2.Name = "label2";
            label2.Size = new Size(219, 73);
            label2.TabIndex = 0;
            label2.Text = "Lab";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(170, 373);
            trackBar1.Maximum = 3;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(130, 56);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Bahnschrift Condensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(137, 448);
            button1.Name = "button1";
            button1.Size = new Size(193, 45);
            button1.TabIndex = 2;
            button1.Text = "Начать Побег";
            button1.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(475, 603);
            Controls.Add(button1);
            Controls.Add(trackBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Menu";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TrackBar trackBar1;
        private Button button1;
    }
}
