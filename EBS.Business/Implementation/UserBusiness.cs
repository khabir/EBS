using EBS.Business.Interface;
using EBS.Data;
using EBS.Entities.BaseEntities;
using EBS.Helpers;
using EBS.Shared;
using System;
using System.Collections.Generic;

namespace EBS.Business.Implementation
{
    public class UserBusiness : IBaseBusiness
    {
        public Message Delete()
        {
            return new Message();
        }

        public List<User> Get()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ErrorHelper.LogError(ex);
            }

            return null;
        }

        public List<User> GetAll()
        {
            try
            {
                DbHelper db = DbHelper.Begin();

                var data = DataFactory.UserData.GetAll(db);

                db.End();

                return data;
            }
            catch (Exception ex)
            {
                ErrorHelper.LogError(ex);
                throw;
            }
        }

        public int Insert<T>(T entity)
        {
            try
            {
                DbHelper db = DbHelper.Begin(true);

                int ret = DataFactory.UserData.Insert(entity, db);

                db.End();

                return ret;
            }
            catch (Exception ex)
            {
                throw ErrorHelper.LogError(ex);
            }
        }

        public Message Update()
        {
            return new Message();
        }

        //public Message Insert<T>(T entity)
        //{
        //    var message = new Message();

        //    try
        //    {
        //        DbHelper db = DbHelper.Begin(true);

        //        message = DataFactory.UserData.Insert(entity, db);

        //        db.End();

        //        if (message.ExecutionStatus == ExecutionStatus.Success)
        //        {
        //            message.Text = "User information saved successfully.";
        //        }
        //        else if(message.ExecutionStatus== ExecutionStatus.Failed)
        //        {
        //            message.Text = message.Exception.Message;
        //            message.MessageType = MessageType.Error;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message.Exception = ex;
        //        message.Text = ex.Message;
        //        message.MessageType = MessageType.Error;
        //    }

        //    return message;
        //}
    }
}
