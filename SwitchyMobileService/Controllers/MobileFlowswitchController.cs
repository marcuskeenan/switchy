using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using SwitchyMobileService.DataObjects;
using SwitchyMobileService.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace SwitchyMobileService.Controllers
{
    public class MobileFlowswitchController : TableController<MobileFlowswitch>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new ExistingContext();
            DomainManager = new MobileFlowswitchDomainManager(context, Request, Services);
        }

        public IQueryable<MobileFlowswitch> GetAllMobileFlowswitchs()
        {
            return Query();
        }

        public SingleResult<MobileFlowswitch> GetMobileFlowswitch(string id)
        {
            return Lookup(id);
        }

        //[AuthorizeLevel(AuthorizationLevel.Admin)]
        //protected override Task<MobileFlowswitch> PatchAsync(string id, Delta<MobileFlowswitch> patch)
        //{
        //    return base.UpdateAsync(id, patch);
        //}

        //[AuthorizeLevel(AuthorizationLevel.Admin)]
        //protected override Task<MobileFlowswitch> PostAsync(MobileFlowswitch item)
        //{
        //    return base.InsertAsync(item);
        //}

        [AuthorizeLevel(AuthorizationLevel.Admin)]
        protected override Task DeleteAsync(string id)
        {
            return base.DeleteAsync(id);
        }
    }
}