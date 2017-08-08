using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Modules.EmailCampaign;

namespace Sitecore.Support
{
    static class SupportHelper
    {
        public static Item GetParentItemFromTemplate(Item child, string parentTemplateId, Language language)
        {
            ID id;
            Assert.ArgumentNotNull(child, "child");
            Assert.ArgumentNotNullOrEmpty(parentTemplateId, "parentTemplateId");
            Assert.ArgumentNotNull(language, "language");
            if (ID.TryParse(parentTemplateId, out id))
            {
                DataSource dataSource = child.Database.DataManager.DataSource;
                for (ID id2 = dataSource.GetParentID(child.ID); !ID.IsNullOrEmpty(id2); id2 = dataSource.GetParentID(id2))
                {
                    if (dataSource.GetItemInformation(id2).ItemDefinition.TemplateID == id)
                    {
                        return child.Database.GetItem(id2);
                    }
                }
            }
            return null;
        }
        public static Item GetParentItemFromTemplate(Item child, string parentTemplateId)
        {
            return GetParentItemFromTemplate(child, parentTemplateId, child.Language);
        }

        public static ManagerRoot GetManagerRootFromChildItem(Item childItem)
        {
            return (Factory.GetManagerRootFromItem(GetParentItemFromTemplate(childItem, "{CF9C8A2A-2794-4FEA-980A-EF8426F3D6C3}")) ?? Factory.GetManagerRootFromItem(childItem));
        }
    }
}