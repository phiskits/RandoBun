using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public interface IFileReader
    {
        public FileReaderResult ReadFile(string filename);
    }
}
