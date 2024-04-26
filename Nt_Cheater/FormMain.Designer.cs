
namespace Nt_Cheater
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.MyStatusStrip = new System.Windows.Forms.StatusStrip();
			this.MyToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ButtonRefindGame = new System.Windows.Forms.Button();
			this.TextboxScore = new System.Windows.Forms.TextBox();
			this.ButtonScore = new System.Windows.Forms.Button();
			this.ButtonScorerate = new System.Windows.Forms.Button();
			this.TextboxScorerate = new System.Windows.Forms.TextBox();
			this.ButtonDreampower = new System.Windows.Forms.Button();
			this.CheckboxDreampower = new System.Windows.Forms.CheckBox();
			this.ListboxDreampower = new System.Windows.Forms.ListBox();
			this.ListboxLife = new System.Windows.Forms.ListBox();
			this.CheckboxLife = new System.Windows.Forms.CheckBox();
			this.ButtonLife = new System.Windows.Forms.Button();
			this.ListboxBoom = new System.Windows.Forms.ListBox();
			this.CheckboxBoom = new System.Windows.Forms.CheckBox();
			this.ButtonBoom = new System.Windows.Forms.Button();
			this.CheckboxSmooth = new System.Windows.Forms.CheckBox();
			this.MyTimer = new System.Windows.Forms.Timer(this.components);
			this.MyStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MyStatusStrip
			// 
			this.MyStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MyToolStripStatusLabel});
			this.MyStatusStrip.Location = new System.Drawing.Point(0, 219);
			this.MyStatusStrip.Name = "MyStatusStrip";
			this.MyStatusStrip.Size = new System.Drawing.Size(284, 22);
			this.MyStatusStrip.TabIndex = 0;
			this.MyStatusStrip.Text = "MyStatusStrip";
			// 
			// MyToolStripStatusLabel
			// 
			this.MyToolStripStatusLabel.Name = "MyToolStripStatusLabel";
			this.MyToolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
			this.MyToolStripStatusLabel.Text = "状态栏";
			// 
			// ButtonRefindGame
			// 
			this.ButtonRefindGame.Location = new System.Drawing.Point(23, 180);
			this.ButtonRefindGame.Name = "ButtonRefindGame";
			this.ButtonRefindGame.Size = new System.Drawing.Size(100, 25);
			this.ButtonRefindGame.TabIndex = 0;
			this.ButtonRefindGame.Text = "*重新寻找游戏";
			this.ButtonRefindGame.UseVisualStyleBackColor = true;
			this.ButtonRefindGame.Click += new System.EventHandler(this.ButtonRefindGame_Click);
			// 
			// TextboxScore
			// 
			this.TextboxScore.Location = new System.Drawing.Point(14, 13);
			this.TextboxScore.Name = "TextboxScore";
			this.TextboxScore.Size = new System.Drawing.Size(120, 21);
			this.TextboxScore.TabIndex = 1;
			this.TextboxScore.Text = "999999999";
			// 
			// ButtonScore
			// 
			this.ButtonScore.Location = new System.Drawing.Point(151, 13);
			this.ButtonScore.Name = "ButtonScore";
			this.ButtonScore.Size = new System.Drawing.Size(120, 21);
			this.ButtonScore.TabIndex = 2;
			this.ButtonScore.Text = "得分";
			this.ButtonScore.UseVisualStyleBackColor = true;
			this.ButtonScore.Click += new System.EventHandler(this.ButtonScore_Click);
			// 
			// ButtonScorerate
			// 
			this.ButtonScorerate.Location = new System.Drawing.Point(151, 40);
			this.ButtonScorerate.Name = "ButtonScorerate";
			this.ButtonScorerate.Size = new System.Drawing.Size(120, 21);
			this.ButtonScorerate.TabIndex = 4;
			this.ButtonScorerate.Text = "得分率";
			this.ButtonScorerate.UseVisualStyleBackColor = true;
			this.ButtonScorerate.Click += new System.EventHandler(this.ButtonScorerate_Click);
			// 
			// TextboxScorerate
			// 
			this.TextboxScorerate.Location = new System.Drawing.Point(14, 40);
			this.TextboxScorerate.Name = "TextboxScorerate";
			this.TextboxScorerate.Size = new System.Drawing.Size(120, 21);
			this.TextboxScorerate.TabIndex = 3;
			this.TextboxScorerate.Text = "999999990";
			// 
			// ButtonDreampower
			// 
			this.ButtonDreampower.Location = new System.Drawing.Point(211, 75);
			this.ButtonDreampower.Name = "ButtonDreampower";
			this.ButtonDreampower.Size = new System.Drawing.Size(60, 21);
			this.ButtonDreampower.TabIndex = 7;
			this.ButtonDreampower.Text = "梦想力";
			this.ButtonDreampower.UseVisualStyleBackColor = true;
			this.ButtonDreampower.Click += new System.EventHandler(this.ButtonDreampower_Click);
			// 
			// CheckboxDreampower
			// 
			this.CheckboxDreampower.AutoSize = true;
			this.CheckboxDreampower.Location = new System.Drawing.Point(151, 79);
			this.CheckboxDreampower.Name = "CheckboxDreampower";
			this.CheckboxDreampower.Size = new System.Drawing.Size(48, 16);
			this.CheckboxDreampower.TabIndex = 6;
			this.CheckboxDreampower.Text = "不耗";
			this.CheckboxDreampower.UseVisualStyleBackColor = true;
			this.CheckboxDreampower.CheckedChanged += new System.EventHandler(this.CheckboxDreampower_CheckedChanged);
			// 
			// ListboxDreampower
			// 
			this.ListboxDreampower.FormattingEnabled = true;
			this.ListboxDreampower.ItemHeight = 12;
			this.ListboxDreampower.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
			this.ListboxDreampower.Location = new System.Drawing.Point(14, 72);
			this.ListboxDreampower.Name = "ListboxDreampower";
			this.ListboxDreampower.Size = new System.Drawing.Size(121, 28);
			this.ListboxDreampower.TabIndex = 5;
			// 
			// ListboxLife
			// 
			this.ListboxLife.FormattingEnabled = true;
			this.ListboxLife.ItemHeight = 12;
			this.ListboxLife.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.ListboxLife.Location = new System.Drawing.Point(14, 106);
			this.ListboxLife.Name = "ListboxLife";
			this.ListboxLife.Size = new System.Drawing.Size(121, 28);
			this.ListboxLife.TabIndex = 8;
			// 
			// CheckboxLife
			// 
			this.CheckboxLife.AutoSize = true;
			this.CheckboxLife.Location = new System.Drawing.Point(151, 113);
			this.CheckboxLife.Name = "CheckboxLife";
			this.CheckboxLife.Size = new System.Drawing.Size(48, 16);
			this.CheckboxLife.TabIndex = 9;
			this.CheckboxLife.Text = "不耗";
			this.CheckboxLife.UseVisualStyleBackColor = true;
			this.CheckboxLife.CheckedChanged += new System.EventHandler(this.CheckboxLife_CheckedChanged);
			// 
			// ButtonLife
			// 
			this.ButtonLife.Location = new System.Drawing.Point(211, 109);
			this.ButtonLife.Name = "ButtonLife";
			this.ButtonLife.Size = new System.Drawing.Size(60, 21);
			this.ButtonLife.TabIndex = 10;
			this.ButtonLife.Text = "残机";
			this.ButtonLife.UseVisualStyleBackColor = true;
			this.ButtonLife.Click += new System.EventHandler(this.ButtonLife_Click);
			// 
			// ListboxBoom
			// 
			this.ListboxBoom.FormattingEnabled = true;
			this.ListboxBoom.ItemHeight = 12;
			this.ListboxBoom.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
			this.ListboxBoom.Location = new System.Drawing.Point(14, 140);
			this.ListboxBoom.Name = "ListboxBoom";
			this.ListboxBoom.Size = new System.Drawing.Size(121, 28);
			this.ListboxBoom.TabIndex = 11;
			// 
			// CheckboxBoom
			// 
			this.CheckboxBoom.AutoSize = true;
			this.CheckboxBoom.Location = new System.Drawing.Point(151, 147);
			this.CheckboxBoom.Name = "CheckboxBoom";
			this.CheckboxBoom.Size = new System.Drawing.Size(48, 16);
			this.CheckboxBoom.TabIndex = 12;
			this.CheckboxBoom.Text = "不耗";
			this.CheckboxBoom.UseVisualStyleBackColor = true;
			this.CheckboxBoom.CheckedChanged += new System.EventHandler(this.CheckboxBoom_CheckedChanged);
			// 
			// ButtonBoom
			// 
			this.ButtonBoom.Location = new System.Drawing.Point(211, 143);
			this.ButtonBoom.Name = "ButtonBoom";
			this.ButtonBoom.Size = new System.Drawing.Size(60, 21);
			this.ButtonBoom.TabIndex = 13;
			this.ButtonBoom.Text = "Boom";
			this.ButtonBoom.UseVisualStyleBackColor = true;
			this.ButtonBoom.Click += new System.EventHandler(this.ButtonBoom_Click);
			// 
			// CheckboxSmooth
			// 
			this.CheckboxSmooth.AutoSize = true;
			this.CheckboxSmooth.Location = new System.Drawing.Point(178, 185);
			this.CheckboxSmooth.Name = "CheckboxSmooth";
			this.CheckboxSmooth.Size = new System.Drawing.Size(72, 16);
			this.CheckboxSmooth.TabIndex = 14;
			this.CheckboxSmooth.Text = "平滑画质";
			this.CheckboxSmooth.UseVisualStyleBackColor = true;
			this.CheckboxSmooth.CheckedChanged += new System.EventHandler(this.CheckboxSmooth_CheckedChanged);
			// 
			// MyTimer
			// 
			this.MyTimer.Interval = 500;
			this.MyTimer.Tick += new System.EventHandler(this.MyTimer_Tick);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 241);
			this.Controls.Add(this.CheckboxSmooth);
			this.Controls.Add(this.ListboxBoom);
			this.Controls.Add(this.CheckboxBoom);
			this.Controls.Add(this.ButtonBoom);
			this.Controls.Add(this.ListboxLife);
			this.Controls.Add(this.CheckboxLife);
			this.Controls.Add(this.ButtonLife);
			this.Controls.Add(this.ListboxDreampower);
			this.Controls.Add(this.CheckboxDreampower);
			this.Controls.Add(this.ButtonDreampower);
			this.Controls.Add(this.ButtonScorerate);
			this.Controls.Add(this.TextboxScorerate);
			this.Controls.Add(this.ButtonScore);
			this.Controls.Add(this.TextboxScore);
			this.Controls.Add(this.ButtonRefindGame);
			this.Controls.Add(this.MyStatusStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.Text = "噩梦之旅 修改器";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MyStatusStrip.ResumeLayout(false);
			this.MyStatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MyStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel MyToolStripStatusLabel;
        private System.Windows.Forms.Button ButtonRefindGame;
        private System.Windows.Forms.TextBox TextboxScore;
        private System.Windows.Forms.Button ButtonScore;
        private System.Windows.Forms.Button ButtonScorerate;
        private System.Windows.Forms.TextBox TextboxScorerate;
        private System.Windows.Forms.Button ButtonDreampower;
        private System.Windows.Forms.CheckBox CheckboxDreampower;
        private System.Windows.Forms.ListBox ListboxDreampower;
		private System.Windows.Forms.ListBox ListboxLife;
		private System.Windows.Forms.CheckBox CheckboxLife;
		private System.Windows.Forms.Button ButtonLife;
		private System.Windows.Forms.ListBox ListboxBoom;
		private System.Windows.Forms.CheckBox CheckboxBoom;
		private System.Windows.Forms.Button ButtonBoom;
		private System.Windows.Forms.CheckBox CheckboxSmooth;
		private System.Windows.Forms.Timer MyTimer;
	}
}

