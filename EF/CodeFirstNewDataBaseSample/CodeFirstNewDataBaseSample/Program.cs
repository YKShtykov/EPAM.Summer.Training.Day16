using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDataBaseSample
{
   class Program
   {
      static void Main(string[] args)
      {
         using (var bc = new BlogContext())
         {
            Console.WriteLine("Enter name");
            var name = Console.ReadLine();

            var blog = new Blog { Name = name };
            bc.Blogs.Add(blog);
            bc.SaveChanges();

            var query = bc.Blogs.OrderBy(b=>b.Name).Select(b=>b);

            foreach (var item in query)
            {
               Console.WriteLine(item.Name);
            }
         }
         Console.ReadKey();
      }
   }

   public class Blog
   {
      public int BlogId { get; set; }
      public string Name { get; set; }
      public string  URL { get; set; }

      public virtual List<Post> Posts { get; set; }
   }

   public class Post
   {
      public int PostId { get; set; }
      public string PostTitle { get; set; }
      public string PostContent { get; set; }

      public int BlogId { get; set; }
      public virtual Blog Blog { get; set; }
   }

   public class BlogContext: DbContext
   {
      public DbSet<Blog> Blogs { get; set; }
      public DbSet<Post> Posts { get; set; }
      public DbSet<User> Users { get; set; }
   }

   public class User
   {
      [Key]
      public string Username { get; set; }
      public string DisplayName { get; set; }
   }
}
