using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.Data
{
    public class FileReaderResult
    {
        /// <summary>
        /// Collection of the File's contents. Key is the address, value is a list of file entries of that address
        /// </summary>
        public Dictionary<long, FileReaderEntry[]> Items;

        public FileReaderResult()
        {
            Items = new Dictionary<long, FileReaderEntry[]>();
        }
    }
}
