using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public class RandomizerWorkerBase : RandoBunObject, IRandomizerWorker
    {
        public void RunWorker(RandomizerWorkerParams workerParams)
        {
            // initialize randomizer
            Randomizer.Initialize(workerParams.Seed);

            var fileReader = new FileConfigReader() as IFileReader;

            // read files
            var fileReaderResult = fileReader.ReadFile("");

            // prepare patch
            var patchParams = GetPatchParams(new FileReaderResult[] { fileReaderResult });

            // initialize patcher
            var patcher = new Patcher() as IPatcher;

            // apply patch
            patcher.WriteBytes(workerParams.FileName, patchParams);
        }

        protected PatchParams[] GetPatchParams(FileReaderResult[] fileReaderResults)
        {
            List<PatchParams> results = new List<PatchParams>();
            // initialize converter
            var converter = new Converter() as IConverter;

            // loop through file reader results
            foreach (var result in fileReaderResults)
            {
                // loop through keys
                foreach (var key in result.Items.Keys)
                {
                    // build patch params
                    var item = result.Items[key];

                    // loop entries
                    foreach (var entry in item.ToArray())
                    {
                        // get value in bytes
                        var data = converter.ToBytes(entry.Value, entry.Type);

                        // build patch params
                        var patchParams = new PatchParams()
                        {
                            Position = key,
                            Data = data,
                            Length = 4,
                            Offset = entry.Offset
                        };
                    }
                }
            }

            return results.ToArray();
        }
    }
}
