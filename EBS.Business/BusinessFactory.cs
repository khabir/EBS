using EBS.Business.Implementation;

namespace EBS.Business
{
    public static class BusinessFactory
    {
        public static readonly UserBusiness UserBusiness = new UserBusiness();
    }
}
