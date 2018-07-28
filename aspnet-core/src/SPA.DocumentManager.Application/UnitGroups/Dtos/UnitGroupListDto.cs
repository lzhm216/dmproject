using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using SPA.DocumentManager.UnitGroups;

namespace SPA.DocumentManager.UnitGroups.Dtos
{ 
    public class UnitGroupListDto : FullAuditedEntityDto<int>
    {
    
        /// <summary>
/// Id
/// </summary>
public int? Id { get; set; }


/// <summary>
/// UnitGroupName
/// </summary>
[Required(ErrorMessage="UnitGroupName不能为空")]
public string UnitGroupName { get; set; }


/// <summary>
/// Contact
/// </summary>
[MaxLength(50, ErrorMessage="Contact超出最大长度")]
[Required(ErrorMessage="Contact不能为空")]
public string Contact { get; set; }


/// <summary>
/// ContactPhone
/// </summary>
[MaxLength(11, ErrorMessage="ContactPhone超出最大长度")]
[Required(ErrorMessage="ContactPhone不能为空")]
public string ContactPhone { get; set; }



		
		
		
		//// custom codes 
		
        //// custom codes end
    }
}