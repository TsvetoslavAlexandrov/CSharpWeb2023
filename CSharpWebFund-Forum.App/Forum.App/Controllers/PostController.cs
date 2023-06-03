using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Forum.App.Controllers;

public class PostController : Controller
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
            this.postService = postService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<PostListViewModel> allPosts =
            await this.postService.ListAllAsync();

        return View(allPosts);
    }
}