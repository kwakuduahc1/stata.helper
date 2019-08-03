using Microsoft.EntityFrameworkCore;

namespace StataHelper.Model.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabelCollections>(x => x.HasData(
                new LabelCollections { LabelName = "Short Months", LabelCollectionsID = 1, Description = "Short name of months of the year" },
                new LabelCollections { LabelName = "Full Months", LabelCollectionsID = 2, Description = "Full name of months of the year" },
                new LabelCollections { LabelName = "Short Weeks", LabelCollectionsID = 3, Description = "Short name of days of the week" },
                new LabelCollections { LabelName = "Full Weeks", LabelCollectionsID = 4, Description = "Full name of days of the week" },
                new LabelCollections { LabelName = "Short Gender", LabelCollectionsID = 5, Description = "Short gender" },
                new LabelCollections { LabelName = "Long Gender", LabelCollectionsID = 6, Description = "Long gender" },
                new LabelCollections { LabelName = "Short Yes/Nos", LabelCollectionsID = 7, Description = "Short form of yes/no responses" },
                new LabelCollections { LabelName = "Long Yes/No's", LabelCollectionsID = 8, Description = "Long form of yes/no responses" },
                new LabelCollections { LabelName = "Short True/False", LabelCollectionsID = 9, Description = "True of false represented as T/F" },
                 new LabelCollections { LabelName = "True/False", LabelCollectionsID = 10, Description = "True of false as is" }
                ));
            {
                string[] shmth = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                string[] lgmth = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string[] shwk = new string[] { "Mon", "Tue", "Wed", "Thur", "Fri", "Sat", "Sun" };
                string[] lgwk = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

                for (byte i = 1; i < shmth.Length + 1; i++)
                    modelBuilder.Entity<Labels>(x => x.HasData(
                        new Labels { Key = i, LabelsID = i, Label = shmth[i - 1], LabelCollectionsID = 1 }
                        ));

                for (byte i = 13; i < lgmth.Length + 13; i++)
                    modelBuilder.Entity<Labels>(x => x.HasData(
                        new Labels { Key = (byte)(i - 12), LabelsID = i, Label = lgmth[i - 13], LabelCollectionsID = 2 }
                        ));

                for (byte i = 25; i < shwk.Length + 25; i++)
                    modelBuilder.Entity<Labels>(x => x.HasData(
                        new Labels { Key = (byte)(i - 24), LabelsID = i, Label = shwk[i - 25], LabelCollectionsID = 3 }
                        ));

                for (byte i = 33; i < lgwk.Length + 33; i++)
                    modelBuilder.Entity<Labels>(x => x.HasData(
                        new Labels { Key = (byte)(i - 32), LabelsID = i, Label = lgwk[i - 33], LabelCollectionsID = 4 }
                        ));
            }
            modelBuilder.Entity<Labels>(x => x.HasData(
                new Labels { LabelCollectionsID = 5, Key = 0, Label = "F", LabelsID = 40 },
                new Labels { LabelCollectionsID = 5, Key = 1, Label = "M", LabelsID = 41 },
                new Labels { LabelCollectionsID = 6, Key = 0, Label = "Female", LabelsID = 42 },
                new Labels { LabelCollectionsID = 6, Key = 1, Label = "Male", LabelsID = 43 },
                new Labels { LabelCollectionsID = 7, Key = 0, Label = "Y", LabelsID = 44 },
                new Labels { LabelCollectionsID = 7, Key = 1, Label = "N", LabelsID = 45 },
                new Labels { LabelCollectionsID = 8, Key = 0, Label = "Yes", LabelsID = 46 },
                new Labels { LabelCollectionsID = 8, Key = 1, Label = "No", LabelsID = 47 },
                new Labels { LabelCollectionsID = 9, Key = 0, Label = "F", LabelsID = 48 },
                new Labels { LabelCollectionsID = 9, Key = 1, Label = "T", LabelsID = 49 },
                new Labels { LabelCollectionsID = 10, Key = 0, Label = "False", LabelsID = 50 },
                new Labels { LabelCollectionsID = 10, Key = 1, Label = "True", LabelsID = 51 }
                ));
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Projects> Projects { get; set; }

        public virtual DbSet<LabelCollections> LabelCollections { get; set; }

        public virtual DbSet<Labels> Labels { get; set; }

        public virtual DbSet<Variables> Variables { get; set; }

        public virtual DbSet<Varlabs> Varlabs { get; set; }
    }
}
