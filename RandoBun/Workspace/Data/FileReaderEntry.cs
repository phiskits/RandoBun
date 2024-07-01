using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.Data
{
    public struct FileReaderEntry
    {
        /// <summary>
        /// Offset from the address
        /// </summary>
        public int Offset { get; private set; }

        /// <summary>
        /// Type of the value which will be written
        /// </summary>
        public EntryValueType Type { get; private set; }

        /// <summary>
        /// Value to write to the address + offset
        /// </summary>
        public object Value { get; private set; }

        public FileReaderEntry(int offset, EntryValueType type, object value) 
        { 
            Offset = offset; Type = type; Value = value; 
        }
    }
}
