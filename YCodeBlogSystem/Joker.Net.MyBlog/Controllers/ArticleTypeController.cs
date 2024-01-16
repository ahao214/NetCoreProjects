using AutoMapper;
using Joker.Net.IBaseService;
using Joker.Net.Model;
using Joker.Net.Model.DTO;
using Joker.Net.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Net.MyBlog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleTypeController : ControllerBase
    {
        private readonly IArticleTypeService _articleTypeService;
        private readonly IMapper _mapper;

        public ArticleTypeController(IArticleTypeService articleTypeService, IMapper mapper)
        {
            this._articleTypeService = articleTypeService;
            _mapper = mapper;
        }

        [HttpGet("GetTypes")]

        public async Task<ActionResult<ApiResult>> GetTypes()
        {
            var data = await _articleTypeService.FindAllAsync();
            if (data.Count == 0)
            {
                return ApiResultHelper.Error("没有更多的文章类型");
            }

            List<ArticleTypeDTO> articleTypeDTO = new List<ArticleTypeDTO>();
            foreach (var item in data)
            {
                articleTypeDTO.Add(_mapper.Map<ArticleTypeDTO>(item));
            }

            return ApiResultHelper.Success(articleTypeDTO);
        }

        [HttpPost("Create")]

        public async Task<ActionResult<ApiResult>> Create(string TypeName)
        {
            ArticleType type = new ArticleType()
            {
                TypeName = TypeName,
                IsDeleted = false
            };

            var result = await _articleTypeService.CreateAsync(type);

            if (!result)
            {
                return ApiResultHelper.Error($"{TypeName} 类型创建失败!");
            }

            return ApiResultHelper.Success(result);
        }

        [HttpDelete("Deleted")]

        public async Task<ActionResult<ApiResult>> Delete(Guid id)
        {
            var data = await _articleTypeService.FindOneAsync(id);
            if (data is null)
            {
                return ApiResultHelper.Error($"删除失败");
            }

            data.IsDeleted = true;

            var result = await _articleTypeService.DeletedAsync(data);

            if (!result)
            {
                return ApiResultHelper.Error($"删除失败");
            }

            return ApiResultHelper.Success(result);
        }

        [HttpPut("Edit")]

        public async Task<ActionResult<ApiResult>> Edit(Guid id, string TypeName)
        {
            var data = await _articleTypeService.FindOneAsync(id);
            if (data is null)
            {
                return ApiResultHelper.Error($"修改失败");
            }

            data.TypeName = TypeName;

            var result = await _articleTypeService.UpdateAsync(data);

            if (!result)
            {
                return ApiResultHelper.Error($"修改失败");
            }
            return ApiResultHelper.Success(result);
        }

    }
}
