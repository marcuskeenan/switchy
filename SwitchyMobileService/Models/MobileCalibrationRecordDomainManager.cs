using AutoMapper;
using Microsoft.WindowsAzure.Mobile.Service;
using SwitchyMobileService.DataObjects;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace SwitchyMobileService.Models
{
    public class MobileCalibrationRecordDomainManager : MappedEntityDomainManager<MobileCalibrationRecord, CalibrationRecord>
    {
        private ExistingContext context;

        public MobileCalibrationRecordDomainManager(ExistingContext context, HttpRequestMessage request, ApiServices services)
            : base(context, request, services)
        {
            Request = request;
            this.context = context;
        }

        protected override T GetKey<T>(string mobileCalibrationRecordId)
        {
            int ID = this.context.CalibrationRecords
                .Where(c => c.Id == mobileCalibrationRecordId)
                .Select(c => c.ID)
                .FirstOrDefault();

            if (ID == 0)
            {
                throw new HttpResponseException(this.Request.CreateNotFoundResponse());
            }
            return (T)(object)ID;
        }

        public override SingleResult<MobileCalibrationRecord> Lookup(string mobileCalibrationRecordId)
        {
            int ID = GetKey<int>(mobileCalibrationRecordId);
            return LookupEntity(c => c.ID == ID);
        }

        private async Task<Flowswitch> VerifyMobileFlowswitch(string mobileFlowswitchId, string mobileFlowswitchName)
        {
            int ID = MobileFlowswitchDomainManager.GetKey(mobileFlowswitchId, this.context.Flowswitches, this.Request);
            Flowswitch flowswitch = await this.context.Flowswitches.FindAsync(ID);
            if (flowswitch == null)
            {
                throw new HttpResponseException(Request.CreateBadRequestResponse("Flowswitch with name '{0}' was not found", mobileFlowswitchName));
            }
            return flowswitch;
        }

        public override async Task<MobileCalibrationRecord> InsertAsync(MobileCalibrationRecord mobileCalibrationRecord)
        {
            Flowswitch flowswitch = await VerifyMobileFlowswitch(mobileCalibrationRecord.MobileFlowswitchId, mobileCalibrationRecord.MobileFlowswitchName);
            mobileCalibrationRecord.FlowswitchID = flowswitch.ID;
            return await base.InsertAsync(mobileCalibrationRecord);
        }

        public override async Task<MobileCalibrationRecord> UpdateAsync(string mobileCalibrationRecordId, Delta<MobileCalibrationRecord> patch)
        {
            Flowswitch flowswitch = await VerifyMobileFlowswitch(patch.GetEntity().MobileFlowswitchId, patch.GetEntity().MobileFlowswitchName);

            int ID = GetKey<int>(mobileCalibrationRecordId);

            CalibrationRecord existingCalibrationRecord = await this.Context.Set<CalibrationRecord>().FindAsync(ID);
            if (existingCalibrationRecord == null)
            {
                throw new HttpResponseException(this.Request.CreateNotFoundResponse());
            }

            MobileCalibrationRecord existingCalibrationRecordDTO = Mapper.Map<CalibrationRecord, MobileCalibrationRecord>(existingCalibrationRecord);
            patch.Patch(existingCalibrationRecordDTO);
            Mapper.Map<MobileCalibrationRecord, CalibrationRecord>(existingCalibrationRecordDTO, existingCalibrationRecord);

            // This is required to map the right Id for the flowswitch
            existingCalibrationRecord.FlowswitchID = flowswitch.ID;

            await this.SubmitChangesAsync();

            MobileCalibrationRecord updatedCalibrationRecordDTO = Mapper.Map<CalibrationRecord, MobileCalibrationRecord>(existingCalibrationRecord);

            return updatedCalibrationRecordDTO;
        }

        public override async Task<MobileCalibrationRecord> ReplaceAsync(string mobileCalibrationRecordId, MobileCalibrationRecord mobileCalibrationRecord)
        {
            await VerifyMobileFlowswitch(mobileCalibrationRecord.MobileFlowswitchId, mobileCalibrationRecord.MobileFlowswitchName);

            return await base.ReplaceAsync(mobileCalibrationRecordId, mobileCalibrationRecord);
        }

        public override Task<bool> DeleteAsync(string mobileCalibrationRecordId)
        {
            int ID= GetKey<int>(mobileCalibrationRecordId);
            return DeleteItemAsync(ID);
        }
    }
}