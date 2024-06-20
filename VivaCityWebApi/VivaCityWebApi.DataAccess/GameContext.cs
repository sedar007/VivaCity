using VivaCityWebApi.Common;
using VivaCityWebApi.Common.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace VivaCityWebApi.DataAccess {
	public class GameContext : DbContext
	{
		public DbSet<UserDao> Users { get; set; }
		public DbSet<VillageDao> Villages { get; set; }
		public DbSet<BatimentDao> Batiments { get; set; }
		public DbSet<CoutDao> Couts { get; set; }
		public DbSet<RessourceDao> Ressources { get; set; }
		public DbSet<RessourceItemDao> RessourceItem { get; set; }

		private string SQLConnectionString;

		public GameContext(IOptions<AppSettings> options)
		{
			SQLConnectionString = options.Value.SQLConnectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(SQLConnectionString);

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var batimentDaoBuilder = modelBuilder.Entity<BatimentDao>();
			var coutDaoBuilder = modelBuilder.Entity<CoutDao>();
			var ressourceDaoBuilder = modelBuilder.Entity<RessourceDao>();
			var usersDaoBuilder = modelBuilder.Entity<UserDao>();
			var villageDaoBuilder = modelBuilder.Entity<VillageDao>();
			var ressourceItemDaoBuilder = modelBuilder.Entity<RessourceItemDao>();
			//var userDaoBuilder = modelBuilder.Entity<UserDao>();

			batimentDaoBuilder.HasKey(x => x.Id);
			coutDaoBuilder.HasKey(x => x.Id);
			ressourceDaoBuilder.HasKey(x => x.Id);
			usersDaoBuilder.HasKey(x => x.Id);
			villageDaoBuilder.HasKey(x => x.Id);
			ressourceItemDaoBuilder.HasKey(x => x.Id);
			//userDaoBuilder.HasKey(x => x.Pseudo);
			batimentDaoBuilder.HasOne<CoutDao>(x => x.Cout)
				.WithMany()
				.HasForeignKey(x => x.CoutId)
				.OnDelete(DeleteBehavior.Cascade);
			
			coutDaoBuilder.HasOne<RessourceDao>(x => x.Ressource)
				.WithMany()
				.HasForeignKey(x => x.RessourceId)
				.OnDelete(DeleteBehavior.Cascade);
			
			ressourceDaoBuilder.HasOne<RessourceItemDao>(x => x.RessourceItem)
				.WithMany()
				.HasForeignKey(x => x.RessourceItemId)
				.OnDelete(DeleteBehavior.Cascade);

			usersDaoBuilder.HasMany<VillageDao>(x => x.Villages)
				.WithOne(x => x.User)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			
			villageDaoBuilder.HasMany<BatimentDao>(x => x.Batiments)
				.WithOne(x => x.Village)
				.HasForeignKey(x => x.VillageId)
				.OnDelete(DeleteBehavior.Cascade);
			
			villageDaoBuilder.HasMany<RessourceDao>(x => x.Ressources)
				.WithOne()
				.HasForeignKey(x => x.VillageId)
				.OnDelete(DeleteBehavior.Cascade);
			
			
			/*gameBuilder.Property(x => x.Id).HasColumnType("varchar");
			gameBuilder.Property(x => x.Name)
				.HasMaxLength(255)
				.IsUnicode(true)
				.HasColumnType("varchar");*/

			modelBuilder.HasSequence("user_id_seq");
			modelBuilder.HasSequence("batiment_id_seq");
			modelBuilder.HasSequence("cout_id_seq");
			modelBuilder.HasSequence("ressource_id_seq");
			modelBuilder.HasSequence("village_id_seq");
			modelBuilder.HasSequence("ressource_item_id_seq");
			
			usersDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('user_id_seq')");
			batimentDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('batiment_id_seq')");
			coutDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('cout_id_seq')");
			ressourceDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('ressource_id_seq')");
			villageDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('village_id_seq')");
			ressourceItemDaoBuilder.Property(x => x.Id).HasDefaultValueSql("nextval('ressource_item_id_seq')");
			
		}
	}
}
