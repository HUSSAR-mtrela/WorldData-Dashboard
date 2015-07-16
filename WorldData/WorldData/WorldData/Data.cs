 

namespace WorldData
{
    public class DataItem : ObservableObject
    {
        private string _label;

        public string Label
        {
            get { return _label; }
            set { _label = value; RaisePropertyChanged(); }
        }

        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(); }
        }

        private double _level;

        public double Level
        {
            get { return _level; }
            set { _level = value; RaisePropertyChanged(); }
        }
        

    }

}
