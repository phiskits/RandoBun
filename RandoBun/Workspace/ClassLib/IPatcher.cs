using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandoBun.Workspace.Data;

namespace RandoBun.Workspace.ClassLib
{
    public interface IPatcher
    {
        public bool WriteBytes(string filePath, PatchParams[] patchParams);
    }
}
