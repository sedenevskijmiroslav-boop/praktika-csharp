using System.Windows;
using Task1.ViewModels;

namespace Task1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}