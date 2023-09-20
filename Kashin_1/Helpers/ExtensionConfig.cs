using CustomComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Helpers
{
    public static class ExtensionConfig
    {
        public static void CheckFields(this ComponentTextToPdfConfig config)
        {
            if (config.Header.IsEmpty() || config.FilePath.IsEmpty() || (config.Paragraphs != null && config.Paragraphs.Count == 0) || (config.Paragraphs != null && config.Paragraphs.All((string x) => x.IsEmpty())))
            {
                throw new ArgumentNullException("Нет текста для вставки в документ");
            }
        }
    }
}
