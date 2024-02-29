using Semytskyi1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semytskyi1.Views
{
    /// <summary>
    /// Логика взаимодействия для BirthdayView.xaml
    /// </summary>
    public partial class BirthdayView : UserControl
    {
        private BirthdayViewModel birthdayViewModel = new BirthdayViewModel();

        public BirthdayView()
        {
            InitializeComponent();
            DataContext = birthdayViewModel;
        }
    }
}
