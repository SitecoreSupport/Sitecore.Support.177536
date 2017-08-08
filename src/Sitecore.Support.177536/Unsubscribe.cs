

using Sitecore.Data.Items;
using Sitecore.Modules.EmailCampaign;
using Sitecore.Modules.EmailCampaign.Xdb;
using System;

namespace Sitecore.Support.EmailCampaign.Cd
{
    public class Unsubscribe : Sitecore.EmailCampaign.Cd.Sitecore.Unsubscribe
    {
        protected override string UnsubscribeContact(XdbContactId xdbContactId, Guid messageID)
        {
            string str = ClientApi.Unsubscribe(xdbContactId, messageID);
            Item messageItem = Sitecore.Context.Database.GetItem(messageID.ToString());
            if (messageItem == null)
            {
                return "/";
            }
            return SupportHelper.GetManagerRootFromChildItem(messageItem).GetConfirmativePageUrl();
        }
    }
}