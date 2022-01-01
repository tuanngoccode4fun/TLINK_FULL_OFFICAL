using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTechLink;

namespace EFTechLink.Interface
{
    public interface IDataContextAction
    {
        ImportTransaction select(string qRCode, string headerCode, string headerNo, string headerSTT);

        bool Insert(ImportTransaction transaction);

        bool Delete(ImportTransaction transaction);

        bool Update(ImportTransaction transaction);

    }
}
