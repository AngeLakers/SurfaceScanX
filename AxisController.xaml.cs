using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;

namespace SurfaceScan;

public partial class AxisController : UserControl
{
    public AxisController()
    {
        InitializeComponent();
        this.DataContext = new AxisControllerViewModel();  // 设置 ViewModel 为 DataContext
    }

   public class AxisControllerViewModel : INotifyPropertyChanged
    {
        private double _xValue;
        private double _yValue;
        private double _zValue;
        private double _aValue;
        private double _bValue;
        private double _wValue;

        public double XValue
        {
            get { return _xValue; }
            set
            {
                if (_xValue != value)
                {
                    _xValue = value;
                    OnPropertyChanged(nameof(XValue));
                }
            }
        }

        public double YValue
        {
            get { return _yValue; }
            set
            {
                if (_yValue != value)
                {
                    _yValue = value;
                    OnPropertyChanged(nameof(YValue));
                }
            }
        }

        public double ZValue
        {
            get { return _zValue; }
            set
            {
                if (_zValue != value)
                {
                    _zValue = value;
                    OnPropertyChanged(nameof(ZValue));
                }
            }
        }

        public double AValue
        {
            get { return _aValue; }
            set
            {
                if (_aValue != value)
                {
                    _aValue = value;
                    OnPropertyChanged(nameof(AValue));
                }
            }
        }

        public double BValue
        {
            get { return _bValue; }
            set
            {
                if (_bValue != value)
                {
                    _bValue = value;
                    OnPropertyChanged(nameof(BValue));
                }
            }
        }

        public double WValue
        {
            get { return _wValue; }
            set
            {
                if (_wValue != value)
                {
                    _wValue = value;
                    OnPropertyChanged(nameof(WValue));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    private void ModifyZ_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ModifyY_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void ModifyX_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        throw new NotImplementedException();
    }
}




