using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace five_son_chess
{
    class StateEvaluate
    {
        #region 声明并初始化变量
        public int gametype = 0;//游戏类型
        public int[, ,] map = new int[226, 15, 15];//三维数组做棋局存储
        public int step = 0;//初始步数为0
        public int line = 0;//初始行数为0
        public int list = 0;//初始列数为0
        public int wtg;//下子者标识
        public int time;//时间倒数
        public int or = 0;//连续超时次数
        public bool JinShou;//是否有禁手
        public bool WuShou;//是否有五手两打
        public int WushouStep;//五手两打步数指示
        public int[] Wushoux = new int[3];//五手两打x位置记录
        public int[] Wushouy = new int[3];//五手两打y位置记录
        public Point[] JiShu=new Point[225];//记录每一步位置的point数组
        public bool StepIndicator;
        int AiWhichGo = 0;//ai先手或者后手的记录
        public bool aiIndicator = true;//记录是否为ai行动的指示
        #endregion

        /// <summary>
        /// 判断是否练成五子，由列、行、左下至右上斜向、左上至右下斜向共4个判定组成
        /// </summary>
        /// <param name="tstep"></传递进的当前下子步数>
        /// <param name="tlist"></传递进的当前下子列数>
        /// <param name="tline"></传递进的当前下子行数>
        /// <returns></returns>
        #region 成五
        public int ifFive(int tstep, int tlist, int tline)
        {
            map[tstep, tlist, tline] = tstep % 2 == 0 ? 1 : -100;
            if (ifListFive(tstep, tlist) != 0)
            {
                return ifListFive(tstep, tlist);
            }
            if (ifLineFive(tstep, tline) != 0)
            {
                return ifLineFive(tstep, tline);
            }
            if (ifLTtoRDFive(tstep, tlist, tline) != 0)
            {
                return ifLTtoRDFive(tstep, tlist, tline);
            }
            if (ifLDtoRTFive(tstep, tlist, tline) != 0)
            {
                return ifLDtoRTFive(tstep, tlist, tline);
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 列是否成五
        /// </summary>
        /// <param name="tstep"></传递步数>
        /// <param name="tlist"><传递列数>
        /// <returns></returns>
        #region 列成五
        private int ifListFive(int tstep, int tlist)
        {
            for (int i = 0; i < 11; i++)
            {
                if (map[tstep, tlist, i] + map[tstep, tlist, i + 1] + map[tstep, tlist, i + 2] + map[tstep, tlist, i + 3] + map[tstep, tlist, i + 4] == 5 || map[tstep, tlist, i] + map[tstep, tlist, i + 1] + map[tstep, tlist, i + 2] + map[tstep, tlist, i + 3] + map[tstep, tlist, i + 4] == -500)
                {
                    return map[tstep, tlist, i];
                }
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 行是否成五
        /// </summary>
        /// <param name="tstep"></传递步数>
        /// <param name="tline"></传递行数>
        /// <returns></returns>
        #region 行成五
        private int ifLineFive(int tstep, int tline)
        {
            for (int i = 0; i < 11; i++)
            {
                if (map[tstep, i, tline] + map[tstep, i + 1, tline] + map[tstep, i + 2, tline] + map[tstep, i + 3, tline] + map[tstep, i + 4, tline] == 5 || map[tstep, i, tline] + map[tstep, i + 1, tline] + map[tstep, i + 2, tline] + map[tstep, i + 3, tline] + map[tstep, i + 4, tline] == -500)
                {
                    return map[tstep, i, tline];
                }
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 左下至右上是否成五
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 左下右上成五
        private int ifLDtoRTFive(int tstep, int tlist, int tline)
        {
            int LDRT = tlist + tline;
            if (LDRT < 4 || LDRT > 24)
            {
                return 0;
            }
            if (LDRT <= 14)
            {
                for (int i = 0; i <= LDRT - 4; i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == 5 || map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == -500)
                    {
                        return map[tstep, i, LDRT - i];
                    }
                }
            }
            else
            {
                for (int i = LDRT - 14; i <= 10; i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == 5 || map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == -500)
                    {
                        return map[tstep, i, LDRT - i];
                    }
                }
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 左上至右下是否成五
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 左上右下成五
        private int ifLTtoRDFive(int tstep, int tlist, int tline)
        {
            int LTRD = tline - tlist;
            if (LTRD >= 0)
            {
                for (int i = 0; i <= (14 - LTRD - 4); i++)
                {
                    if (map[tstep, i, LTRD + i] + map[tstep, i + 1, LTRD + i + 1] + map[tstep, i + 2, LTRD + i + 2] + map[tstep, i + 3, LTRD + i + 3] + map[tstep, i + 4, LTRD + i + 4] == 5 || map[tstep, i, LTRD + i] + map[tstep, i + 1, LTRD + i + 1] + map[tstep, i + 2, LTRD + i + 2] + map[tstep, i + 3, LTRD + i + 3] + map[tstep, i + 4, LTRD + i + 4] == -500)
                    {
                        return map[tstep, i, LTRD + i];
                    }
                }
            }
            else
            {
                for (int i = -LTRD; i <= 10; i++)
                {
                    if (map[tstep, i, LTRD + i] + map[tstep, i + 1, LTRD + i + 1] + map[tstep, i + 2, LTRD + i + 2] + map[tstep, i + 3, LTRD + i + 3] + map[tstep, i + 4, LTRD + i + 4] == 5 || map[tstep, i, LTRD + i] + map[tstep, i + 1, LTRD + i + 1] + map[tstep, i + 2, LTRD + i + 2] + map[tstep, i + 3, LTRD + i + 3] + map[tstep, i + 4, LTRD + i + 4] == -500)
                    {
                        return map[tstep, i, LTRD + i];
                    }
                }
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 是否禁手的判断
        /// 先判断禁手的开关状态，然后由当前棋盘状态及下子位置，对黑方4的数目与活3的数目进行统计
        /// 如果满足禁手条件则判为禁手
        /// 通过将落子点的棋盘值改为10这一异常值来表达禁手
        /// 如果不是禁手点则将落子点恢复为0（空值）
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        #region 是否禁手
        public void ifJinShou(int tstep, int tlist, int tline)
        {
            if (JinShou == true)
            {
                int num33 = ifJinShou33(tstep, tlist, tline);
                int num44 = ifJinShou44(tstep, tlist, tline);
                //int i = tlist + 1;
                //int j = tlist - 1;
                //int numofch = 1;
                //if (i < 15)
                //{
                //    while (map[tstep, i, tline] == 0 || map[tstep, i, tline] == 1)
                //    {
                //        if (map[tstep, i, tline] == 1)
                //        {
                //            numofch++;
                //        }
                //        i++;
                //    }
                //}
                //if (j > -1)
                //{
                //    while (map[tstep, j, tline] == 0 || map[tstep, j, tline] == 1)
                //    {
                //        if (map[tstep, j, tline] == 1)
                //        {
                //            numofch++;
                //        }
                //        j--;
                //    }
                //}
                //switch (numofch)
                //{
                //    case 3: num33++;
                //        break;
                //    case 4: num44++;
                //        break;
                //}
                //numofch = 1;

                //i = tline + 1;
                //j = tline - 1;
                //if (i < 15)
                //{
                //    while (map[tstep, tlist, i] == 0 || map[tstep, tlist, i] == 1)
                //    {
                //        if (map[tstep, tlist, i] == 1)
                //        {
                //            numofch++;
                //        }
                //        i++;
                //    }
                //}
                //if (j > -1)
                //{
                //    while (map[tstep, tlist, j] == 0 || map[tstep, tlist, j] == 1)
                //    {
                //        if (map[tstep, tlist, j] == 1)
                //        {
                //            numofch++;
                //        }
                //        j--;
                //    }
                //}
                //switch (numofch)
                //{
                //    case 3: num33++;
                //        break;
                //    case 4: num44++;
                //        break;
                //}
                //numofch = 1;
                if (num44 >= 2 || num33 >= 2)//满足禁手条件之一即为禁手
                {
                    map[tstep, tlist, tline] = 10;
                }
                else
                {
                    map[tstep, tlist, tline] = 0;
                }
            }
        }
        #endregion

        /// <summary>
        /// 找活三的数量
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 33
        private int ifJinShou33(int tstep, int tlist, int tline)
        {
            int NumOfThree = 0;
            map[tstep, tlist, tline] = 1;

            for (int i = 0; i < 10; i++)//按列找活三
            {
                if (map[tstep, tlist, i] + map[tstep, tlist, i + 1] + map[tstep, tlist, i + 2] + map[tstep, tlist, i + 3] + map[tstep, tlist, i + 4] + map[tstep, tlist, i + 5] == 3 && map[tstep, tlist, i] == 0 && map[tstep, tlist, i + 5] == 0 && (tline < i + 5 && tline > i))
                {
                    NumOfThree++;
                    i++;
                }
            }

            for (int i = 0; i < 10; i++)//按行找活三
            {
                if (map[tstep, i, tline] + map[tstep, i + 1, tline] + map[tstep, i + 2, tline] + map[tstep, i + 3, tline] + map[tstep, i + 4, tline] + map[tstep, i + 5, tline] == 3 && map[tstep, i + 5, tline] == 0 && map[tstep, i, tline] == 0 && (tlist < i + 5 && tlist > i))
                {
                    NumOfThree++;
                    i++;
                }
            }

            int LTRD = tlist - tline;//按左上右下找活三

            if (LTRD < 0)
            {
                for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                {
                    if (map[tstep, i, i - LTRD] + map[tstep, i + 1, i - LTRD + 1] + map[tstep, i + 2, i - LTRD + 2] + map[tstep, i + 3, i - LTRD + 3] + map[tstep, i + 4, i - LTRD + 4] + map[tstep, i + 5, i - LTRD + 5] == 3 && map[tstep, i, i - LTRD] == 0 && map[tstep, i + 5, i - LTRD + 5] == 0 && tlist > i && tlist < i + 5)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                {
                    if (map[tstep, i + LTRD, i] + map[tstep, i + LTRD + 1, i + 1] + map[tstep, i + LTRD + 2, i + 2] + map[tstep, i + LTRD + 3, i + 3] + map[tstep, i + LTRD + 4, i + 4] + map[tstep, i + LTRD + 5, i + 5] == 3 && map[tstep, i + LTRD, i] == 0 && map[tstep, i + LTRD + 5, i + 5] == 0 && tlist > i + LTRD && tlist < i + LTRD + 5)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }

            int LDRT = tlist + tline;//按左下右上找活三

            if (LDRT < 14)
            {
                for (int i = 0; i < (LDRT - 4); i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] + map[tstep, i + 5, LDRT - i - 5] == 3 && map[tstep, i, LDRT - i] == 0 && map[tstep, i + 5, LDRT - i - 5] == 0 && tlist > i && tlist < i + 5)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }
            else
            {
                for (int i = Math.Abs(14 - LDRT); i < 10; i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] + map[tstep, i + 5, LDRT - i - 5] == 3 && map[tstep, i, LDRT - i] == 0 && map[tstep, i + 5, LDRT - i - 5] == 0 && tlist > i && tlist < i + 5)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }
            return NumOfThree;
        }
        #endregion

        /// <summary>
        /// 找四的数量
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 44
        private int ifJinShou44(int tstep, int tlist, int tline)
        {
            int NumOfFour = 0;
            map[tstep, tlist, tline] = 1;
            for (int i = 0; i < 11; i++)//按列找四
            {
                if (map[tstep, tlist, i] + map[tstep, tlist, i + 1] + map[tstep, tlist, i + 2] + map[tstep, tlist, i + 3] + map[tstep, tlist, i + 4] == 4 && (tline < i + 5 && tline > i - 1))
                {
                    NumOfFour++;
                    i++;
                }
            }

            for (int i = 0; i < 10; i++)//按行找四
            {
                if (map[tstep, i, tline] + map[tstep, i + 1, tline] + map[tstep, i + 2, tline] + map[tstep, i + 3, tline] + map[tstep, i + 4, tline] == 4 && (tlist < i + 5 && tlist > i - 1))
                {
                    NumOfFour++;
                    i++;
                }
            }

            int LTRD = tlist - tline;//按左上右下找四

            if (LTRD < 0)
            {
                for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                {
                    if (map[tstep, i, i - LTRD] + map[tstep, i + 1, i - LTRD + 1] + map[tstep, i + 2, i - LTRD + 2] + map[tstep, i + 3, i - LTRD + 3] + map[tstep, i + 4, i - LTRD + 4] == 4 && tlist > i - 1 && tlist < i + 5)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                {
                    if (map[tstep, i + LTRD, i] + map[tstep, i + LTRD + 1, i + 1] + map[tstep, i + LTRD + 2, i + 2] + map[tstep, i + LTRD + 3, i + 3] + map[tstep, i + LTRD + 4, i + 4] == 4 && tlist > i + LTRD && tlist < i - 1 + LTRD + 5)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }

            int LDRT = tlist + tline;//按左下右上找四

            if (LDRT < 14)
            {
                for (int i = 0; i < (LDRT - 3); i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == 4 && tlist > i - 1 && tlist < i + 5)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }
            else
            {
                for (int i = Math.Abs(14 - LDRT); i < 11; i++)
                {
                    if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] == 4 && tlist > i - 1 && tlist < i + 5)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }
            return NumOfFour;
        }
        #endregion

        /// <summary>
        /// 长连禁手判断，在优先级上应高于成5（长连必满足成5，但为禁手)
        /// 因此与禁手判断分开处理
        /// 与成五类似，按四个方向处理
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        #region 长连
        private bool ifChangLian(int tstep, int x, int y)
        {
            if (JinShou == true)
            {
                map[tstep, x, y] = 1;
                int left = x - 4 >= 0 ? x - 4 : 0;
                int right = x + 4 <= 14 ? x + 4 : 14;
                int down = y - 4 >= 0 ? y - 4 : 0;
                int top = y + 4 <= 14 ? y + 4 : 14;
                int value = 0;
                for (int i = left; i <= right; i++)//判断横向长连
                {
                    value = value + Math.Abs(map[tstep, i, y]);
                }
                value = value % 100;
                if (value > 5)
                {
                    for (int i = left; i <= right - 5; i++)
                    {
                        value = 0;
                        for (int j = 0; j < 6; j++)
                        {
                            value = value + map[tstep, i + j, y];
                            if (value > 5)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                }
                value = 0;
                for (int i = down; i <= top; i++)//纵向长连
                {
                    value = value + Math.Abs(map[tstep, x, i]);
                }
                value = value % 100;
                if (value > 5)
                {
                    for (int i = down; i <= top - 5; i++)
                    {
                        value = 0;
                        for (int j = 0; j < 6; j++)
                        {
                            value = value + map[tstep, x, i + j];
                            if (value > 5)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                }
                value = 0;
                for (int LTRD = -9; LTRD < 10; LTRD++)//按左上右下找
                {
                    if (LTRD < 0)
                    {
                        for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                        {
                            if (map[tstep, i, i - LTRD] + map[tstep, i + 1, i - LTRD + 1] + map[tstep, i + 2, i - LTRD + 2] + map[tstep, i + 3, i - LTRD + 3] + map[tstep, i + 4, i - LTRD + 4] + map[tstep, i + 5, i - LTRD + 5] == 6)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                        {
                            if (map[tstep, i + LTRD, i] + map[tstep, i + LTRD + 1, i + 1] + map[tstep, i + LTRD + 2, i + 2] + map[tstep, i + LTRD + 3, i + 3] + map[tstep, i + LTRD + 4, i + 4] + map[tstep, i + LTRD + 5, i + 5] == 6)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                }


                for (int LDRT = 5; LDRT < 24; LDRT++) //按左下右上找
                {
                    if (LDRT < 14)
                    {
                        for (int i = 0; i < (LDRT - 4); i++)
                        {
                            if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] + map[tstep, i + 5, LDRT - i - 5] == 6)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                    else
                    {
                        for (int i = Math.Abs(14 - LDRT); i < 10; i++)
                        {
                            if (map[tstep, i, LDRT - i] + map[tstep, i + 1, LDRT - i - 1] + map[tstep, i + 2, LDRT - i - 2] + map[tstep, i + 3, LDRT - i - 3] + map[tstep, i + 4, LDRT - i - 4] + map[tstep, i + 5, LDRT - i - 5] == 6)
                            {
                                map[tstep, x, y] = 10;
                                return true;
                            }
                        }
                    }
                }
                map[tstep, x, y] = 0;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 当五手两打功能开启时，进行的方法，主要是弹出提示
        /// </summary>
        #region 5守2打
        public void Move_WuShou()
        {
            switch (WushouStep)
            {
                case 0:
                    MessageBox.Show("五手两打：请黑方选择第一个下子位置：", "五手两打", MessageBoxButtons.OK, MessageBoxIcon.None);
                    time = 30;
                    break;
                case 1:
                    MessageBox.Show("五手两打：请黑方选择第二个下子位置：", "五手两打", MessageBoxButtons.OK, MessageBoxIcon.None);
                    time = 30;
                    break;
                case 2:
                    MessageBox.Show("五手两打：请白方选择想要留下的棋子：", "五手两打", MessageBoxButtons.OK, MessageBoxIcon.None);
                    time = 30;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 当按下双人对战按钮时对各个指示器、棋盘状态、计数器赋上相应的值
        /// </summary>
        #region 双人初始化
        public void RenRen_Click()
        {
            gametype = 1;
            step = 0;
            for (int i = 0; i < 225; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        map[i, j, k] = 0;
                    }
                }
            }
            time = 30;
            wtg = 0;
        }
        #endregion

        /// <summary>
        /// 按下人机对战按钮(玩家先手)时对各个指示器、棋盘状态、计数器赋上相应的值
        /// </summary>
        #region 人机（人先手）初始化
        public void RenJi1_Click()
        {
            WuShou = false;
            gametype = 2;
            AiWhichGo = 1;
            step = 0;
            for (int i = 0; i < 225; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        map[i, j, k] = 0;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 按下人机对战按钮(玩家后手)时对各个指示器、棋盘状态、计数器赋上相应的值
        /// </summary>
        #region 人机（人后手）初始化
        public void RenJi2_Click()
        {
            WuShou = false;
            gametype = 2;
            AiWhichGo = 2;
            step = 0;
            for (int i = 0; i < 225; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    for (int k = 0; k < 15; k++)
                    {
                        map[i, j, k] = 0;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 双人对战时，在窗体上按下鼠标后所进行的方法
        /// </summary>
        /// <param name="list"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        #region 双人点鼠标
        public int Mou_Click(int list, int line)
        {
            if (step <= 224)
            {
                if (step != 4 || WuShou == false)
                {
                    if (list >= 0 && list < 15 && line >= 0 && line < 15 && map[step, list, line] != 1 && map[step, list, line] != -100 && gametype != 0 && gametype < 3)//下子，为该step及之后的每一步中都加入新下的子
                    {
                        if (step % 2 == 0)
                        {
                            if (!ifChangLian(step, list, line))
                            {
                                if (ifFive(step, list, line) != 1 && JinShou == true)
                                {
                                    map[step, list, line] = 0;
                                    ifJinShou(step, list, line);
                                }
                            }
                            if (map[step, list, line] != 10 || JinShou == false)
                            {
                                JiShu[step].X = list * 29 + 7;
                                JiShu[step].Y = line * 29 + 30;
                                for (int i = step; i < 225; i++)
                                {
                                    map[i, list, line] = 1;
                                }
                            }
                            else if (map[step, list, line] == 10)
                            {
                                if (MessageBox.Show("黑棋禁手！点击是结束游戏，白方胜利！点击否黑方重新下子！", "禁手！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    gametype = 0;
                                    return 666;
                                }
                                else
                                {
                                    map[step, list, line] = 0;
                                    return 233;
                                }
                            }
                        }
                        else
                        {
                            JiShu[step].X = list * 29 + 7;
                            JiShu[step].Y = line * 29 + 30;
                            for (int i = step; i < 225; i++)
                            {
                                map[i, list, line] = -100;
                            }
                        }
                        switch (ifFive(step, list, line))//判断是否五子
                        {
                            case 0: //无
                                if (map[step, list, line] == 1 || map[step, list, line] == -100)
                                {
                                    step++;
                                    if (step == 4 && WuShou == true)
                                    {
                                        WushouStep = 0;
                                        Move_WuShou();
                                        return 5;
                                    }
                                }
                                break;
                            case 1://黑成五子
                                step++;
                                return 1;
                            case -100: //白成五子
                                step++;
                                return -100;
                        }
                    }
                    else
                    {
                        return 233;
                    }
                }
                else if (list >= 0 && list < 15 && line >= 0 && line < 15 && map[step, list, line] != 1 && map[step, list, line] != -100 && gametype != 0 && gametype < 3)//下子，为该step及之后的每一步中都加入新下的子
                {
                    if (WushouStep < 2)
                    {
                        Wushoux[WushouStep] = list;
                        Wushouy[WushouStep] = line;
                        WushouStep++;
                        Move_WuShou();
                        return 5;
                    }
                    else if ((list == Wushoux[0] && line == Wushouy[0]) || (list == Wushoux[1] && line == Wushouy[1]))
                    {
                        JiShu[step].X = list * 29 + 7;
                        JiShu[step].Y = line * 29 + 30;
                        for (int i = step; i < 225; i++)
                        {
                            map[i, list, line] = 1;
                        }
                        step++;
                        WushouStep = 0;
                        return 5;
                    }
                }

                //int[,] temp = new int[15, 15];
                //for (int i = 0; i < 15; i++)
                //{
                //    for (int j = 0; j < 15; j++)
                //    {
                //        temp[i, j] = map[step, i, j];
                //    }
                //}
                //int c = analyse(temp, -100);
            }
            else
            {
                MessageBox.Show("和棋！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// 人机对战时，在窗体上按下鼠标后所进行的方法
        /// </summary>
        /// <param name="list"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        #region 人机点鼠标
        public int Mou_Click_WithAI(int list, int line)//有ai时按下鼠标
        {
            if (step > 224)
            {
                MessageBox.Show("和棋！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                if (list >= 0 && list < 15 && line >= 0 && line < 15 && map[step, list, line] != 1 && map[step, list, line] != -100)//下子，为该step及之后的每一步中都加入新下的子
                {
                    if (step % 2 == 0)
                    {
                        if (!ifChangLian(step, list, line))
                        {
                            if (ifFive(step, list, line) != 1 && JinShou == true)
                            {
                                map[step, list, line] = 0;
                                ifJinShou(step, list, line);
                            }
                        }
                        if (map[step, list, line] != 10 || JinShou == false)
                        {
                            JiShu[step].X = list * 29 + 7;
                            JiShu[step].Y = line * 29 + 30;
                            for (int i = step; i < 225; i++)
                            {
                                map[i, list, line] = 1;
                            }
                        }
                        else if (map[step, list, line] == 10)
                        {
                            if (MessageBox.Show("黑棋禁手！点击是结束游戏，白方胜利！点击否黑方重新下子！", "禁手！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                gametype = 0;
                                return 666;
                            }
                            else
                            {
                                map[step, list, line] = 0;
                                return 233;
                            }
                        }
                    }
                    else
                    {
                        JiShu[step].X = list * 29 + 7;
                        JiShu[step].Y = line * 29 + 30;
                        for (int i = step; i < 225; i++)
                        {
                            map[i, list, line] = -100;
                        }
                    }
                    switch (ifFive(step, list, line))//判断是否五子
                    {
                        case 0: //无
                            if (map[step, list, line] == 1 || map[step, list, line] == -100)
                            {
                                step++;
                                if (step < 225)
                                {
                                    if (aiIndicator)
                                    {
                                        aiIndicator = false;
                                        Point temp = Solution();
                                        return Mou_Click_WithAI(temp.X, temp.Y);
                                    }
                                    else
                                    {
                                        aiIndicator = true;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("和棋！", "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.None);
                                }
                            }
                            break;
                        case 1://黑成五子
                            step++;
                            return 1;
                        case -100: //白成五子
                            step++;
                            return -100;
                    }
                }
                else
                {
                    return 233;
                }
            }

            //int[,] temp = new int[15, 15];
            //for (int i = 0; i < 15; i++)
            //{
            //    for (int j = 0; j < 15; j++)
            //    {
            //        temp[i, j] = map[step, i, j];
            //    }
            //}
            //int c = analyse(temp, -100);
            return 0;
        }
        #endregion

        /// <summary>
        /// 当按下悔棋按钮后进行的方法
        /// 根据游戏类型的不同设有不同的悔棋方法
        /// </summary>
        /// <returns></returns>
        #region 悔棋
        public bool HuiQi_Click()//按下悔棋
        {
            if (gametype < 0)
            {
                gametype += 3;
            }
            if (gametype == 1)
            {
                if (step > 0)
                {
                    if (step > 1)
                    {
                        step = step - 2;
                        for (int i = step + 1; i < 225; i++)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                for (int k = 0; k < 15; k++)
                                {
                                    map[i, j, k] = map[step, j, k];
                                }
                            }
                        }
                        step++;
                        if (step == 4 && WuShou == true)
                        {
                            Move_WuShou();
                        }
                        return true;
                    }
                    else
                    {
                        for (int i = 0; i < 225; i++)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                for (int k = 0; k < 15; k++)
                                {
                                    map[i, j, k] = 0;
                                }
                            }
                        }
                        step = 0;
                        if (step == 4 && WuShou == true)
                        {
                            Move_WuShou();
                        }
                        return true;
                    }
                }
            }
            else if (gametype == 2)
            {
                if (step > 2)
                {
                    step = step - 3;
                    for (int i = step + 1; i < 225; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            for (int k = 0; k < 15; k++)
                            {
                                map[i, j, k] = map[step, j, k];
                            }
                        }
                    }
                    step++;
                    return true;
                }
                else
                {
                    for (int i = 0; i < 225; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            for (int k = 0; k < 15; k++)
                            {
                                map[i, j, k] = 0;
                            }
                        }
                    }
                    step = 0;
                    return true;
                }
            }
            return false;
        }
        #endregion

        /// <summary>
        /// ai运算部分
        /// 模拟棋盘每个地方下子对黑白双方产生的影响，对自己越有利的分数越高
        /// 根据得分选择下子位置
        /// </summary>
        /// <returns></returns>
        #region ai找点
        public Point Solution()
        {
            Point tempP = new Point(0, 0);
            int[,] BAppraise = new int[15, 15];
            int[,] WAppraise = new int[15, 15];
            double[,] TAppraise = new double[15, 15];
            int[] xb = new int[255];
            int[] yb = new int[255];
            int nob = 0;
            if (AiWhichGo == 2 && step == 0)
            {
                return new Point(7, 7);
            }
            //if (step < 3)
            //{
            //    for (int i = 6; i < 9; i++)
            //    {
            //        for (int j = 6; j < 9; j++)
            //        {
            //            if (map[step, i, j] == 0)
            //            {
            //                BAppraise[i, j] = map_banalyse(step, i, j);
            //                WAppraise[i, j] = map_wanalyse(step, i, j);
            //            }
            //            else
            //            {
            //                BAppraise[i, j] = -1000;
            //                WAppraise[i, j] = -1000;
            //            }
            //            TAppraise[i, j] = BAppraise[i, j] + WAppraise[i, j];
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < 15; i++)
            //    {
            //        for (int j = 0; j < 15; j++)
            //        {
            //            if (map[step, i, j] == 0)
            //            {
            //                BAppraise[i, j] = map_banalyse(step, i, j);
            //                WAppraise[i, j] = map_wanalyse(step, i, j);
            //            }
            //            else
            //            {
            //                BAppraise[i, j] = -1000;
            //                WAppraise[i, j] = -1000;
            //            }
            //            TAppraise[i, j] = BAppraise[i, j] + WAppraise[i, j];
            //        }
            //    }
            //}
            if (step % 2 == 0)
            {
                if (step < 3)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            if (map[step, i, j] == 0)
                            {
                                BAppraise[i, j] = map_banalyse(step, i, j);
                                WAppraise[i, j] = map_wanalyse(step, i, j);
                            }
                            else
                            {
                                BAppraise[i, j] = -1000;
                                WAppraise[i, j] = -1000;
                            }
                            TAppraise[i, j] = 1.1 * BAppraise[i, j] + WAppraise[i, j];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (map[step, i, j] == 0)
                            {
                                BAppraise[i, j] = map_banalyse(step, i, j);
                                WAppraise[i, j] = map_wanalyse(step, i, j);
                            }
                            else
                            {
                                BAppraise[i, j] = -1000;
                                WAppraise[i, j] = -1000;
                            }
                            TAppraise[i, j] = 1.1 * BAppraise[i, j] + WAppraise[i, j];
                        }
                    }
                }
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (BAppraise[i, j] >= 1000000)
                        {
                            tempP.X = i;
                            tempP.Y = j;
                            return tempP;
                        }
                        //if (BAppraise[i, j] > BAppraise[xb, yb])
                        //{
                        //    xb = i;
                        //    yb = j;
                        //}
                        //if (BAppraise[i, j] == BAppraise[xb, yb] && TAppraise[i, j] > TAppraise[xb, yb])
                        //{
                        //    xb = i;
                        //    yb = j;
                        //}
                        //if (WAppraise[i, j] > WAppraise[xw, yw])
                        //{
                        //    xw = i;
                        //    yw = j;
                        //}
                        //if (WAppraise[i, j] == WAppraise[xw, yw] && TAppraise[i, j] > TAppraise[xw, yw])
                        //{
                        //    xw = i;
                        //    yw = j;
                        //}
                        if (TAppraise[i, j] > TAppraise[xb[0], yb[0]])
                        {
                            for (int k = 0; k < nob + 1; k++)
                            {
                                xb[nob] = 0;
                                yb[nob] = 0;
                            }
                            nob = 0;
                            xb[nob] = i;
                            yb[nob] = j;
                        }
                        else if (TAppraise[i, j] == TAppraise[xb[0], yb[0]])
                        {
                            nob++;
                            xb[nob] = i;
                            yb[nob] = j;
                        }
                    }
                }
                //if (WAppraise[xw, yw] >= 1000000)
                //{
                //    tempP.X = xw;
                //    tempP.Y = yw;
                //}
                //else if (BAppraise[xb, yb] >= 60000)
                //{
                //    tempP.X = xb;
                //    tempP.Y = yb;
                //}
                //else if (BAppraise[xb, yb] >= WAppraise[xw, yw])
                //{
                //    tempP.X = xb;
                //    tempP.Y = yb;
                //}
                //else
                //{
                //    tempP.X = xw;
                //    tempP.Y = yw;
                //}
                Random ran = new Random();
                int zzz=ran.Next(nob + 1);
                tempP.X = xb[zzz];
                tempP.Y = yb[zzz];
                return tempP;
            }
            else
            {
                if (step < 3)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int j = 6; j < 9; j++)
                        {
                            if (map[step, i, j] == 0)
                            {
                                BAppraise[i, j] = map_banalyse(step, i, j);
                                WAppraise[i, j] = map_wanalyse(step, i, j);
                            }
                            else
                            {
                                BAppraise[i, j] = -1000;
                                WAppraise[i, j] = -1000;
                            }
                            TAppraise[i, j] = BAppraise[i, j] + 1.1 * WAppraise[i, j];
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 15; i++)
                    {
                        for (int j = 0; j < 15; j++)
                        {
                            if (map[step, i, j] == 0)
                            {
                                BAppraise[i, j] = map_banalyse(step, i, j);
                                WAppraise[i, j] = map_wanalyse(step, i, j);
                            }
                            else
                            {
                                BAppraise[i, j] = -1000;
                                WAppraise[i, j] = -1000;
                            }
                            TAppraise[i, j] = BAppraise[i, j] + 1.1 * WAppraise[i, j];
                        }
                    }
                }
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (WAppraise[i, j] == 1000000)
                        {
                            tempP.X = i;
                            tempP.Y = j;
                            return tempP;
                        }
                        //if (BAppraise[i, j] > BAppraise[xb, yb])
                        //{
                        //    xb = i;
                        //    yb = j;
                        //}
                        //if (BAppraise[i, j] == BAppraise[xb, yb] && TAppraise[i, j] > TAppraise[xb, yb])
                        //{
                        //    xb = i;
                        //    yb = j;
                        //}
                        //if (WAppraise[i, j] > WAppraise[xw, yw])
                        //{
                        //    xw = i;
                        //    yw = j;
                        //}
                        //if (WAppraise[i, j] == WAppraise[xw, yw] && TAppraise[i, j] > TAppraise[xw, yw])
                        //{
                        //    xw = i;
                        //    yw = j;
                        //}
                        if (TAppraise[i, j] > TAppraise[xb[0], yb[0]])
                        {
                            for (int k = 0; k < nob + 1; k++)
                            {
                                xb[nob] = 0;
                                yb[nob] = 0;
                            }
                            nob = 0;
                            xb[nob] = i;
                            yb[nob] = j;
                        }
                        else if (TAppraise[i, j] == TAppraise[xb[0], yb[0]])
                        {
                            nob++;
                            xb[nob] = i;
                            yb[nob] = j;
                        }
                    }
                }
                //if (BAppraise[xb, yb] >= 1000000)
                //{
                //    tempP.X = xb;
                //    tempP.Y = yb;
                //}
                //else if (WAppraise[xw, yw] >= 60000)
                //{
                //    tempP.X = xw;
                //    tempP.Y = yw;
                //}
                //else if (WAppraise[xw, yw] >= BAppraise[xb, yb])
                //{
                //    tempP.X = xw;
                //    tempP.Y = yw;
                //}
                //else
                //{
                //    tempP.X = xb;
                //    tempP.Y = yb;
                //}
                Random ran = new Random();
                int zzz = ran.Next(nob + 1);
                tempP.X = xb[zzz];
                tempP.Y = yb[zzz];
                return tempP;
            }
        }
        #endregion

        /// <summary>
        /// 黑方棋局评估方法
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 黑棋评估
        private int map_banalyse(int tstep,int tlist,int tline)
        {
            if (tstep % 2 != 0)
            {
                tstep++;
            }
            map[tstep, tlist, tline] = 1;
            if (ifFive(tstep, tlist, tline) != 0)//成五
            {
                map[tstep, tlist, tline] = 0;
                return 1000000;
            }
            map[tstep, tlist, tline] = 0;
            int t1;
            int[,] tm = new int[15, 15];
            int[,] tm1 = new int[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tm[i, j] = map[tstep, i, j];
                    tm1[i, j] = map[tstep, i, j];
                }
            }
            if (JinShou == true)
            {
                ifJinShou(tstep, tlist, tline);
            }
            if (map[tstep, tlist, tline] == 0)
            {
                tm[tlist, tline] = 1;
                t1 = analyse(tm, tm1, 1, tstep, tlist, tline);
                return t1;
            }
            else
            {
                map[tstep, tlist, tline] = 0;
                return -1000;
            }
        }
        #endregion

        /// <summary>
        /// 白方棋局评估方法
        /// </summary>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 白棋评估
        private int map_wanalyse(int tstep, int tlist, int tline)
        {
            if (tstep % 2 == 0)
            {
                tstep++;
            }
            map[tstep, tlist, tline] = -100;
            if (ifFive(tstep, tlist, tline) != 0)//成五
            {
                map[tstep, tlist, tline] = 0;
                return 1000000;
            }
            int t1;
            int[,] tm = new int[15, 15];
            int[,] tm1 = new int[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tm[i, j] = map[tstep, i, j];
                    tm1[i, j] = map[tstep - 1, i, j];
                }
            }
            t1 = analyse(tm, tm1, -100, tstep, tlist, tline);
            map[tstep, tlist, tline] = 0;
            return t1;
        }
        #endregion

        /// <summary>
        /// 棋局评估函数
        /// 根据活四、冲四、活三、眠三、活二数量加权求和得到棋局的评分
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="tm1"></param>
        /// <param name="pt"></param>
        /// <param name="tstep"></param>
        /// <param name="tlist"></param>
        /// <param name="tline"></param>
        /// <returns></returns>
        #region 评估
        private int analyse(int[,] tm,int[,] tm1, int pt,int tstep, int tlist, int tline)
        {
            
            int HuoFour = CountHuoFour(tm, pt) - CountHuoFour(tm1, pt);//成活四
            if (HuoFour < 0)
            {
                HuoFour = 0;
            }
            int SiFour = CountSiFour(tm, pt) - CountSiFour(tm1, pt);//成冲四
            if (SiFour < 0)
            {
                SiFour = 0;
            }
            int HuoThree = CountHuoThree(tm, pt) - CountHuoThree(tm1, pt);//成活三
            if (HuoThree < 0)
            {
                HuoThree = 0;
            }
            int MianSan = CountMianSan(tm, pt) - CountMianSan(tm1, pt);//成眠三
            if (MianSan < 0)
            {
                MianSan = 0;
            }
            int HuoEr = CountHuoEr(tm, pt) - CountHuoEr(tm1, pt);//成活二
            if (HuoEr < 0)
            {
                HuoEr = 0;
            }
            return HuoFour*100000+SiFour*60000+HuoThree*30001+MianSan*9998+HuoEr*4998;
        }
        #endregion

        /// <summary>
        /// 活四数量统计
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        #region 找活四
        private int CountHuoFour(int[,] tm, int pt)
        {
            int NumOfHuoFour = 0;
            for (int tlist = 0; tlist < 15; tlist++)
            {
                for (int i = 0; i < 10; i++)//按列找活四
                {
                    if (tm[tlist, i] + tm[tlist, i + 1] + tm[tlist, i + 2] + tm[tlist, i + 3] + tm[tlist, i + 4] + tm[tlist, i + 5] == 4 * pt && tm[tlist, i] == 0 && tm[tlist, i + 5] == 0)
                    {
                        NumOfHuoFour++;
                        i++;
                    }
                }
            }

            for (int tline = 0; tline < 15; tline++)
            {
                for (int i = 0; i < 10; i++)//按行找活四
                {
                    if (tm[i, tline] + tm[i + 1, tline] + tm[i + 2, tline] + tm[i + 3, tline] + tm[i + 4, tline] + tm[i + 5, tline] == 4 * pt && tm[i + 5, tline] == 0 && tm[i, tline] == 0)
                    {
                        NumOfHuoFour++;
                        i++;
                    }
                }
            }

            for (int LTRD = 9; LTRD > -10; LTRD--)//按左上右下找活四
            {
                if (LTRD < 0)
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i, i - LTRD] + tm[i + 1, i - LTRD + 1] + tm[i + 2, i - LTRD + 2] + tm[i + 3, i - LTRD + 3] + tm[i + 4, i - LTRD + 4] + tm[i + 5, i - LTRD + 5] == 4 * pt && tm[i, i - LTRD] == 0 && tm[i + 5, i - LTRD + 5] == 0)
                        {
                            NumOfHuoFour++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i + LTRD, i] + tm[i + LTRD + 1, i + 1] + tm[i + LTRD + 2, i + 2] + tm[i + LTRD + 3, i + 3] + tm[i + LTRD + 4, i + 4] + tm[i + LTRD + 5, i + 5] == 4 * pt && tm[i + LTRD, i] == 0 && tm[i + LTRD + 5, i + 5] == 0)
                        {
                            NumOfHuoFour++;
                            i++;
                        }
                    }
                }
            }


            for (int LDRT = 5; LDRT < 24; LDRT++)
            {
                if (LDRT < 14)//按左下右上找活四
                {
                    for (int i = 0; i < (LDRT - 4); i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 4 * pt && tm[i, LDRT - i] == 0 && tm[i + 5, LDRT - i - 5] == 0)
                        {
                            NumOfHuoFour++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = Math.Abs(14 - LDRT); i < 10; i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 4 * pt && tm[i, LDRT - i] == 0 && tm[i + 5, LDRT - i - 5] == 0)
                        {
                            NumOfHuoFour++;
                            i++;
                        }
                    }
                }
            }
            if (NumOfHuoFour > 0)
                return NumOfHuoFour;
            else
                return 0;
        }
        #endregion

        /// <summary>
        /// 冲四数量统计
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        #region 找冲四
        private int CountSiFour(int[,] tm, int pt)
        {
            int NumOfFour = 0;
            for (int tlist = 0; tlist < 15; tlist++)//按列找四
            {
                for (int i = 0; i < 11; i++)
                {
                    if (tm[tlist, i] + tm[tlist, i + 1] + tm[tlist, i + 2] + tm[tlist, i + 3] + tm[tlist, i + 4] == 4 * pt)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }

            for (int tline = 0; tline < 15; tline++)//按行找四
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[i, tline] + tm[i + 1, tline] + tm[i + 2, tline] + tm[i + 3, tline] + tm[i + 4, tline] == 4 * pt)
                    {
                        NumOfFour++;
                        i++;
                    }
                }
            }

            for (int LTRD = -4; LTRD < 10; LTRD++)//按左上右下找四
            {
                if (LTRD < 0)
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i, i - LTRD] + tm[i + 1, i - LTRD + 1] + tm[i + 2, i - LTRD + 2] + tm[i + 3, i - LTRD + 3] + tm[i + 4, i - LTRD + 4] == 4 * pt)
                        {
                            NumOfFour++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i + LTRD, i] + tm[i + LTRD + 1, i + 1] + tm[i + LTRD + 2, i + 2] + tm[i + LTRD + 3, i + 3] + tm[i + LTRD + 4, i + 4] == 4 * pt)
                        {
                            NumOfFour++;
                            i++;
                        }
                    }
                }
            }


            for (int LDRT = 4; LDRT < 25; LDRT++) //按左下右上找四
            {
                if (LDRT < 14)
                {
                    for (int i = 0; i < (LDRT - 3); i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] == 4 * pt)
                        {
                            NumOfFour++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = Math.Abs(14 - LDRT); i < 11; i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] == 4 * pt)
                        {
                            NumOfFour++;
                            i++;
                        }
                    }
                }
            }
                return NumOfFour;
        }
        #endregion

        /// <summary>
        /// 活三数量统计
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        #region 找活三
        private int CountHuoThree(int[,] tm, int pt)
        {
            int NumOfThree = 0;
            for (int tlist = 0; tlist < 15; tlist++)//按列找活三
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[tlist, i] + tm[tlist, i + 1] + tm[tlist, i + 2] + tm[tlist, i + 3] + tm[tlist, i + 4] + tm[tlist, i + 5] == 3 * pt && tm[tlist, i] == 0 && tm[tlist, i + 5] == 0)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }

            for (int tline = 0; tline < 15; tline++)//按行找活三
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[i, tline] + tm[i + 1, tline] + tm[i + 2, tline] + tm[i + 3, tline] + tm[i + 4, tline] + tm[i + 5, tline] == 3 * pt && tm[i + 5, tline] == 0 && tm[i, tline] == 0)
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }

            for (int LTRD = -9; LTRD < 10; LTRD++) //按左上右下找活三
            {
                if (LTRD < 0)
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i, i - LTRD] + tm[i + 1, i - LTRD + 1] + tm[i + 2, i - LTRD + 2] + tm[i + 3, i - LTRD + 3] + tm[i + 4, i - LTRD + 4] + tm[i + 5, i - LTRD + 5] == 3 * pt && tm[i, i - LTRD] == 0 && tm[i + 5, i - LTRD + 5] == 0)
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i + LTRD, i] + tm[i + LTRD + 1, i + 1] + tm[i + LTRD + 2, i + 2] + tm[i + LTRD + 3, i + 3] + tm[i + LTRD + 4, i + 4] + tm[i + LTRD + 5, i + 5] == 3 * pt && tm[i + LTRD, i] == 0 && tm[i + LTRD + 5, i + 5] == 0)
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
            }

            for (int LDRT = 5; LDRT < 24; LDRT++)//按左下右上找活三
            {
                if (LDRT < 14)
                {
                    for (int i = 0; i < (LDRT - 4); i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 3 * pt && tm[i, LDRT - i] == 0 && tm[i + 5, LDRT - i - 5] == 0)
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = Math.Abs(14 - LDRT); i < 10; i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 3 * pt && tm[i, LDRT - i] == 0 && tm[i + 5, LDRT - i - 5] == 0)
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
            }
            return NumOfThree;
        }
        #endregion

        /// <summary>
        /// 眠三数量统计
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        #region 找眠三
        private int CountMianSan(int[,] tm, int pt)
        {
            int NumOfThree = 0;
            for (int tlist = 0; tlist < 15; tlist++)//按列找眠三
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[tlist, i] + tm[tlist, i + 1] + tm[tlist, i + 2] + tm[tlist, i + 3] + tm[tlist, i + 4] + tm[tlist, i + 5] == 3 * pt + (-100 / pt) && tm[tlist, i] == (-100 / pt) || tm[tlist, i + 5] == (-100 / pt))
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }

            for (int tline = 0; tline < 15; tline++)//按行找眠三
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[i, tline] + tm[i + 1, tline] + tm[i + 2, tline] + tm[i + 3, tline] + tm[i + 4, tline] + tm[i + 5, tline] == 3 * pt + (-100 / pt) && tm[i + 5, tline] == (-100 / pt) || tm[i, tline] == (-100 / pt))
                    {
                        NumOfThree++;
                        i++;
                    }
                }
            }

            for (int LTRD = -9; LTRD < 10; LTRD++) //按左上右下找眠三
            {
                if (LTRD < 0)
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i, i - LTRD] + tm[i + 1, i - LTRD + 1] + tm[i + 2, i - LTRD + 2] + tm[i + 3, i - LTRD + 3] + tm[i + 4, i - LTRD + 4] + tm[i + 5, i - LTRD + 5] == 3 * pt + (-100 / pt) && tm[i, i - LTRD] == (-100 / pt) || tm[i + 5, i - LTRD + 5] == (-100 / pt))
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i + LTRD, i] + tm[i + LTRD + 1, i + 1] + tm[i + LTRD + 2, i + 2] + tm[i + LTRD + 3, i + 3] + tm[i + LTRD + 4, i + 4] + tm[i + LTRD + 5, i + 5] == 3 * pt + (-100 / pt) && tm[i + LTRD, i] == (-100 / pt) || tm[i + LTRD + 5, i + 5] == (-100 / pt))
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
            }

            for (int LDRT = 5; LDRT < 24; LDRT++)//按左下右上找眠三
            {
                if (LDRT < 14)
                {
                    for (int i = 0; i < (LDRT - 4); i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 3 * pt + (-100 / pt) && tm[i, LDRT - i] == (-100 / pt) || tm[i + 5, LDRT - i - 5] == (-100 / pt))
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = Math.Abs(14 - LDRT); i < 10; i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] + tm[i + 5, LDRT - i - 5] == 3 * pt + (-100 / pt) && tm[i, LDRT - i] == (-100 / pt) || tm[i + 5, LDRT - i - 5] == (-100 / pt))
                        {
                            NumOfThree++;
                            i++;
                        }
                    }
                }
            }
            return NumOfThree;
        }
        #endregion

        /// <summary>
        /// 活二数量统计
        /// </summary>
        /// <param name="tm"></param>
        /// <param name="pt"></param>
        /// <returns></returns>
        #region 找活二
        private int CountHuoEr(int[,] tm, int pt)
        {
            int NumOfEr = 0;
            for (int tlist = 0; tlist < 15; tlist++)
            {
                for (int i = 0; i < 11; i++)
                {
                    if (tm[tlist, i] + tm[tlist, i + 1] + tm[tlist, i + 2] + tm[tlist, i + 3] + tm[tlist, i + 4] == 2 * pt && tm[tlist, i] + tm[tlist, i + 4] == 0)
                    {
                        NumOfEr++;
                        i++;
                    }
                }
            }

            for (int tline = 0; tline < 15; tline++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (tm[i, tline] + tm[i + 1, tline] + tm[i + 2, tline] + tm[i + 3, tline] + tm[i + 4, tline] == 2 * pt && tm[i + 4, tline] + tm[i, tline] == 0)
                    {
                        NumOfEr++;
                        i++;
                    }
                }
            }

            for (int LTRD = -4; LTRD < 10; LTRD++)
            {
                if (LTRD < 0)
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i, i - LTRD] + tm[i + 1, i - LTRD + 1] + tm[i + 2, i - LTRD + 2] + tm[i + 3, i - LTRD + 3] + tm[i + 4, i - LTRD + 4] == 2 * pt && tm[i + 4, i - LTRD + 4] + tm[i, i - LTRD] == 0)
                        {
                            NumOfEr++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < (10 - Math.Abs(LTRD)); i++)
                    {
                        if (tm[i + LTRD, i] + tm[i + LTRD + 1, i + 1] + tm[i + LTRD + 2, i + 2] + tm[i + LTRD + 3, i + 3] + tm[i + LTRD + 4, i + 4] == 2 * pt && tm[i + LTRD + 4, i + 4] + tm[i + LTRD, i] == 0)
                        {
                            NumOfEr++;
                            i++;
                        }
                    }
                }
            }


            for (int LDRT = 4; LDRT < 25; LDRT++)
            {
                if (LDRT < 14)
                {
                    for (int i = 0; i < (LDRT - 3); i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] == 2 * pt && tm[i + 4, LDRT - i - 4] + tm[i, LDRT - i] == 0)
                        {
                            NumOfEr++;
                            i++;
                        }
                    }
                }
                else
                {
                    for (int i = Math.Abs(14 - LDRT); i < 11; i++)
                    {
                        if (tm[i, LDRT - i] + tm[i + 1, LDRT - i - 1] + tm[i + 2, LDRT - i - 2] + tm[i + 3, LDRT - i - 3] + tm[i + 4, LDRT - i - 4] == 2 * pt && tm[i + 4, LDRT - i - 4] + tm[i, LDRT - i] == 0)
                        {
                            NumOfEr++;
                            i++;
                        }
                    }
                }
            }
            return NumOfEr;
        }
        #endregion
    }
}