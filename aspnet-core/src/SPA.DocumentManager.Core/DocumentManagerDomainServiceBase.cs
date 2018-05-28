using Abp.Domain.Services;

namespace SPA.DocumentManager
{
    public abstract class DocumentManagerDomainServiceBase : DomainService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /* Add your common members for all your domain services. */
        /*在领域服务中添加你的自定义公共方法*/
        protected DocumentManagerDomainServiceBase()
        {
            LocalizationSourceName = DocumentManagerConsts.LocalizationSourceName;
        }
    }
}
