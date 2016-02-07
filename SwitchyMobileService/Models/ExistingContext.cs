using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using System.Linq;

namespace SwitchyMobileService.Models
{


    public class ExistingContext : DbContext
    {
        public ExistingContext()
            : base("Name=MS_TableConnectionString")
        {

        }

        public DbSet<Flowswitch> Flowswitches { get; set; }

        public DbSet<CalibrationRecord> CalibrationRecords { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            base.OnModelCreating(modelBuilder);
        } 

    }
}
