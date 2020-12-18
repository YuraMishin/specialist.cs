using System;

namespace DataBaseFirstDemo
{
    /// <summary>
    /// Simple Database-First Workflow Example
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point to the app
        /// </summary>
        static void Main()
        {
            var context = new DataBaseFirstDemoEntities();
            var post = new Post()
            {
                PostId = 1,
                DatePublished = DateTime.Now,
                Title = "Title",
                Body = "Body"
            };
            context.Posts.Add(post);
            context.SaveChanges();
            Console.WriteLine("1 entry is added");
        }
    }
}
