using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace LittleWhales.Infrastructure
{
   public class EnumUtil
    {

        public static EnumParam GetManualSort<T>(int value) where T : new() 
        {
            Type t = typeof(T);
            EnumParam param = new EnumParam();
            foreach (MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(value))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(ManualSort))
                        {
                            string[] val = ((ManualSort)attr).Name.Split('|');
                            
                            param.Name = val[0];
                            param.Key = val[1]; 
                        }
                    }
                }
            }
            return param;
        }

        public static List<EnumParam> GetManualSort(Type enumType)
        {
            List<EnumParam> list = new List<EnumParam>();

            if (!enumType.IsEnum && !IsGenericEnum(enumType)) // enumType既不是enum也不是enum?
            {
                return list;
            }
            enumType = GetRealEnum(enumType);

            list = new List<EnumParam>();
            FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                EnumParam param = new EnumParam();

                object[] objs = field.GetCustomAttributes(typeof(ManualSort), false);
                if (objs.Length > 0)
                {
                    ManualSort a = objs[0] as ManualSort;
                    if (a != null && a.Name != null)
                    {
                        string[] val = a.Name.Split('|');
                        param.Name = val[0];
                        param.Key = val[1];
                    }
                } 
                list.Add(param);
            }
            return list;
        } 

        public static List<EnumParam> GetDescriptions<T>(Type enumType)
        {
            List<EnumParam> list = new List<EnumParam>();

            if (!enumType.IsEnum && !IsGenericEnum(enumType)) // enumType既不是enum也不是enum?
            {
                return list;
            }
            enumType = GetRealEnum(enumType);
           
                list = new List<EnumParam>();
                FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
                foreach (FieldInfo field in fields)
                {
                    EnumParam param = new EnumParam();

                    object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (objs.Length > 0)
                    {
                        DescriptionAttribute a = objs[0] as DescriptionAttribute;
                        if (a != null && a.Description != null)
                        {
                            param.Desc = a.Description;
                        }
                    }
                    //objs = field.GetCustomAttributes(typeof(ViewAttribute), false);
                    //if (objs.Length > 0)
                    //{
                    //    ViewAttribute a = objs[0] as ViewAttribute;
                    //    if (a != null && a.ViewTxt != null)
                    //    {
                    //        param.View = a.ViewTxt;
                    //    }
                    //}
                    //objs = field.GetCustomAttributes(typeof(EditionAttribute), false);
                    //if (objs.Length > 0)
                    //{
                    //    EditionAttribute a = objs[0] as EditionAttribute;
                    //    if (a != null && a.Edition != null)
                    //    {
                    //        param.Edition = a.Edition;
                    //    }
                    //}
                    //objs = field.GetCustomAttributes(typeof(NameAttribute), false);
                    //if (objs.Length > 0)
                    //{
                    //    NameAttribute a = objs[0] as NameAttribute;
                    //    if (a != null && a.Name != null)
                    //    {
                    //        param.Name = a.Name;
                    //    }
                    //}
                    //objs = field.GetCustomAttributes(typeof(ClassifyAttribute), false);
                    //if (objs.Length > 0)
                    //{
                    //    ClassifyAttribute a = objs[0] as ClassifyAttribute;
                    //    if (a != null && a.Name != null)
                    //    {
                    //        param.Classify = a.Name;
                    //    }
                    //}


                    param.Key = (T)field.GetValue(null);


                    list.Add(param);
                } 
                return list;
            
        }


        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="value"></param>
        /// <param name="view"></param>
        /// <returns></returns>
        public static string GetDescription<TEnum, T>(object value, bool view = false) where TEnum : struct
        {
            EnumParam ep = GetOne<T>(value, typeof(TEnum));
            if (ep == null)
            {
                return string.Empty;
            }
            if (view && !string.IsNullOrWhiteSpace(ep.View))
            {
                return ep.View;
            }
            return ep.Desc;
        }
        private static EnumParam GetOne<T>(object enumValue, Type enumType)
        {
            var list = GetDescriptions<T>(enumType);
            return list.Find(p => p.Key.ToStr().Equals(enumValue.ToStr()));
        }

        private static bool IsGenericEnum(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
                    && type.GetGenericArguments().Length == 1 && type.GetGenericArguments()[0].IsEnum);
        }

        private static Type GetRealEnum(Type type)
        {
            Type t = type;
            while (IsGenericEnum(t))
            {
                t = type.GetGenericArguments()[0];
            }
            return t;
        }
    }


    public class EnumParam
    {
        #region 枚举特性
        public object Key { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string View { get; set; } 
        #endregion

        
    }
}
