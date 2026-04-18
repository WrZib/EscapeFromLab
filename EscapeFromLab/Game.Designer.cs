namespace EscapeFromLab
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            title = new Label();
            textBox = new Label();
            btn1 = new RoundedButton();
            btn2 = new RoundedButton();
            btn3 = new RoundedButton();
            btn4 = new RoundedButton();
            hpbar = new ProgressBar();
            alarmbar = new ProgressBar();
            invBox = new ListBox();
            turns = new Label();
            trustbar = new ProgressBar();
            pictureBox = new PictureBox();
            hp = new Label();
            alarm = new Label();
            trust = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // title
            // 
            title.Anchor = AnchorStyles.Top;
            title.BackColor = Color.Transparent;
            title.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            title.ForeColor = Color.White;
            title.Location = new Point(244, 12);
            title.Name = "title";
            title.Size = new Size(256, 28);
            title.TabIndex = 0;
            title.Text = "label1";
            title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox
            // 
            textBox.Anchor = AnchorStyles.Top;
            textBox.BackColor = Color.FromArgb(80, 80, 80, 80);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBox.ForeColor = Color.White;
            textBox.Location = new Point(21, 422);
            textBox.Name = "textBox";
            textBox.Size = new Size(556, 200);
            textBox.TabIndex = 1;
            textBox.Text = "label2";
            // 
            // btn1
            // 
            btn1.Anchor = AnchorStyles.Bottom;
            btn1.BackColor = Color.Gray;
            btn1.FlatAppearance.BorderColor = Color.Gray;
            btn1.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn1.FlatStyle = FlatStyle.Flat;
            btn1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn1.ForeColor = Color.White;
            btn1.Location = new Point(109, 636);
            btn1.Name = "btn1";
            btn1.Size = new Size(233, 45);
            btn1.TabIndex = 2;
            btn1.Text = "button1";
            btn1.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            btn2.Anchor = AnchorStyles.Bottom;
            btn2.BackColor = Color.Gray;
            btn2.FlatAppearance.BorderColor = Color.Gray;
            btn2.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn2.FlatStyle = FlatStyle.Flat;
            btn2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn2.ForeColor = Color.White;
            btn2.Location = new Point(410, 636);
            btn2.Name = "btn2";
            btn2.Size = new Size(233, 45);
            btn2.TabIndex = 3;
            btn2.Text = "button2";
            btn2.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            btn3.Anchor = AnchorStyles.Bottom;
            btn3.BackColor = Color.Gray;
            btn3.FlatAppearance.BorderColor = Color.Gray;
            btn3.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn3.FlatStyle = FlatStyle.Flat;
            btn3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn3.ForeColor = Color.White;
            btn3.Location = new Point(109, 694);
            btn3.Name = "btn3";
            btn3.Size = new Size(233, 45);
            btn3.TabIndex = 4;
            btn3.Text = "button3";
            btn3.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            btn4.Anchor = AnchorStyles.Bottom;
            btn4.BackColor = Color.Gray;
            btn4.FlatAppearance.BorderColor = Color.Gray;
            btn4.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn4.FlatStyle = FlatStyle.Flat;
            btn4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btn4.ForeColor = Color.White;
            btn4.Location = new Point(410, 694);
            btn4.Name = "btn4";
            btn4.Size = new Size(233, 45);
            btn4.TabIndex = 5;
            btn4.Text = "button4";
            btn4.UseVisualStyleBackColor = false;
            // 
            // hpbar
            // 
            hpbar.Anchor = AnchorStyles.Top;
            hpbar.ForeColor = Color.LimeGreen;
            hpbar.Location = new Point(21, 12);
            hpbar.Name = "hpbar";
            hpbar.Size = new Size(190, 45);
            hpbar.Step = 1;
            hpbar.Style = ProgressBarStyle.Continuous;
            hpbar.TabIndex = 6;
            // 
            // alarmbar
            // 
            alarmbar.Anchor = AnchorStyles.Top;
            alarmbar.ForeColor = Color.Crimson;
            alarmbar.Location = new Point(560, 12);
            alarmbar.Name = "alarmbar";
            alarmbar.Size = new Size(160, 28);
            alarmbar.Step = 5;
            alarmbar.Style = ProgressBarStyle.Continuous;
            alarmbar.TabIndex = 7;
            // 
            // invBox
            // 
            invBox.Anchor = AnchorStyles.Top;
            invBox.BackColor = Color.FromArgb(80, 80, 81);
            invBox.BorderStyle = BorderStyle.FixedSingle;
            invBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            invBox.ForeColor = Color.WhiteSmoke;
            invBox.FormattingEnabled = true;
            invBox.Location = new Point(583, 422);
            invBox.Name = "invBox";
            invBox.Size = new Size(137, 202);
            invBox.TabIndex = 8;
            // 
            // turns
            // 
            turns.Anchor = AnchorStyles.Top;
            turns.AutoSize = true;
            turns.BackColor = Color.Transparent;
            turns.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            turns.ForeColor = Color.White;
            turns.Location = new Point(347, 41);
            turns.Name = "turns";
            turns.Size = new Size(50, 20);
            turns.TabIndex = 9;
            turns.Text = "label3";
            turns.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trustbar
            // 
            trustbar.Anchor = AnchorStyles.Top;
            trustbar.Location = new Point(560, 46);
            trustbar.Name = "trustbar";
            trustbar.Size = new Size(160, 11);
            trustbar.Step = 5;
            trustbar.Style = ProgressBarStyle.Continuous;
            trustbar.TabIndex = 10;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Location = new Point(21, 79);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(699, 327);
            pictureBox.TabIndex = 11;
            pictureBox.TabStop = false;
            // 
            // hp
            // 
            hp.Anchor = AnchorStyles.Top;
            hp.AutoSize = true;
            hp.BackColor = Color.Transparent;
            hp.ForeColor = Color.White;
            hp.Location = new Point(215, 22);
            hp.Name = "hp";
            hp.Size = new Size(28, 20);
            hp.TabIndex = 12;
            hp.Text = "HP";
            // 
            // alarm
            // 
            alarm.Anchor = AnchorStyles.Top;
            alarm.AutoSize = true;
            alarm.BackColor = Color.Transparent;
            alarm.ForeColor = Color.White;
            alarm.Location = new Point(496, 12);
            alarm.Name = "alarm";
            alarm.Size = new Size(58, 20);
            alarm.TabIndex = 13;
            alarm.Text = "ALARM";
            // 
            // trust
            // 
            trust.Anchor = AnchorStyles.Top;
            trust.AutoSize = true;
            trust.BackColor = Color.Transparent;
            trust.ForeColor = Color.White;
            trust.Location = new Point(502, 41);
            trust.Name = "trust";
            trust.Size = new Size(52, 20);
            trust.TabIndex = 14;
            trust.Text = "TRUST";
            trust.Click += label1_Click;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            BackgroundImage = Properties.Resources.BackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(745, 774);
            Controls.Add(alarm);
            Controls.Add(trust);
            Controls.Add(hp);
            Controls.Add(pictureBox);
            Controls.Add(trustbar);
            Controls.Add(turns);
            Controls.Add(invBox);
            Controls.Add(hpbar);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(textBox);
            Controls.Add(title);
            Controls.Add(alarmbar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(763, 821);
            Name = "Game";
            Text = "Escape From Lab";
            Load += Game_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label textBox;
        private ProgressBar hpbar;
        private ProgressBar alarmbar;
        private ListBox invBox;
        private Label turns;
        private ProgressBar trustbar;
        private PictureBox pictureBox;
        private RoundedButton btn1;
        private RoundedButton btn2;
        private RoundedButton btn3;
        private RoundedButton btn4;
        private Label hp;
        private Label alarm;
        private Label trust;
    }
}