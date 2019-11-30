/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：RandomUtil.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 9:35:43
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Text;

namespace LittleWhales.Infrastructure
{

    public class RandomUtil
    {
        private static char[] constant ={
                                     '0','1','2','3','4','5','6','7','8','9',
                                     'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                                     'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
                                };
        private static char[] number = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char[] Letter ={
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                                     'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        /// <summary>
        /// 生成随机码 
        /// </summary>
        /// <param name="Length">长度</param>
        /// <param name="category">1 数字加字母 2 仅数字 3 仅字母</param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length = 6, int category = 0)
        {
            StringBuilder newRandom = new StringBuilder(62);
            Random rd = new Random();
            char[] character;
            switch (category)
            {
                case 1:
                    for (int i = 0; i < Length; i++)
                    {
                        newRandom.Append(constant[rd.Next(62)]);
                    }
                    break;
                case 2:

                    for (int i = 0; i < Length; i++)
                    {
                        newRandom.Append(number[rd.Next(10)]);
                    }
                    break;
                case 3:
                    for (int i = 0; i < Length; i++)
                    {
                        newRandom.Append(Letter[rd.Next(52)]);
                    }
                    break;
                default:
                    for (int i = 0; i < Length; i++)
                    {
                        newRandom.Append(constant[rd.Next(62)]);
                    }
                    break;

            }

            return newRandom.ToString();
        }
    }
}
