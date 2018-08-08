using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace five_son_chess
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 一些初始对象的声明，包括棋盘图片、棋子笔刷、StateEvaluate类的对象、棋盘等
        /// </summary>
        #region 初始变量声明
        public Bitmap bg = global::five_son_chess.Properties.Resources.bg;
        public int ste = 0;
        public int lin = 0;
        public int lis = 0;
        int[] mmx=new int[2];
        int[] mmy=new int[2];
        public Bitmap b = global::five_son_chess.Properties.Resources.b;
        public Bitmap w = global::five_son_chess.Properties.Resources.w;
        public Bitmap bl = global::five_son_chess.Properties.Resources.bl;
        public Bitmap wl = global::five_son_chess.Properties.Resources.wl;
        public Bitmap b52 = global::five_son_chess.Properties.Resources.b52;
        public Bitmap b51 = global::five_son_chess.Properties.Resources.b51;
        StateEvaluate state = new StateEvaluate();
        Font JSQ = new Font("微软雅黑",10,System.Drawing.FontStyle.Regular);
        SolidBrush bBrush = new SolidBrush(System.Drawing.Color.Black);
        SolidBrush wBrush = new SolidBrush(System.Drawing.Color.White);
        Pen bPen = new Pen(System.Drawing.Color.Brown);
        static TextureBrush bgbrush = new TextureBrush(global::five_son_chess.Properties.Resources.bg);
        Pen bgpen = new Pen(bgbrush, 1);
        #endregion


        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体一的Load内容，为一些量初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = global::five_son_chess.Properties.Resources.icon;
            查看帮助ToolStripMenuItem.Text = "禁手：开";
            state.JinShou = true;
            五手两打关ToolStripMenuItem.Text = "五手两打：关";
            state.WuShou = false;
            state.WushouStep = 0;
            步数指示关ToolStripMenuItem.Text = "步数指示：关";
            state.StepIndicator = false;
            暂停ToolStripMenuItem.Enabled = false;
            继续ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = false;
            保存游戏ToolStripMenuItem.Enabled = false;
            label1.Image = global::five_son_chess.Properties.Resources.tuzi;
            clock1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 开始游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 双人游戏启动，并对一些功能的开关做初始化，并激活双人对战
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region 双人对战
        private void 人机对局ToolStripMenuItem_Click(object sender, EventArgs e)//将游戏模式设置为双人游戏并初始化（事件名有误，正常）
        {
            state.RenRen_Click();
            label1.Visible = false;
            label1.Enabled = false;
            timer1.Enabled = true;
            暂停ToolStripMenuItem.Enabled = true;
            悔棋ToolStripMenuItem.Enabled = true;
            保存游戏ToolStripMenuItem.Enabled = false;
            五手两打关ToolStripMenuItem.Enabled = true;
            Refresh();
        }
        #endregion


        private void Form1_Paint(object sender, PaintEventArgs e)//重绘界面
        {
            if (state.gametype != 0 && state.gametype < 3)
            {
                pictureBox1.Visible = false;
                pictureBox1.Image = null;
                Graphics g;
                g = e.Graphics;
                g.DrawImage(bg, 0, 25, 450, 450);//画棋盘
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        switch (state.map[state.step, i, j])//画子，1黑-100白0不画
                        {
                            case 1:
                                g.DrawImage(b, i * 29 + 7, j * 29 + 30, 29, 29);
                                break;
                            case -100:
                                g.DrawImage(w, i * 29 + 7, j * 29 + 30, 29, 29);
                                break;
                        }
                    }
                }
                switch (state.WushouStep)
                {
                    case 1:
                        g.DrawImage(b51, state.Wushoux[0] * 29 + 7, state.Wushouy[0] * 29 + 30, 29, 29);
                        break;
                    case 2:
                        g.DrawImage(b51, state.Wushoux[0] * 29 + 7, state.Wushouy[0] * 29 + 30, 29, 29);
                        g.DrawImage(b52, state.Wushoux[1] * 29 + 7, state.Wushouy[1] * 29 + 30, 29, 29);
                        break;
                }
                if (state.StepIndicator)
                {
                    for (int i = 0; i < state.step; i++)
                    {
                        if (i % 2 == 0)
                        {
                            g.DrawString(Convert.ToString(i + 1), JSQ, wBrush, state.JiShu[i]);
                        }
                        else
                        {
                            g.DrawString(Convert.ToString(i + 1), JSQ, bBrush, state.JiShu[i]);
                        }
                    }
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)//根据巡数、游戏模式及位置判别点击鼠标后的操作
        {
            lis = (e.X - 7) / 29;
            lin = (e.Y - 30) / 29;
            if (state.gametype == 1)
            {
                switch (state.Mou_Click(lis, lin))
                {
                    case 666:
                        timer1.Enabled = false;
                        timeLabel1.Text = "";
                        timebar1.Value = 0;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        MessageBox.Show("对局结束！白方胜！");
                        state.gametype -= 3;
                        break;
                    case 1:
                        //黑成五子
                        timer1.Enabled = false;
                        timeLabel1.Text = "";
                        timebar1.Value = 0;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        Refresh();
                        state.gametype -= 3;
                        MessageBox.Show("对局结束！黑方胜！");
                        break;
                    case -100:
                        //白成五子
                        timer1.Enabled = false;
                        timeLabel1.Text = "";
                        timebar1.Value = 0;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        Refresh();
                        state.gametype -= 3;
                        MessageBox.Show("对局结束！白方胜！");
                        break;
                    case 5:
                        Refresh();
                        if (state.step == 4 && state.WuShou == true)
                        {
                            五手两打关ToolStripMenuItem.Enabled = false;
                            悔棋ToolStripMenuItem.Enabled = false;
                            保存游戏ToolStripMenuItem.Enabled = false;
                            读取游戏ToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            五手两打关ToolStripMenuItem.Enabled = true;
                            悔棋ToolStripMenuItem.Enabled = true;
                            保存游戏ToolStripMenuItem.Enabled = false;
                            读取游戏ToolStripMenuItem.Enabled = true;
                        }
                        break;
                    case 0:
                        Refresh();
                        if (state.step % 2 == 0)
                        {
                            this.CreateGraphics().DrawImage(wl, state.JiShu[state.step - 1].X, state.JiShu[state.step - 1].Y, 29, 29);
                        }
                        else
                        {
                            this.CreateGraphics().DrawImage(bl, state.JiShu[state.step - 1].X, state.JiShu[state.step - 1].Y, 29, 29);
                        }
                        break;
                    case 233:
                        break;
                }
            }
            else if (state.gametype == 2)
            {
                switch (state.Mou_Click_WithAI(lis,lin))
                {
                    case 666:
                        timer1.Enabled = false;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        MessageBox.Show("对局结束！白方胜！");
                        state.gametype -= 3;
                        break;
                    case 1:
                        //黑成五子
                        timer1.Enabled = false;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        Refresh();
                        state.gametype -= 3;
                        MessageBox.Show("对局结束！黑方胜！");
                        break;
                    case -100:
                        //白成五子
                        timer1.Enabled = false;
                        暂停ToolStripMenuItem.Enabled = false;
                        继续ToolStripMenuItem.Enabled = false;
                        悔棋ToolStripMenuItem.Enabled = false;
                        保存游戏ToolStripMenuItem.Enabled = false;
                        读取游戏ToolStripMenuItem.Enabled = true;
                        Refresh();
                        state.gametype -= 3;
                        MessageBox.Show("对局结束！白方胜！");
                        break;
                    case 5:
                        Refresh();
                        if (state.step == 4 && state.WuShou == true)
                        {
                            五手两打关ToolStripMenuItem.Enabled = false;
                            悔棋ToolStripMenuItem.Enabled = false;
                            保存游戏ToolStripMenuItem.Enabled = false;
                            读取游戏ToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            五手两打关ToolStripMenuItem.Enabled = true;
                            悔棋ToolStripMenuItem.Enabled = true;
                            保存游戏ToolStripMenuItem.Enabled = false;
                            读取游戏ToolStripMenuItem.Enabled = true;
                        }
                        break;
                    case 0:
                        Refresh();
                        if (state.step % 2 == 0)
                        {
                            this.CreateGraphics().DrawImage(wl, state.JiShu[state.step - 1].X, state.JiShu[state.step - 1].Y, 29, 29);
                        }
                        else
                        {
                            this.CreateGraphics().DrawImage(bl, state.JiShu[state.step - 1].X, state.JiShu[state.step - 1].Y, 29, 29);
                        }
                        break;
                    case 233:
                        break;
                }
            }
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)//返回初始界面
        {
            label1.Visible = true;
            label1.Enabled = true;
            state.gametype = 0;
            timer1.Enabled = false;
            暂停ToolStripMenuItem.Enabled = false;
            继续ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = false;
            保存游戏ToolStripMenuItem.Enabled = false;
            读取游戏ToolStripMenuItem.Enabled = true;
            state.WushouStep = 0;
            timeLabel1.Text = "";
            timebar1.Value = 0;
            Invalidate();
        }

        private void Form1_FontChanged(object sender, EventArgs e)
        {

        }

        private void 结束ToolStripMenuItem_Click(object sender, EventArgs e)//结束程序
        {
            if (MessageBox.Show("是否要退出本程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void 悔棋ToolStripMenuItem_Click(object sender, EventArgs e)//将棋局复原至上一手
        {
            if (state.HuiQi_Click())
            {
                Refresh();
                //if (state.step == 4 && state.WuShou == true)
                //{
                //    五手两打关ToolStripMenuItem.Enabled = false;
                //    悔棋ToolStripMenuItem.Enabled = false;
                //}
                //else
                //{
                //    五手两打关ToolStripMenuItem.Enabled = true;
                //    悔棋ToolStripMenuItem.Enabled = true;
                //}
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//倒计时功能
        {
            if (state.wtg == state.step % 2)
            {
                state.time = state.time > 0 ? state.time - 1 : -1;
            }
            else
            {
                state.time = 30;
            }
            if (state.step % 2 == 0)
            {
                string t = String.Concat("黑方走子：", state.time.ToString());
                timeLabel1.Text = t;
                timebar1.Value = 3 * state.time < 0 ? 0 : 3 * state.time;
            }
            else
            {
                string t = String.Concat("白方走子：", state.time.ToString());
                timeLabel1.Text = t;
                timebar1.Value = 3 * state.time < 0 ? 0 : 3 * state.time;
            }
            state.wtg = state.step % 2;
            if (state.time == 0)
            {
                if (state.step % 2 == 0)
                {
                    MessageBox.Show("黑方走子超时！白子连下！", "超时警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    state.or++;
                    if (state.or == 2)
                    {
                        state.or = 0;
                        state.step--;
                    }
                    else
                    {
                        state.step++;
                    }
                }
                else
                {
                    MessageBox.Show("白方走子超时！黑子连下！", "超时警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    state.or++;
                    if (state.or == 2)
                    {
                        state.or = 0;
                        state.step--;
                    }
                    else
                    {
                        state.step++;
                    }
                }
            }

        }

        private void 暂停ToolStripMenuItem_Click(object sender, EventArgs e)//停止计时器，扰乱游戏类型，暂停
        {
            pictureBox1.Visible = true;
            pictureBox1.Image = global::five_son_chess.Properties.Resources.pause;
            timer1.Enabled = false;
            state.gametype = state.gametype + 5;
            暂停ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = false;
            继续ToolStripMenuItem.Enabled = true;
            保存游戏ToolStripMenuItem.Enabled = true;
            Refresh();
        }

        private void 继续ToolStripMenuItem_Click(object sender, EventArgs e)//继续
        {
            timer1.Enabled = true;
            state.gametype = state.gametype - 5;
            暂停ToolStripMenuItem.Enabled = true;
            继续ToolStripMenuItem.Enabled = false;
            保存游戏ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = true;
            Refresh();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)//禁手开关
        {
            if (state.JinShou == true)
            {
                查看帮助ToolStripMenuItem.Text = "禁手：关";
                state.JinShou = false;
            }
            else
            {
                查看帮助ToolStripMenuItem.Text = "禁手：开";
                state.JinShou = true;
            }
        }

        private void 五手两打关ToolStripMenuItem_Click(object sender, EventArgs e)//五手两打功能开关
        {
            if (state.WuShou == true)
            {
                五手两打关ToolStripMenuItem.Text = "五手两打：关";
                state.WuShou = false;
            }
            else
            {
                五手两打关ToolStripMenuItem.Text = "五手两打：开";
                state.WuShou = true;
            }
        }

        private void 人机对战ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 保存游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svd = new SaveFileDialog();
            svd.Filter = "sh files(*.sh)|*.sh";
            svd.FileName = "save";
            svd.RestoreDirectory = true;
            if (svd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter svfile = new StreamWriter(svd.FileName.ToString());
                for (int i = 0; i < 225; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            svfile.WriteLine(state.map[i, j, k]);
                        }
                    }
                }
                for (int i = 0; i < 225; i++)
                {
                    svfile.WriteLine(state.JiShu[i].X);
                    svfile.WriteLine(state.JiShu[i].Y);
                }
                svfile.WriteLine(state.step);
                svfile.WriteLine(state.JinShou);
                svfile.WriteLine(state.WuShou);
                svfile.WriteLine(timer1.Enabled);
                svfile.WriteLine(暂停ToolStripMenuItem.Enabled);
                svfile.WriteLine(继续ToolStripMenuItem.Enabled);
                svfile.WriteLine(悔棋ToolStripMenuItem.Enabled);
                svfile.WriteLine(state.gametype);
                svfile.Close();
            }
        }

        private void 读取游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label1.Enabled = false;
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "sh files(*.sh)|*.sh";
            opd.RestoreDirectory = true;
            if (opd.ShowDialog() == DialogResult.OK)
            {
                StreamReader opfile = new StreamReader(opd.FileName.ToString());
                for (int i = 0; i < 225; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        for (int k = 0; k < 15; k++)
                        {
                            state.map[i, j, k]=Convert.ToInt32(opfile.ReadLine());
                        }
                    }
                }
                for (int i = 0; i < 225; i++)
                {
                    state.JiShu[i].X = Convert.ToInt32(opfile.ReadLine());
                    state.JiShu[i].Y = Convert.ToInt32(opfile.ReadLine());
                }
                state.step = Convert.ToInt32(opfile.ReadLine());
                state.JinShou = !Convert.ToBoolean(opfile.ReadLine());
                state.WuShou = !Convert.ToBoolean(opfile.ReadLine());
                state.time = 30;
                timer1.Enabled = Convert.ToBoolean(opfile.ReadLine());
                暂停ToolStripMenuItem.Enabled = Convert.ToBoolean(opfile.ReadLine());
                继续ToolStripMenuItem.Enabled = Convert.ToBoolean(opfile.ReadLine());
                悔棋ToolStripMenuItem.Enabled = Convert.ToBoolean(opfile.ReadLine());
                state.gametype = 1;
                Refresh();
                state.gametype = Convert.ToInt32(opfile.ReadLine());
                opfile.Close();
                保存游戏ToolStripMenuItem.Enabled = true;
                if (state.JinShou == true)
                {
                    查看帮助ToolStripMenuItem.Text = "禁手：关";
                    state.JinShou = false;
                }
                else
                {
                    查看帮助ToolStripMenuItem.Text = "禁手：开";
                    state.JinShou = true;
                }

                if (state.WuShou == true)
                {
                    五手两打关ToolStripMenuItem.Text = "五手两打：关";
                    state.WuShou = false;
                }
                else
                {
                    五手两打关ToolStripMenuItem.Text = "五手两打：开";
                    state.WuShou = true;
                }
            }
        }

        private void 步数指示关ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state.StepIndicator == true)
            {
                步数指示关ToolStripMenuItem.Text = "步数指示：关";
                state.StepIndicator = false;
            }
            else
            {
                步数指示关ToolStripMenuItem.Text = "步数指示：开";
                state.StepIndicator = true;
            }
            Refresh();
        }

        private void 玩家先手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.RenJi1_Click();
            label1.Visible = false;
            label1.Enabled = false;
            timer1.Enabled = false;
            state.aiIndicator = true;
            暂停ToolStripMenuItem.Enabled = false;
            继续ToolStripMenuItem.Enabled = false;
            五手两打关ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = true;
            保存游戏ToolStripMenuItem.Enabled = true;
            timeLabel1.Text = "人机对战中";
            timebar1.Value = 0;
            Refresh();
        }

        private void 玩家后手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state.RenJi2_Click();
            label1.Visible = false;
            label1.Enabled = false;
            timer1.Enabled = false;
            暂停ToolStripMenuItem.Enabled = false;
            继续ToolStripMenuItem.Enabled = false;
            五手两打关ToolStripMenuItem.Enabled = false;
            悔棋ToolStripMenuItem.Enabled = true;
            保存游戏ToolStripMenuItem.Enabled = true;
            state.aiIndicator = false;
            timeLabel1.Text = "人机对战中";
            timebar1.Value = 0;
            Refresh();
            this.CreateGraphics().DrawImage(bl, state.Solution().X * 29 + 7, state.Solution().Y * 29 + 30, 29, 29);
            state.Mou_Click_WithAI(state.Solution().X, state.Solution().Y);
        }

        private void 查看帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            if (label1.Visible == true)
            {
                label1.Visible = false;
                label1.Enabled = false;
            }
            else
            {
                label1.Visible = true;
                label1.Enabled = true;
            }
        }

        private void timeLabel1_Click(object sender, EventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            clock1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (state.gametype == 1 || state.gametype == 2)
            {
                mmx[1] = (e.X - 7) / 29;
                mmy[1] = (e.Y - 30) / 29;
                if (mmx[1] != mmx[0] || mmy[1] != mmy[0])
                {
                    
                    if (mmx[1] >= 0 && mmx[1] < 15 && mmy[1] >= 0 && mmy[1] < 15)
                    {
                        Graphics h = this.CreateGraphics();

                        h.DrawLine(bgpen, mmx[0] * 29 + 7, mmy[0] * 29 + 30, mmx[0] * 29 + 7, mmy[0] * 29 + 35);
                        h.DrawLine(bgpen, mmx[0] * 29 + 7, mmy[0] * 29 + 30, mmx[0] * 29 + 12, mmy[0] * 29 + 30);
                        h.DrawLine(bgpen, (mmx[0] + 1) * 29 + 7, mmy[0] * 29 + 30, (mmx[0] + 1) * 29 + 7, mmy[0] * 29 + 35);
                        h.DrawLine(bgpen, (mmx[0] + 1) * 29 + 7, mmy[0] * 29 + 30, (mmx[0] + 1) * 29 + 2, mmy[0] * 29 + 30);
                        h.DrawLine(bgpen, mmx[0] * 29 + 7, (mmy[0] + 1) * 29 + 30, mmx[0] * 29 + 7, (mmy[0] + 1) * 29 + 25);
                        h.DrawLine(bgpen, mmx[0] * 29 + 7, (mmy[0] + 1) * 29 + 30, mmx[0] * 29 + 12, (mmy[0] + 1) * 29 + 30);
                        h.DrawLine(bgpen, (mmx[0] + 1) * 29 + 7, (mmy[0] + 1) * 29 + 30, (mmx[0] + 1) * 29 + 7, (mmy[0] + 1) * 29 + 25);
                        h.DrawLine(bgpen, (mmx[0] + 1) * 29 + 7, (mmy[0] + 1) * 29 + 30, (mmx[0] + 1) * 29 + 2, (mmy[0] + 1) * 29 + 30);

                        h.DrawLine(bPen, mmx[1] * 29 + 7, mmy[1] * 29 + 30, mmx[1] * 29 + 7, mmy[1] * 29 + 35);
                        h.DrawLine(bPen, mmx[1] * 29 + 7, mmy[1] * 29 + 30, mmx[1] * 29 + 12, mmy[1] * 29 + 30);
                        h.DrawLine(bPen, (mmx[1] + 1) * 29 + 7, mmy[1] * 29 + 30, (mmx[1] + 1) * 29 + 7, mmy[1] * 29 + 35);
                        h.DrawLine(bPen, (mmx[1] + 1) * 29 + 7, mmy[1] * 29 + 30, (mmx[1] + 1) * 29 + 2, mmy[1] * 29 + 30);
                        h.DrawLine(bPen, mmx[1] * 29 + 7, (mmy[1] + 1) * 29 + 30, mmx[1] * 29 + 7, (mmy[1] + 1) * 29 + 25);
                        h.DrawLine(bPen, mmx[1] * 29 + 7, (mmy[1] + 1) * 29 + 30, mmx[1] * 29 + 12, (mmy[1] + 1) * 29 + 30);
                        h.DrawLine(bPen, (mmx[1] + 1) * 29 + 7, (mmy[1] + 1) * 29 + 30, (mmx[1] + 1) * 29 + 7, (mmy[1] + 1) * 29 + 25);
                        h.DrawLine(bPen, (mmx[1] + 1) * 29 + 7, (mmy[1] + 1) * 29 + 30, (mmx[1] + 1) * 29 + 2, (mmy[1] + 1) * 29 + 30);

                        mmx[0] = mmx[1];
                        mmy[0] = mmy[1];
                    }
                }
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



    }
}