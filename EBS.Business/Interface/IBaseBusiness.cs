using EBS.Shared;

namespace EBS.Business.Interface
{
    interface IBaseBusiness
    {
        int Insert<T>(T t);

        Message Update();

        Message Delete();
    }
}
