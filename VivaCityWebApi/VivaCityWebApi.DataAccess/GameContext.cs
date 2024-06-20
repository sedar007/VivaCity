using VivaCityWebApi.Common;
using VivaCityWebApi.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace VivaCityWebApi.DataAccess {
	public class GameContext : DbContext
	{
		public DbSet<GameDao> Games { get; set; }
		public DbSet<UserDao> Users { get; set; }
		public DbSet<Village> Villages { get; set; }
		public DbSet<Batiment> Batiments { get; set; }
		public DbSet<Cout> Couts { get; set; }
		public DbSet<Ressources> Ressources { get; set; }

		private string SQLConnectionString;

		public GameContext(IOptions<AppSettings> options)
		{
			SQLConnectionString = options.Value.SQLConnectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(SQLConnectionString);

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var batimentBuilder = modelBuilder.Entity<Batiment>();
			var coutBuilder = modelBuilder.Entity<Cout>();
			var ressourcesBuilder = modelBuilder.Entity<Ressources>();
			var usersBuilder = modelBuilder.Entity<UserDao>();
			var villageBuilder = modelBuilder.Entity<Village>();
			var gameDaoBuilder = modelBuilder.Entity<GameDao>();
			//var userDaoBuilder = modelBuilder.Entity<UserDao>();

			batimentBuilder.HasKey(x => x.Id);
			coutBuilder.HasKey(x => x.Id);
			ressourcesBuilder.HasKey(x => x.Id);
			usersBuilder.HasKey(x => x.Id);
			villageBuilder.HasKey(x => x.Id);
			gameDaoBuilder.HasKey(x => x.Id);
			//userDaoBuilder.HasKey(x => x.Pseudo);

			/*gameBuilder.Property(x => x.Id).HasColumnType("varchar");
			gameBuilder.Property(x => x.Name)
				.HasMaxLength(255)
				.IsUnicode(true)
				.HasColumnType("varchar");*/

			modelBuilder.HasSequence("user_id_seq");
			usersBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('user_id_seq')");
		}
	}
}
