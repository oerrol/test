namespace five_son_chess
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人机对局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.人机对战ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家先手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.玩家后手ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.继续ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.悔棋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.五手两打关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.步数指示关ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.返回ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.timeLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timebar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.clock1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.选项ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.窗口ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始游戏ToolStripMenuItem,
            this.保存游戏ToolStripMenuItem,
            this.读取游戏ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 21);
            this.文件ToolStripMenuItem.Text = "files";
            // 
            // 开始游戏ToolStripMenuItem
            // 
            this.开始游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.人机对局ToolStripMenuItem,
            this.人机对战ToolStripMenuItem});
            this.开始游戏ToolStripMenuItem.Name = "开始游戏ToolStripMenuItem";
            this.开始游戏ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.开始游戏ToolStripMenuItem.Text = "开始游戏";
            // 
            // 人机对局ToolStripMenuItem
            // 
            this.人机对局ToolStripMenuItem.Name = "人机对局ToolStripMenuItem";
            this.人机对局ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.人机对局ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.人机对局ToolStripMenuItem.Text = "双人对战";
            this.人机对局ToolStripMenuItem.Click += new System.EventHandler(this.人机对局ToolStripMenuItem_Click);
            // 
            // 人机对战ToolStripMenuItem
            // 
            this.人机对战ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.玩家先手ToolStripMenuItem,
            this.玩家后手ToolStripMenuItem});
            this.人机对战ToolStripMenuItem.Name = "人机对战ToolStripMenuItem";
            this.人机对战ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.人机对战ToolStripMenuItem.Text = "人机对战";
            this.人机对战ToolStripMenuItem.Click += new System.EventHandler(this.人机对战ToolStripMenuItem_Click);
            // 
            // 玩家先手ToolStripMenuItem
            // 
            this.玩家先手ToolStripMenuItem.Name = "玩家先手ToolStripMenuItem";
            this.玩家先手ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.玩家先手ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.玩家先手ToolStripMenuItem.Text = "玩家先手";
            this.玩家先手ToolStripMenuItem.Click += new System.EventHandler(this.玩家先手ToolStripMenuItem_Click);
            // 
            // 玩家后手ToolStripMenuItem
            // 
            this.玩家后手ToolStripMenuItem.Name = "玩家后手ToolStripMenuItem";
            this.玩家后手ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.玩家后手ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.玩家后手ToolStripMenuItem.Text = "玩家后手";
            this.玩家后手ToolStripMenuItem.Click += new System.EventHandler(this.玩家后手ToolStripMenuItem_Click);
            // 
            // 保存游戏ToolStripMenuItem
            // 
            this.保存游戏ToolStripMenuItem.Enabled = false;
            this.保存游戏ToolStripMenuItem.Name = "保存游戏ToolStripMenuItem";
            this.保存游戏ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存游戏ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.保存游戏ToolStripMenuItem.Text = "保存游戏";
            this.保存游戏ToolStripMenuItem.Click += new System.EventHandler(this.保存游戏ToolStripMenuItem_Click);
            // 
            // 读取游戏ToolStripMenuItem
            // 
            this.读取游戏ToolStripMenuItem.Name = "读取游戏ToolStripMenuItem";
            this.读取游戏ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.读取游戏ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.读取游戏ToolStripMenuItem.Text = "读取游戏";
            this.读取游戏ToolStripMenuItem.Click += new System.EventHandler(this.读取游戏ToolStripMenuItem_Click);
            // 
            // 选项ToolStripMenuItem
            // 
            this.选项ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停ToolStripMenuItem,
            this.继续ToolStripMenuItem,
            this.悔棋ToolStripMenuItem});
            this.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem";
            this.选项ToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.选项ToolStripMenuItem.Text = "actions";
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            this.暂停ToolStripMenuItem.Click += new System.EventHandler(this.暂停ToolStripMenuItem_Click);
            // 
            // 继续ToolStripMenuItem
            // 
            this.继续ToolStripMenuItem.Enabled = false;
            this.继续ToolStripMenuItem.Name = "继续ToolStripMenuItem";
            this.继续ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.继续ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.继续ToolStripMenuItem.Text = "继续";
            this.继续ToolStripMenuItem.Click += new System.EventHandler(this.继续ToolStripMenuItem_Click);
            // 
            // 悔棋ToolStripMenuItem
            // 
            this.悔棋ToolStripMenuItem.Name = "悔棋ToolStripMenuItem";
            this.悔棋ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.悔棋ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.悔棋ToolStripMenuItem.Text = "悔棋";
            this.悔棋ToolStripMenuItem.Click += new System.EventHandler(this.悔棋ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.五手两打关ToolStripMenuItem,
            this.步数指示关ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.帮助ToolStripMenuItem.Text = "options";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.查看帮助ToolStripMenuItem.Text = "禁手：开";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 五手两打关ToolStripMenuItem
            // 
            this.五手两打关ToolStripMenuItem.Name = "五手两打关ToolStripMenuItem";
            this.五手两打关ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.五手两打关ToolStripMenuItem.Text = "五手两打：关";
            this.五手两打关ToolStripMenuItem.Click += new System.EventHandler(this.五手两打关ToolStripMenuItem_Click);
            // 
            // 步数指示关ToolStripMenuItem
            // 
            this.步数指示关ToolStripMenuItem.Name = "步数指示关ToolStripMenuItem";
            this.步数指示关ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.步数指示关ToolStripMenuItem.Text = "步数指示：关";
            this.步数指示关ToolStripMenuItem.Click += new System.EventHandler(this.步数指示关ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
            this.helpToolStripMenuItem.Text = "help";
            // 
            // 查看帮助ToolStripMenuItem1
            // 
            this.查看帮助ToolStripMenuItem1.Name = "查看帮助ToolStripMenuItem1";
            this.查看帮助ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.查看帮助ToolStripMenuItem1.Text = "使用说明";
            this.查看帮助ToolStripMenuItem1.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem1_Click);
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.返回ToolStripMenuItem,
            this.结束ToolStripMenuItem});
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(40, 21);
            this.窗口ToolStripMenuItem.Text = "exit";
            // 
            // 返回ToolStripMenuItem
            // 
            this.返回ToolStripMenuItem.Name = "返回ToolStripMenuItem";
            this.返回ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.返回ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.返回ToolStripMenuItem.Text = "返回";
            this.返回ToolStripMenuItem.Click += new System.EventHandler(this.返回ToolStripMenuItem_Click);
            // 
            // 结束ToolStripMenuItem
            // 
            this.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem";
            this.结束ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.结束ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.结束ToolStripMenuItem.Text = "结束";
            this.结束ToolStripMenuItem.Click += new System.EventHandler(this.结束ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 304);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeLabel1,
            this.timebar1,
            this.clock1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(450, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // timeLabel1
            // 
            this.timeLabel1.AutoSize = false;
            this.timeLabel1.Name = "timeLabel1";
            this.timeLabel1.Size = new System.Drawing.Size(90, 17);
            this.timeLabel1.Click += new System.EventHandler(this.timeLabel1_Click);
            // 
            // timebar1
            // 
            this.timebar1.Maximum = 91;
            this.timebar1.Name = "timebar1";
            this.timebar1.Size = new System.Drawing.Size(100, 16);
            // 
            // clock1
            // 
            this.clock1.AutoSize = false;
            this.clock1.Name = "clock1";
            this.clock1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.clock1.Size = new System.Drawing.Size(243, 17);
            this.clock1.Spring = true;
            this.clock1.Text = " ";
            this.clock1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clock1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 435);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(450, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五子棋";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 返回ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人机对局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 悔棋ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 五手两打关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 人机对战ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 步数指示关ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 玩家先手ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 玩家后手ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel1;
        private System.Windows.Forms.ToolStripProgressBar timebar1;
        private System.Windows.Forms.ToolStripStatusLabel clock1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

