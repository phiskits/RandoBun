using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.Data
{
    public struct RandomizerWorkerParams
    {
        /// <summary>
        /// Random seed for the randomizer class
        /// </summary>
        public int Seed;

        /// <summary>
        /// File name to write the patch to (ISO file, etc)
        /// </summary>
        public string FileName;
    }
}
