using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public static class Roll
    {
        public static Random random = new Random();

        

        /// <summary>
        /// 两面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D2(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 3);
            }
            return num;
        }

        /// <summary>
        /// 三面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D3(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 4);
            }
            return num;
        }

        /// <summary>
        /// 四面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D4(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 5);
            }
            return num;
        }

        /// <summary>
        /// 六面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D6(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 7);
            }
            return num;
        }

        /// <summary>
        /// 八面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D8(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 9);
            }
            return num;
        }

        /// <summary>
        /// 十面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D10(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 11);
            }
            return num;
        }

        /// <summary>
        /// 十二面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D12(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 13);
            }
            return num;
        }

        /// <summary>
        /// 二十面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D20(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 21);
            }
            return num;
        }

        /// <summary>
        /// 一百面骰子
        /// </summary>
        /// <param name="frequency">次数</param>
        /// <returns></returns>
        public static int D100(int frequency = 1)
        {
            int num = 0;
            for (int i = 0; i < frequency; i++)
            {
                num += random.Next(1, 101);
            }
            return num;
        }
    }
}
