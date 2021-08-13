using EBS.Data;

namespace EBS.Helpers
{
    public static class ConfigurationHelper
    {
        public static void SetConnectionString()
        {
            //DbHelper.SetConnectionString(".", "EBS", "sa", "Password_1");
            DbHelper.SetConnectionString("23b78545-0d9e-4687-b9d5-a28d00805b20.sqlserver.sequelizer.com", "db23b785450d9e4687b9d5a28d00805b20", "cufzhmzyccsyrlby", "wjoBeZCiixDbdJNCDAPFtuXqu4mq2P4AMuPQd8LmseV4a34DzpCpTDMct6gjNmpB");
            
        }
    }
}
