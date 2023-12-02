using MauiBase.Util;
using MauiBase.ViewModels;
using System.Diagnostics;

namespace MauiBase.Views;

public partial class FileSearchPage : ContentPage
{

    public FileSearchPage()
    {
        InitializeComponent();
    }

    private void Search_Button_Clicked(object sender, EventArgs e)
    {
        if(BindingContext is FileSearchModel viewModel && Search_Keyword.Text.Length>0)
        {
            viewModel.Keyword = Search_Keyword.Text;
        }
    }
}