using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MauiBase.ViewModels
{
    class ClockViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DateTime _datetime;
        private Timer _timer;

        public DateTime DateTime
        {
            get => _datetime;
            set 
            {
                if (_datetime.Second != value.Second)
                {
                    _datetime = value;
                    OnPropertyChanged();
                }
            }
        }

        public ClockViewModel()
        {
            _datetime = DateTime.Now;
            /** 
             * 创建定时器，每一秒钟更新DateTime(隐式调用setter)
             * 参数1：委托到期时调用的方法，这里使用lambda表达式
             */
            _timer = new Timer(  
                new TimerCallback(s => DateTime = DateTime.Now), null, TimeSpan.Zero, TimeSpan.FromSeconds(0.1));
        }

        ~ClockViewModel() =>_timer.Dispose();

        //  在属性改变时调用此方法 保持更新
        public void OnPropertyChanged([CallerMemberName] string name = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
    }
}
