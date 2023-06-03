namespace Forum.Services.Interfaces;

using ViewModels.Post;

public interface IPostService
{
    Task<IEnumerable<PostListViewModel>> ListAllAsync();
}