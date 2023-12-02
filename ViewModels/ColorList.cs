using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MauiBase.ViewModels
{
    internal class ColorList
    {
        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public Color Color { get; private set; }
        public float Red => Color.Red;
        public float Green => Color.Green;
        public float Blue => Color.Blue;
        public static IEnumerable<ColorList> All { get; private set; }

        static ColorList()
        {
            Debug.WriteLine("开始生成列表");
            List<ColorList> all = new();
            StringBuilder stringBuilder = new();

            foreach (FieldInfo fieldInfo in typeof(Colors).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic && fieldInfo.IsStatic && fieldInfo.FieldType == typeof(Color))
                {
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    foreach (char ch in name)
                    {
                        if (name.IndexOf(ch) != 0 && Char.IsUpper(ch))
                        {
                            stringBuilder.Append(' ');
                        }
                        stringBuilder.Append(ch);
                    }
                    ColorList color = new()
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = (Color)fieldInfo.GetValue(null)
                    };
                    all.Add(color);
                }
            }
            all.TrimExcess();
            All = all;
        }
    }
}
