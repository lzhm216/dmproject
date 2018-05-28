using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SPA.DocumentManager.EntityFrameworkCore
{
    public static class DocumentManagerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DocumentManagerDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString, b=>b.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<DocumentManagerDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
