using EBS.Base;
using EBS.Business;
using EBS.Entities.BaseEntities;
using EBS.Helpers;
using EBS.Shared;
using System;
using System.Collections.Generic;

namespace EBS
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigurationHelper.SetConnectionString();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                //var user = new User();

                //user.FirstName = firstNameTextBox.Text.Trim();
                //user.LastName = lastNameTextBox.Text.Trim();
                //user.Password = passwordTextBox.Text.Trim();
                //user.Type = 1;
                //user.UpdatedBy = 5;

                //int ret = BusinessFactory.UserBusiness.Insert(user);

                //if (ret == 1)
                //    ShowMessage(MessageType.Success);

                List<User> userList = BusinessFactory.UserBusiness.GetAll();
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }
    }
}