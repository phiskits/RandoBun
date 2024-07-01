using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.Data
{
    public struct PatchParams
    {
        /// <summary>
        /// File-position to write to
        /// </summary>
        public long Position;

        /// <summary>
        /// Data to write to the file
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// Length of the data to write
        /// </summary>
        public int Length;

        /// <summary>
        /// Offset from the file position
        /// </summary>
        public int Offset;
    }
}
