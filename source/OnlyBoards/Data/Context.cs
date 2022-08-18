using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
   public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(@"Data Source=OnlyBoards.db");
    }
   
   public DbSet<Board> Boards { get; set; }
}