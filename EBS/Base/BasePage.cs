using EBS.Shared;
using System;
using System.Web.UI;

namespace EBS.Base
{
    public class BasePage : Page
    {
        protected override void OnInit(EventArgs e)
        {


            base.OnInit(e);
        }
        protected void ShowMessage(MessageType messageType)
        {
            string title = string.Empty;

            switch (messageType)
            {
                case MessageType.Success:
                    title = "Done!";
                    break;

                case MessageType.Error:
                    title = "Error!";
                    break;

                case MessageType.Warning:
                    title = "Warning!";
                    break;

                case MessageType.Information:
                    title = "Message";
                    break;
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "showMessage", string.Format("showMessage('{0}', '{1}');", title, "Process completed successfully."), true);
        }

        protected void ShowMessage(Exception ex)
        {
            string errorMessage = ex.Message.Replace("\'", "\\'");

            ScriptManager.RegisterStartupScript(this, GetType(), "showMessage", string.Format("showMessage('{0}', '{1}');", "Error", errorMessage), true);
        }

        //protected void ShowMessage(Message message)
        //{
        //    string text = message.Text.Replace("\'", "\\'");
        //    string title = string.Empty;

        //    switch (message.MessageType)
        //    {
        //        case MessageType.Success:
        //            title = "Success!";
        //            break;

        //        case MessageType.Error:
        //            title = "Error!";
        //            break;

        //        case MessageType.Warning:
        //            title = "Warning!";
        //            break;

        //        case MessageType.Information:
        //            title = "Message";
        //            break;
        //    }

        //    ScriptManager.RegisterStartupScript(this, GetType(), "showMessage", string.Format("showMessage('{0}', '{1}');", title, text), true);
        //}

        //public void LogError(Message message)
        //{
        //    ErrorHelper errorHelper = new ErrorHelper();
        //    errorHelper.LogError(message);
        //}
    }
}