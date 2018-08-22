using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SPA.DocumentManager.TaskBooks.Dtos;
using SPA.DocumentManager.TaskBooks;
using System;

namespace SPA.DocumentManager.TaskBooks
{
    /// <summary>
    /// TaskBook应用层服务的接口方法
    /// </summary>
    public interface ITaskBookAppService : IApplicationService
    {
        /// <summary>
        /// 获取TaskBook的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<TaskBookListDto>> GetPagedTaskBooks(GetTaskBooksInput input);

        /// <summary>
        /// 获取任务书的年份
        /// </summary>
        /// <returns></returns>
        ListResultDto<string> GetTaskBookYears();

        /// <summary>
        /// 通过指定id获取TaskBookListDto信息
        /// </summary>
        Task<TaskBookListDto> GetTaskBookByIdAsync(EntityDto<int> input);


        /// <summary>
        /// 导出TaskBook为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetTaskBooksToExcel();

        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetTaskBookForEditOutput> GetTaskBookForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetTaskBookForEditOutput


        /// <summary>
        /// 添加或者修改TaskBook的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateTaskBook(CreateOrUpdateTaskBookInput input);


        /// <summary>
        /// 删除TaskBook信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteTaskBook(EntityDto<int> input);


        /// <summary>
        /// 批量删除TaskBook
        /// </summary>
        Task BatchDeleteTaskBooksAsync(List<int> input);


		//// custom codes 
		
        //// custom codes end
    }
}
