// <auto-generated />
namespace GrandLabFixers.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class RemovedUserNameFromOrderAndOrderDetailsTable : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemovedUserNameFromOrderAndOrderDetailsTable));
        
        string IMigrationMetadata.Id
        {
            get { return "201701311351076_RemovedUserNameFromOrderAndOrderDetailsTable"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
