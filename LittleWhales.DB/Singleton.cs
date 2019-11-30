using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LittleWhales.DB
{
    static class Singleton<T> where T : new()
    {
        public static T Instance = new T();
    }
}
