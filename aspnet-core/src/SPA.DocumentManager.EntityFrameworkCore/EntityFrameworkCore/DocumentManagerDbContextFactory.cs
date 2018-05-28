using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SPA.DocumentManager.Configuration;
using SPA.DocumentManager.Web;

namespace SPA.DocumentManager.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DocumentManagerDbContextFactory : IDesignTimeDbContextFactory<DocumentManagerDbContext>
    {
        public DocumentManagerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DocumentManagerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DocumentManagerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DocumentManagerConsts.ConnectionStringName));

            return new DocumentManagerDbContext(builder.Options);
        }
    }
}
