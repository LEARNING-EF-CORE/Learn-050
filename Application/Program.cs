//using System.Linq;
//using Microsoft.EntityFrameworkCore;

namespace Application
{
	public static class Program
	{
		static Program()
		{
		}

		public static void Main()
		{
			// فرض کنید که می‌خواهیم ریسمان جاری را فارسی کنیم
			var cultureInfo =
				new System.Globalization.CultureInfo(name: "fa");

			System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
			System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

			//LearningManyToMany();
			//LearningOneToZeroOrOne();
			LearningEnum();
		}

		public static void LearningManyToMany()
		{
			Persistence.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				// **************************************************
				// **************************************************
				// **************************************************
				var user1 =
					new Domain.User
					{
						Name = "User 1",
					};

				databaseContext.Users.Add(user1);
				// **************************************************

				// **************************************************
				var user2 =
					new Domain.User
					{
						Name = "User 2",
					};

				databaseContext.Users.Add(user2);
				// **************************************************

				// **************************************************
				var user3 =
					new Domain.User
					{
						Name = "User 3",
					};

				databaseContext.Users.Add(user3);
				// **************************************************
				// **************************************************
				// **************************************************

				//databaseContext.SaveChanges();

				// **************************************************
				// **************************************************
				// **************************************************
				var group1 =
					new Domain.Group
					{
						Name = "Group 1",
					};

				databaseContext.Groups.Add(group1);
				// **************************************************

				// **************************************************
				var group2 =
					new Domain.Group
					{
						Name = "Group 2",
					};

				databaseContext.Groups.Add(group2);
				// **************************************************

				// **************************************************
				var group3 =
					new Domain.Group
					{
						Name = "Group 3",
					};

				databaseContext.Groups.Add(group3);
				// **************************************************
				// **************************************************
				// **************************************************

				//databaseContext.SaveChanges();

				// **************************************************
				// **************************************************
				// **************************************************
				//group1.Users =
				//	new System.Collections.Generic.List<Domain.User>();

				//group1.Users.Add(user1);
				//group1.Users.Add(user2);
				// **************************************************

				// **************************************************
				group1.Users =
					new System.Collections.Generic.List<Domain.User>
					{
						user1,
						user2
					};
				// **************************************************
				// **************************************************
				// **************************************************

				//databaseContext.SaveChanges();

				// **************************************************
				// **************************************************
				// **************************************************
				//user3.Groups =
				//	new System.Collections.Generic.List<Domain.Group>();

				//user3.Groups.Add(group1);
				//user3.Groups.Add(group2);
				// **************************************************

				// **************************************************
				user3.Groups =
					new System.Collections.Generic.List<Domain.Group>
					{
						group1,
						group2
					};
				// **************************************************
				// **************************************************
				// **************************************************

				// Group1:
				//		User1
				//		User2
				//		User3
				// Group2:
				//		User3

				// **************************************************
				// **************************************************
				// **************************************************
				//group2.Users =
				//	new System.Collections.Generic.List<Domain.User>();

				//group2.Users.Add(user1);
				//group2.Users.Add(user3);
				// **************************************************

				// **************************************************
				group2.Users =
					new System.Collections.Generic.List<Domain.User>
					{
						user1,
						user3
					};
				// **************************************************
				// **************************************************
				// **************************************************

				databaseContext.SaveChanges();
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					//databaseContext = null;
				}
			}
		}

		public static void LearningOneToZeroOrOne()
		{
			Persistence.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				// **************************************************
				// **************************************************
				// **************************************************
				var user =
					new Domain.User
					{
						Name = "User",
					};

				var userProfile =
					new Domain.UserProfile
					{
						FatherName = "Father name",
					};

				user.UserProfile = userProfile;

				databaseContext.Users.Add(user);
				// **************************************************

				databaseContext.SaveChanges();
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					//databaseContext = null;
				}
			}
		}

		public static void LearningEnum()
		{
			Persistence.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Persistence.DatabaseContext();

				// **************************************************
				// **************************************************
				// **************************************************
				var user =
					new Domain.User
					{
						Name = "User",
						Gender = Domain.Enums.Gender.Female,
					};

				databaseContext.Users.Add(user);
				// **************************************************

				databaseContext.SaveChanges();
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					//databaseContext = null;
				}
			}
		}
	}
}
