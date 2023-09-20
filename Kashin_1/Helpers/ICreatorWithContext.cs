using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Helpers
{
    public interface ICreatorWithContext : ICreator
    {
        void CreateParagraph(string text);

    }
}
