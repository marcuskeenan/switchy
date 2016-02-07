using System;
using System.ComponentModel.DataAnnotations;

namespace FlowswitchApplication.ViewModels
{
    public class CalibrationFlowswitchGroup
    {
        public Int64 Row { get; set; }
        
        public string Name { get; set; }

        public int CalibrationCount { get; set; }
    }
}