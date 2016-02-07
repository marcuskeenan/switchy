using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwitchyMobileService.DataObjects
{
    public class MobileCalibrationRecord : EntityData
    {
        public string MaxInches { get; set;}
        public string MaxGallons { get; set; }
        public string TripInches { get; set; }
        public string TripGallons { get; set; }

        [NotMapped]
        public int FlowswitchID { get; set; }

        [Required]
        public string MobileFlowswitchId { get; set; }

        public string MobileFlowswitchName { get; set; }


    }
}