using Boxters.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Boxters.Application.Interfaces
{
    public interface IBoxBoxContext
    {
        DatabaseFacade Database { get; }
        DbSet<Account> Account { get; set; }
        DbSet<BranchOffice> BranchOffice { get; set; }
        DbSet<Food> Food { get; set; }
        DbSet<FoodType> FoodType { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<OrderFoodOperation> OrderFoodOperation { get; set; }
        DbSet<OrderState> OrderState { get; set; }
        DbSet<Sale> Sale { get; set; }
        DbSet<SaleFood> SaleFood { get; set; }

        Task<int> SaveChangesAsync(CancellationToken candellationToken);
    }
}
