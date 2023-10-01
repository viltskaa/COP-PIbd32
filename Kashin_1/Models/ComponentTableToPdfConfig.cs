using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Models
{
    public class ComponentTableToPdfConfig<T> : ComponentDocumentWithTableHeaderConfig
    {
        public List<T> Data
        {
            get;
            set;
        }
    }
}
