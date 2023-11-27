using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBase.Views;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(AppContext.BaseDirectory, "notes.txt");
    public const double fontsize = 48;
    public NotePage()
    {
        InitializeComponent();
        Debug.Print(_fileName);
        if (File.Exists(_fileName))
        {
            editor.Text = File.ReadAllText(_fileName);
        } else
        {
            Debug.WriteLine("不存在note文件");
            File.WriteAllText(_fileName, "kawaii");
        }
    }
    void OnSaveButtonClicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, editor.Text);
    }

    void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
        {
            File.Delete(_fileName);
        }
        editor.Text = string.Empty;
    }
}

public class GolbalFontSizeExtension : IMarkupExtension
{
    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return NotePage.fontsize;
    }
}

//[ContentProperty("Member")]
//public class StaticExtension : IMarkupExtension
//{
//    public string Member { get; set; }
//    public object ProvideValue(IServiceProvider serviceProvider)
//    {
//        // https://learn.microsoft.com/zh-cn/training/modules/create-user-interface-xaml/6-xaml-markup-extensions
//    }
//}

