using EBS.Data.Interface;
using EBS.Entities.BaseEntities;
using EBS.Shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace EBS.Data.Implementation
{
    public class UserData : IBaseData
    {
        public Message Delete()
        {
            var message = new Message();

            try
            {
                message.ExecutionStatus = ExecutionStatus.Success;
            }
            catch (Exception e)
            {
                message.ExecutionStatus = ExecutionStatus.Failed;
                message.Exception = e;
            }

            return message;
        }

        public List<User> GetAll(DbHelper dbHelper)
        {
            try
            {
                DataTable dataTable = dbHelper.ExecuteDataTable(StoredProcedures.UserConstant.GET_ALL_USER, null);

                List<User> users = dataTable.ToList<User>();

                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User Get(DbHelper dbHelper, int ID)
        {
            try
            {
                DataTable dataTable = dbHelper.ExecuteDataTable(StoredProcedures.UserConstant.GET_USER_BY_ID, null);

                User user = dataTable.ToObject<User>();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert<T>(T entity, DbHelper dbHelper)
        {
            try
            {
                return dbHelper.ExecuteNonQuery(StoredProcedures.UserConstant.INSERT_USER, entity);
            }
            catch (Exception)
            {
                // TODO: Log error
                throw;
            }
        }

        public Message Update()
        {
            throw new NotImplementedException();
        }

        //public Message Insert<T>(T entity, DbHelper dbHelper)
        //{
        //    var message = new Message();

        //    try
        //    {
        //        dbHelper.ExecuteNonQuery(StoredProcedures.INSERT_USER, entity);
        //        message.ExecutionStatus = ExecutionStatus.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        message.ExecutionStatus = ExecutionStatus.Failed;
        //        message.Exception = ex;
        //    }

        //    return message;
        //}
    }
}