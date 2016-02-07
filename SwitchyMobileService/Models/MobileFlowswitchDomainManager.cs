using AutoMapper;
using Microsoft.WindowsAzure.Mobile.Service;
using SwitchyMobileService.DataObjects;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace SwitchyMobileService.Models
{
    public class MobileFlowswitchDomainManager : MappedEntityDomainManager<MobileFlowswitch, Flowswitch>
    {
        private ExistingContext context;

        public MobileFlowswitchDomainManager(ExistingContext context, HttpRequestMessage request, ApiServices services)
            : base(context, request, services)
        {
            Request = request;
            this.context = context;
        }

        public static int GetKey(string mobileFlowswitchId, DbSet<Flowswitch> flowswitches, HttpRequestMessage request)
        {
            int FlowswitchID = flowswitches
               .Where(f => f.Id == mobileFlowswitchId)
               .Select(f => f.ID)
               .FirstOrDefault();

            if (FlowswitchID == 0)
            {
                throw new HttpResponseException(request.CreateNotFoundResponse());
            }
            return FlowswitchID;
        }

        protected override T GetKey<T>(string mobileFlowswitchId)
        {
            return (T)(object)GetKey(mobileFlowswitchId, this.context.Flowswitches, this.Request);
        }

        public override SingleResult<MobileFlowswitch> Lookup(string mobileFlowswitchId)
        {
            int flowswitchId = GetKey<int>(mobileFlowswitchId);
            return LookupEntity(c => c.ID == flowswitchId);
        }

        public override async Task<MobileFlowswitch> InsertAsync(MobileFlowswitch mobileFlowswitch)
        {
            return await base.InsertAsync(mobileFlowswitch);
        }

        public override async Task<MobileFlowswitch> UpdateAsync(string mobileFlowswitchId, Delta<MobileFlowswitch> patch)
        {
            int flowswitchId = GetKey<int>(mobileFlowswitchId);

            Flowswitch existingFlowswitch = await this.Context.Set<Flowswitch>().FindAsync(flowswitchId);
            if (existingFlowswitch == null)
            {
                throw new HttpResponseException(this.Request.CreateNotFoundResponse());
            }

            MobileFlowswitch existingFlowswitchDTO = Mapper.Map<Flowswitch, MobileFlowswitch>(existingFlowswitch);
            patch.Patch(existingFlowswitchDTO);
            Mapper.Map<MobileFlowswitch, Flowswitch>(existingFlowswitchDTO, existingFlowswitch);

            await this.SubmitChangesAsync();

            MobileFlowswitch updatedFlowswitchDTO = Mapper.Map<Flowswitch, MobileFlowswitch>(existingFlowswitch);

            return updatedFlowswitchDTO;
        }

        public override async Task<MobileFlowswitch> ReplaceAsync(string mobileFlowswitchId, MobileFlowswitch mobileFlowswitch)
        {
            return await base.ReplaceAsync(mobileFlowswitchId, mobileFlowswitch);
        }

        public override async Task<bool> DeleteAsync(string mobileFlowswitchId)
        {
            int flowswitchId = GetKey<int>(mobileFlowswitchId);
            return await DeleteItemAsync(flowswitchId);
        }
    }
}