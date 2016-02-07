using Microsoft.WindowsAzure.Mobile.Service;
using SwitchyMobileService.DataObjects;
using SwitchyMobileService.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.OData;

namespace SwitchyMobileService.Controllers
{
    public class MobileCalibrationRecordController : TableController<MobileCalibrationRecord>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ExistingContext context = new ExistingContext();
            DomainManager = new MobileCalibrationRecordDomainManager(context, Request, Services);
        }

        public IQueryable<MobileCalibrationRecord> GetAllMobileOrders()
        {
            return Query();
        }

        public SingleResult<MobileCalibrationRecord> GetMobileOrder(string id)
        {
            return Lookup(id);
        }

        public Task<MobileCalibrationRecord> PatchMobileOrder(string id, Delta<MobileCalibrationRecord> patch)
        {
            return UpdateAsync(id, patch);
        }

        [ResponseType(typeof(MobileCalibrationRecord))]
        public async Task<IHttpActionResult> PostMobileOrder(MobileCalibrationRecord item)
        {
            MobileCalibrationRecord current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        public Task DeleteMobileOrder(string id)
        {
            return DeleteAsync(id);
        }
    }
}