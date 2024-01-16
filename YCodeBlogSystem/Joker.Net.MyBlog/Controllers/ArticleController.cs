using Joker.Net.IBaseService;
using Joker.Net.Model;
using Joker.Net.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Net.MyBlog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        [HttpGet("Articles")]
        public async Task<ActionResult<ApiResult>> GetArticles()
        {
            var data = await _articleService.FindAllAsync();
            if (data.Count == 0)
            {
                return ApiResultHelper.Error("没有更多的文章");
            }
            return ApiResultHelper.Success(data);
        }


        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> CreateArticle(string title, string content, Guid TypeId)
        {
            Article article = new Article()
            {
                Title = title,
                Content = content,
                CreateTime = DateTime.Now,
                TypeId = TypeId,
                IsDeleted = false,
                ViewCount = 0,
                LikeCount = 0
            };

            var result = await _articleService.CreateAsync(article);
            if (!result)
            {
                return ApiResultHelper.Error($"{title} 添加失败!服务器发生故障");
            }
            return ApiResultHelper.Success(result);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(Guid id)
        {
            Article article = await _articleService.FindOneAsync(id);
            if (article == null)
            {
                return ApiResultHelper.Error("删除失败");
            }
            // 软删除
            article.IsDeleted = true;

            bool result = await _articleService.DeletedAsync(article);
            if (!result)
            {
                return ApiResultHelper.Error("删除失败!服务器发生故障");
            }

            return ApiResultHelper.Success(result);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(Guid id, string title, string content, Guid typeId)
        {
            Article article = await _articleService.FindOneAsync(id);
            if (article is null)
            {
                return ApiResultHelper.Error("修改失败");
            }
            article.Title = title;
            article.Content = content;
            article.TypeId = typeId;

            var result = await _articleService.UpdateAsync(article);
            if (!result)
            {
                return ApiResultHelper.Error("修改失败");
            }
            return ApiResultHelper.Success(result);
        }

    }
}
