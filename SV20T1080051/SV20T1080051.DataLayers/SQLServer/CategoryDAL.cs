﻿using SV20T1080051.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SV20T1080051.DataLayers.SQLServer
{
        public class CategoryDAL : _BaseDAL, ICommonDAL<Category>
        {
        public CategoryDAL(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int Add(Category data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Categories where CategoryName = @CategoryName)
                                select -1
                            else
                                begin
                                    insert into Categories(CategoryName,Description)
                                    values(@CategoryName,@Description);
                                    select @@identity;
                                end";
                var parameters = new
                {
                    categoryName = data.CategoryName ?? "",
                    Description = data.Description ?? "",
                };
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return id;
        }

        public int Count(string searchValue = "")
        {
            int count = 0;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (var connection = OpenConnection())
            {
                var sql = @"select count(*) from Categories
                            where (@searchValue = N'') or (CategoryName like @searchValue)";
                var parameters = new { searchValue = searchValue };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }

            return count;
        }

        public bool Delete(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = "delete from Categories where CategoryId = @categoryId";
                var parameters = new { categoryId = id };
                result = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
                connection.Close();
            }
            return result;
        }

        public Category? Get(int id)
        {
            Category? data = null;
            using (var connection = OpenConnection())
            {
                var sql = "select * from Categories where CategoryId = @categoryId";
                var parameters = new { categoryId = id };
                data = connection.QueryFirstOrDefault<Category>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return data;
        }

        public bool InUsed(int id)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if exists(select * from Orders where CategoryId = @categoryId)
                                select 1
                            else 
                                select 0";
                var parameters = new { categoryId = id };
                result = connection.ExecuteScalar<bool>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return result;
        }

        public IList<Category> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Category> data;
            if (!string.IsNullOrEmpty(searchValue))
                searchValue = "%" + searchValue + "%";
            using (var connection = OpenConnection())
            {
                var sql = @"with cte as
                (
	                select *, row_number() over (order by CategoryName) as RowNumber
	                from Categories
	                where (@searchValue = N'') or (CategoryName like @searchValue)
                )
	            select * from cte
	            where (@pageSize=0)
		            or(RowNumber between (@page -1) * @pageSize + 1 and @page * @pageSize)
	            order by RowNumber";
                var parameters = new
                {
                    page,
                    pageSize,
                    searchValue
                };
                data = connection.Query<Category>(sql: sql, param: parameters, commandType: CommandType.Text).ToList();
                connection.Close();
            }
            if (data == null)
                data = new List<Category>();
            return data;
        }

        public bool Update(Category data)
        {
            bool result = false;
            using (var connection = OpenConnection())
            {
                var sql = @"if not exists(select * from Categories where CategoryId <> @categoryId and CategoryName = @categoryName)
                                begin
                                    update Categories 
                                    set CategoryName = @categoryName,
                                        Description = @description
                                    where CategoryId = @categoryId
                                end";
                var parameters = new
                {
                    categoryId = data.CategoryID,
                    categoryName = data.CategoryName ?? "",
                    Description = data.Description ?? "",
                };
                result = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text) > 0;
            }
            return result;
        }
    }
}
