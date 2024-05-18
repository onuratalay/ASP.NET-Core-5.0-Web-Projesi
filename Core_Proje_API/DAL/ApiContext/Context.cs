using Microsoft.EntityFrameworkCore;

namespace Core_Proje_API.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=ACER-NITRO-5\SQLEXPRESS01;Database=PortfolyoSitesiAPI;Integrated Security=true");
        }


    }
}
