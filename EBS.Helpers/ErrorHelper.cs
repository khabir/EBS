using EBS.Data;
using System;

namespace EBS.Helpers
{
    public class ErrorHelper
    {
        public static Exception LogError(Exception exception)
        {
            DbHelper db = DbHelper.Begin(true);

            // TODO: Log error here

            db.End();

            return exception;
        }
    }
}