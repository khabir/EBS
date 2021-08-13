using EBS.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace EBS.Data
{
    public class DbHelper : IDisposable
    {
        private static string _connectionString;
        private bool _createSession;
        private SqlCommand _cmd;
        private SqlConnection _con;
        private SqlTransaction _trans;

        private DbHelper(bool createSession = false)
        {
            _createSession = createSession;
        }

        public static DbHelper Begin(bool createSession = false)
        {
            return new DbHelper(createSession);
        }

        private static string GetConnectionString()
        {
            return _connectionString;
        }

        public static void SetConnectionString(string server, string database, string user, string password)
        {
            _connectionString = "Data Source=" + server + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + user + ";Password=" + password + "";
        }

        private IEnumerable<SqlParameter> CreateSqlParameterFromEntity<T>(T t)
        {
            var parameters = new List<SqlParameter>();
            var properties = new List<PropertyInfo>(GetObjectProperties(typeof(T)));

            foreach (PropertyInfo p in properties)
            {
                string columnName = p.Name;
                object value = p.GetValue(t, null);

                object[] attributes = p.GetCustomAttributes(true);

                foreach (object obj in attributes)
                {
                    var dbAttribute = obj as DataValidationAttribute;

                    if (dbAttribute != null)
                    {
                        if (!dbAttribute.Exclude)
                        {
                            if (dbAttribute.Required && (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString())))
                                throw new Exception("Value for property '" + columnName + "' is not supplied.");

                            if (dbAttribute.MinLength > 0)
                            {
                                if (value.ToString().Length < dbAttribute.MinLength)
                                    throw new Exception("Value for property '" + columnName + "' should be at least '" + dbAttribute.MinLength + "' character long.");
                            }

                            if (dbAttribute.MaxLength > 0)
                            {
                                if (value.ToString().Length > dbAttribute.MaxLength)
                                    throw new Exception("Value for property '" + columnName + "' should not be more than '" + dbAttribute.MaxLength + "' character long.");
                            }

                            parameters.Add(new SqlParameter(columnName, value));
                        }
                    }
                }
            }

            return parameters;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public void End()
        {
            try
            {
                if (_createSession && _trans != null)
                    _trans.Commit();

                if (_con != null && _con.State == ConnectionState.Open)
                    _con.Close();

                //_trans = null;
                //_con = null;
                _createSession = false;

                //_cmd = null;
            }
            catch
            {
                if (_trans != null)
                    _trans.Rollback();
            }
            finally
            {
                Dispose();
            }
        }

        public DataTable ExecuteDataTable(string commandText)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = commandText;

                IDataReader reader = _cmd.ExecuteReader();

                var table = new DataTable("Table1");
                table.Load(reader, LoadOption.PreserveChanges);

                reader.Close();

                return table;
            }
            catch (Exception e)
            {
                throw new Exception("Error!", e);
            }
        }

        public DataTable ExecuteDataTable(string procedure, IEnumerable<SqlParameter> parameters)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = procedure;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        _cmd.Parameters.Add(item);
                    }
                }

                IDataReader reader = _cmd.ExecuteReader();

                var table = new DataTable("Table1");
                table.Load(reader, LoadOption.PreserveChanges);

                reader.Close();

                return table;
            }
            catch (Exception e)
            {
                HandleError();
                throw new Exception("Error!", e);
            }
        }

        public int ExecuteNonQuery(string commandText)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = commandText;

                return _cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error!", e);
            }
        }

        public int ExecuteNonQuery(string procedure, IEnumerable<SqlParameter> parameters)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = procedure;

                foreach (var item in parameters)
                    _cmd.Parameters.Add(item);

                return _cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                HandleError();
                throw new Exception("Error!", e);
            }
        }

        public int ExecuteNonQuery<T>(string procedure, T entity)
        {
            try
            {
                IEnumerable<SqlParameter> parameters = CreateSqlParameterFromEntity(entity);

                PrepareCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = procedure;

                foreach (var item in parameters)
                    _cmd.Parameters.Add(item);

                return _cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                HandleError();
                throw;
            }
        }

        public object ExecuteScalar(string commandText)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.Text;
                _cmd.CommandText = commandText;

                return _cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Error!", e);
            }
        }

        public object ExecuteScalar(string procedure, IEnumerable<SqlParameter> parameters)
        {
            try
            {
                PrepareCommand();

                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandText = procedure;

                foreach (var item in parameters)
                    _cmd.Parameters.Add(item);

                return _cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                HandleError();
                throw new Exception("Error!", e);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_trans.Dispose();
                //_cmd.Dispose();
                //_con.Dispose();
            }
        }

        private IEnumerable<PropertyInfo> GetObjectProperties(Type type)
        {
            var properties = new List<PropertyInfo>();

            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(type);

            foreach (PropertyDescriptor item in pdc)
                if (item.IsBrowsable)
                    properties.Add(type.GetProperty(item.Name));

            return properties;
        }

        private void HandleError()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _createSession = false;
            }

            if (_con != null && _con.State == ConnectionState.Open)
                _con.Close();
        }

        private void PrepareCommand()
        {
            string conStr = GetConnectionString();

            if (string.IsNullOrEmpty(conStr))
                throw new Exception("Connection string not found!");

            if (_cmd != null)
            {
                _cmd.Parameters.Clear();
                return;
            }

            _cmd = new SqlCommand();
            _con = new SqlConnection(conStr);
            if (_con.State == ConnectionState.Closed)
                _con.Open();

            _cmd.Connection = _con;

            if (_createSession)
            {
                _trans = _con.BeginTransaction();
                _cmd.Transaction = _trans;
            }
        }

        //private Type GetPropertyType(Type type)
        //{
        //    if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
        //        return Nullable.GetUnderlyingType(type);

        //    return type;
        //}
    }
}