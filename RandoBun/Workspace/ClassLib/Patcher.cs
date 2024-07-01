using RandoBun.Workspace.Data;
using System.IO;

namespace RandoBun.Workspace.ClassLib
{
    internal class Patcher : RandoBunObject, IPatcher
    {
        public bool WriteBytes(string filePath, PatchParams[] patchParams)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Write))
                    foreach (var item in patchParams)
                    {
                        fs.Write(item.Data, item.Offset, item.Length);
                    }
                return true;
            } catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
