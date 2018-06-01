﻿using System;
using System.Collections.Generic;
using SPA.DocumentManager.Enums.Extensions;
using SPA.DocumentManager.Plans;

namespace SPA.DocumentManager.Enums
{/// <summary>
/// 枚举实现服务层
/// </summary>
    public class EnumAppService : DocumentManagerAppServiceBase, IEnumAppService
    {


        #region  通用的获取枚举类型的信息
        /// <summary>
        ///     通用的获取枚举类型的信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> GetEnumTypeList<T>()
        {
            var items = new List<KeyValuePair<string, string>>();

            typeof(T).Each(
                (name, value, description) => { items.Add(new KeyValuePair<string, string>(description, value)); });

            return items;
        }

        /// <summary>
        ///     通用的获取枚举类型的信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private List<KeyValuePair<string, int>> GetEnumTypeForIntList<T>()
        {
            var items = new List<KeyValuePair<string, int>>();

            typeof(T).Each(
                (name, value, description) => { items.Add(new KeyValuePair<string, int>(description, Convert.ToInt32(value))); });

            return items;
        }

        #endregion






        public List<KeyValuePair<string, string>> GetUnitTypeList()
        {
            return GetEnumTypeList<UnitType>();
          
        }
    }
}