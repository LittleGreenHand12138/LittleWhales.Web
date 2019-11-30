/*----------------------------------------------------------------
// Copyright (C) 小鲸派
// 版权所有。
//
// 文件名：IOCManage.cs
// 功能描述：
// 
// 创建标识：Wuyuchi 2019/11/8 9:54:24
// 
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Text;

namespace LittleWhales.Core
{
    public class IOCManage
    {
        private static readonly WindsorContainer _container = BasicConventionalRegistrar._container;

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
