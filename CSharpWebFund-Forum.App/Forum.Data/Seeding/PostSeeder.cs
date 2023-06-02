namespace Forum.Data.Seeding;

using Models;
class PostSeeder
{

    internal Post[] GeneratePosts()
    {
        ICollection<Post> posts = new HashSet<Post>();
        Post currentPost;

        currentPost = new Post()
        {
            Title = "My first post",
            Content = 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean elementum rhoncus nunc sed ullamcorper. Sed sed urna pellentesque, placerat augue."
        };

        posts.Add(currentPost);

        currentPost = new Post()
        {
            Title = "My second post",
            Content =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ut enim non nibh euismod pretium. Ut malesuada nulla ut mattis."
        };

        posts.Add(currentPost);

        currentPost = new Post()
        {
            Title = "My third post",
            Content =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In faucibus nunc nec augue congue tincidunt. Donec tristique, leo sollicitudin dignissim."
        };
        posts.Add(currentPost);

        return posts.ToArray();
    }
}