using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SPA.DocumentManager.Localization
{
    public static class DocumentManagerLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DocumentManagerConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DocumentManagerLocalizationConfigurer).GetAssembly(),
                        "SPA.DocumentManager.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
