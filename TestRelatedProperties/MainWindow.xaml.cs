using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestRelatedProperties;

namespace TestRelatedProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool _initCompleted;

        public int Half
        {
            get { return (int)GetValue(HalfProperty); }
            set { SetValue(HalfProperty, value); }
        }
        public static readonly DependencyProperty HalfProperty =
            DependencyProperty.Register("Half", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0, OneHasChanged));

        public int Whole
        {
            get { return (int)GetValue(WholeProperty); }
            set { SetValue(WholeProperty, value); }
        }
        public static readonly DependencyProperty WholeProperty =
            DependencyProperty.Register("Whole", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0, OneHasChanged));


        public int Double
        {
            get { return (int)GetValue(DoubleProperty); }
            set { SetValue(DoubleProperty, value); }
        }
        public static readonly DependencyProperty DoubleProperty =
            DependencyProperty.Register("Double", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0, OneHasChanged));


        private static void OneHasChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mw = d as MainWindow;
            string pName = e.Property.Name;

            System.Diagnostics.Debug.WriteLine($"Init:{mw._initCompleted} Property:{pName} From: {e.OldValue} To:{e.NewValue}");
            
            if (!mw._initCompleted)
                return;

            switch (pName)
            {
                case nameof(Half):
                  //  MessageBox.Show(nameof(Half));
                    mw.Whole = mw.Half * 2;
                    
                    break;
                case nameof(Whole):
                  //  MessageBox.Show(nameof(Whole));
                    mw.Half = mw.Whole/2;
                    mw.Double = mw.Whole* 2;
                    break;

                case nameof(Double):
                  //  MessageBox.Show(nameof(Double));
                    mw.Whole= mw.Double/ 2;
                    break;
                default:
                    MessageBox.Show("???");
                    break;
            }

            
        }


        public MainWindow()
        {
            InitializeComponent();
            Half = 1;
            Whole = 2;
            Double = 3;
            _initCompleted = true;
        }
    }
}
