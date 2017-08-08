using Sitecore.Data.Items;
using Sitecore.Modules.EmailCampaign;
using Sitecore.Modules.EmailCampaign.Xdb;
using System;

namespace Sitecore.Support.EmailCampaign.Cd
{
    public class UnsubscribeFromAll : Sitecore.EmailCampaign.Cd.Sitecore.UnsubscribeFromAll
    {

        protected override string UnsubscribeContact(XdbContactId xdbContactId, Guid messageID)
        {
            string str = ClientApi.UnsubscribeFromAll(xdbContactId, messageID);
            Item messageItem = Sitecore.Context.Database.GetItem(messageID.ToString());
            if (messageItem == null)
            {
                return "/";
            }
            return SupportHelper.GetManagerRootFromChildItem(messageItem).GetConfirmativePageUrl();
        }
    }
}