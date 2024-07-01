using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public interface IConverter
    {
        public byte[] ToBytes(object obj);

        public byte[] ToBytes(object obj, EntryValueType type);

        public object ToEntryValueType(string input, EntryValueType type);
    }
}
