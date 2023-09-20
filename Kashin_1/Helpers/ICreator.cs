using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Helpers
{
    public interface ICreator
    {
        void CreateHeader(string header);

        void SaveDoc(string filepath);
    }
}
