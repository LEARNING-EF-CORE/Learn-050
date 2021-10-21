namespace Domain
{
	public class User : Base.Entity
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
				builder
					.HasOne(current => current.UserProfile)
					.WithOne(other => other.User)
					//.HasForeignKey(dependentEntityTypeName: "UserId")
					.OnDelete(deleteBehavior: Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade)
					.IsRequired(required: false)
					;

				// **************************************************
				var user1 =
					new User
					{
						Name = "Manager",
					};

				var user2 =
					new User
					{
						Name = "Administrator",
					};

				builder.HasData(user1, user2);
				// **************************************************
			}
		}
		#endregion /Configuration

		public User() : base()
		{
		}

		public string Name { get; set; }

		// دستور ذیل برای نسخه‌های خیلی قدیمی است
		//[System.ComponentModel.DisplayName(displayName: "شناسه کاربری")]

		//[System.ComponentModel.DataAnnotations.Display(Name = "شناسه کاربری")]

		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary), Name = "Username")]

		// دستور ذیل خطا می‌دهد
		//[System.ComponentModel.DataAnnotations.Display
		//	(ResourceType = typeof(Resources.DataDictionary),
		//	Name = Resources.DataDictionary.Username)]

		[System.ComponentModel.DataAnnotations.Display
			(ResourceType = typeof(Resources.DataDictionary),
			Name = nameof(Resources.DataDictionary.Username))]

		//[System.ComponentModel.DataAnnotations.Required]

		//[System.ComponentModel.DataAnnotations.Required
		//	(ErrorMessage = "You did not specify Username!")]

		//[System.ComponentModel.DataAnnotations.Required
		//	(ErrorMessage = "You did not specify {0}!")]

		[System.ComponentModel.DataAnnotations.Required
			(ErrorMessageResourceType = typeof(Resources.Messages.Validator),
			ErrorMessageResourceName = nameof(Resources.Messages.Validator.Required))]
		public string Username { get; set; }

		public Enums.Gender Gender { get; set; }

		public virtual UserProfile UserProfile { get; set; }

		public virtual System.Collections.Generic.IList<Group> Groups { get; set; }
	}
}
