using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Models
{
    public class ComponentTextToPdfConfig : ComponentDocumentConfig
    {
        public List<string> Paragraphs
        {
            get;
            set;
        }
    }
}
