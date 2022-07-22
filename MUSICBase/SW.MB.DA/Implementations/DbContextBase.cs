using Microsoft.EntityFrameworkCore;

namespace SW.MB.DA.Implementations {
    internal abstract class DbContextBase : DbContext {
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      
    }
  }
}
