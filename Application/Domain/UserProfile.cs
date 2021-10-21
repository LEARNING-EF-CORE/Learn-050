namespace Domain
{
	public class UserProfile : object
	{
		#region Configuration
		internal class Configuration : object,
			Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<User>
		{
			public Configuration() : base()
			{
			}

			public void Configure
				(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
			{
			}
		}
		#endregion /Configuration

		public UserProfile() : base()
		{
		}

		[System.ComponentModel.DataAnnotations.Key]
		public System.Guid UserId { get; set; }

		public virtual User User { get; set; }

		public string FatherName { get; set; }
	}
}
