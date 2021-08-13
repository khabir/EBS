using EBS.Shared;

namespace EBS.Data.Interface
{
    internal interface IBaseData
    {
        int Insert<T>(T obj, DbHelper dbHelper);

        Message Update();

        Message Delete();
    }
}