using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;

using System.Linq.Dynamic.Core;
 using Microsoft.EntityFrameworkCore; 
using SPA.DocumentManager.TaskBooks.Authorization;
using SPA.DocumentManager.TaskBooks.DomainServices;
using SPA.DocumentManager.TaskBooks.Dtos;
using SPA.DocumentManager.TaskBooks;

namespace SPA.DocumentManager.TaskBooks
{
    /// <summary>
    /// TaskBook应用层服务的接口实现方法
    /// </summary>
	[AbpAuthorize(TaskBookAppPermissions.TaskBook)]
    public class TaskBookAppService : DocumentManagerAppServiceBase, ITaskBookAppService
    {
		private readonly IRepository<TaskBook, int> _taskbookRepository;

		private readonly ITaskBookManager _taskbookManager;
		
		/// <summary>
		/// 构造函数
		/// </summary>
		public TaskBookAppService(
			IRepository<TaskBook, int> taskbookRepository
			,ITaskBookManager taskbookManager
		)
		{
			_taskbookRepository = taskbookRepository;
			 _taskbookManager=taskbookManager;
		}
		
		
		/// <summary>
		/// 获取TaskBook的分页列表信息
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public  async  Task<PagedResultDto<TaskBookListDto>> GetPagedTaskBooks(GetTaskBooksInput input)
		{
		    
		    var query = _taskbookRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
		
			var taskbookCount = await query.CountAsync();
		
			var taskbooks = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();
		
				// var taskbookListDtos = ObjectMapper.Map<List <TaskBookListDto>>(taskbooks);
				var taskbookListDtos =taskbooks.MapTo<List<TaskBookListDto>>();
		
				return new PagedResultDto<TaskBookListDto>(
							taskbookCount,
							taskbookListDtos
					);
		}
		

		/// <summary>
		/// 通过指定id获取TaskBookListDto信息
		/// </summary>
		public async Task<TaskBookListDto> GetTaskBookByIdAsync(EntityDto<int> input)
		{
			var entity = await _taskbookRepository.GetAsync(input.Id);
		
		    return entity.MapTo<TaskBookListDto>();
		}
		
		/// <summary>
		/// MPA版本才会用到的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async  Task<GetTaskBookForEditOutput> GetTaskBookForEdit(NullableIdDto<int> input)
		{
			var output = new GetTaskBookForEditOutput();
			TaskBookEditDto taskbookEditDto;
		
			if (input.Id.HasValue)
			{
				var entity = await _taskbookRepository.GetAsync(input.Id.Value);
		
				taskbookEditDto = entity.MapTo<TaskBookEditDto>();
		
				//taskbookEditDto = ObjectMapper.Map<List <taskbookEditDto>>(entity);
			}
			else
			{
				taskbookEditDto = new TaskBookEditDto();
			}
		
			output.TaskBook = taskbookEditDto;
			return output;
		}
		
		
		/// <summary>
		/// 添加或者修改TaskBook的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public async Task CreateOrUpdateTaskBook(CreateOrUpdateTaskBookInput input)
		{
		    
			if (input.TaskBook.Id.HasValue)
			{
				await UpdateTaskBookAsync(input.TaskBook);
			}
			else
			{
				await CreateTaskBookAsync(input.TaskBook);
			}
		}
		

		/// <summary>
		/// 新增TaskBook
		/// </summary>
		[AbpAuthorize(TaskBookAppPermissions.TaskBook_CreateTaskBook)]
		protected virtual async Task<TaskBookEditDto> CreateTaskBookAsync(TaskBookEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增
		
			var entity = ObjectMapper.Map <TaskBook>(input);
		
			entity = await _taskbookRepository.InsertAsync(entity);
			return entity.MapTo<TaskBookEditDto>();
		}
		
		/// <summary>
		/// 编辑TaskBook
		/// </summary>
		[AbpAuthorize(TaskBookAppPermissions.TaskBook_EditTaskBook)]
		protected virtual async Task UpdateTaskBookAsync(TaskBookEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新
		
			var entity = await _taskbookRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);
		
			// ObjectMapper.Map(input, entity);
		    await _taskbookRepository.UpdateAsync(entity);
		}
		

		
		/// <summary>
		/// 删除TaskBook信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(TaskBookAppPermissions.TaskBook_DeleteTaskBook)]
		public async Task DeleteTaskBook(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _taskbookRepository.DeleteAsync(input.Id);
		}
		
		
		
		/// <summary>
		/// 批量删除TaskBook的方法
		/// </summary>
		[AbpAuthorize(TaskBookAppPermissions.TaskBook_BatchDeleteTaskBooks)]
		public async Task BatchDeleteTaskBooksAsync(List<int> input)
		{
			//TODO:批量删除前的逻辑判断，是否允许删除
			await _taskbookRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出TaskBook为excel表
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetTaskBooksToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}


		
		//// custom codes 
		
        //// custom codes end

    }
}


 