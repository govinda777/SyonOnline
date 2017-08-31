using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyonOnline.WebApi.Model
{
    public class ValidationResult
    {
        private DateTime _timeFinish;
        public ValidationResult()
        {
            TimeStart = DateTime.Now;
        }

        public string Order { get; set; }
        public DateTime TimeStart { get; }
        public DateTime TimeFinish {
            get
            {
                return _timeFinish;
            }
            set
            {
                _timeFinish = value;
                TotalTime = (_timeFinish - TimeStart).TotalSeconds;
            }
        }
        public double TotalTime { get; private set; }
        public string Message { get; set; }
        public bool IsPass { get; set; }
    }
}
