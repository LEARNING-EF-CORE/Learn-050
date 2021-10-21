using Microsoft.EntityFrameworkCore;

namespace Domain
{
	public class Group : Base.Entity
	{
		#region Configuration
		internal class Configuration : object,
			Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<Group>
		{
			public Configuration() : base()
			{
			}

			public void Configure
				(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Group> builder)
			{
				// ToTable() -> using Microsoft.EntityFrameworkCore;
				//builder
				//	.HasMany(current => current.Users)
				//	.WithMany(other => other.Groups)
				//	.UsingEntity(third => third.ToTable(name: "UsersInGroups"))
				//	;

				builder
					.HasMany(current => current.Users)
					.WithMany(other => other.Groups)
					.UsingEntity<System.Collections.Generic.Dictionary<string, object>>("MyRelationName",
						x => x.HasOne<Domain.User>().WithMany().HasForeignKey("UserId"),
						x => x.HasOne<Domain.Group>().WithMany().HasForeignKey("GroupId"),
						x => x.ToTable("UsersInGroups", "Schema")
					);
			}
		}
		#endregion /Configuration

		public Group() : base()
		{
		}

		public string Name { get; set; }

		public virtual System.Collections.Generic.IList<User> Users { get; set; }
	}
}
