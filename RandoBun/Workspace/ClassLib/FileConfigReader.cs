using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace RandoBun.Workspace.ClassLib
{
    public class FileConfigReader : RandoBunObject, IFileReader
    {
        public FileReaderResult ReadFile(string fileName)
        {
            // initialize result
            FileReaderResult result = new FileReaderResult();

            // read lines
            var lines = File.ReadLines(fileName);

            // initialize counter
            var counter = 0;

            // iterate through lines
            foreach (var line in lines)
            {
                if (counter != 0)
                {
                    // split by tab
                    string[] split = line.Split(new char[] { '\u0009' });

                    // get address
                    var address = Convert.ToInt64(split[0], 16);

                    // read line and ignore address part
                    var entry = ParseLine(split.Skip(1).ToArray());

                    // add to items
                    result.Items.Add(address, entry);
                }
                // increment counter
                counter++;
            }

            return result;
        }

        /// <summary>
        /// Parse line into FileReaderEntry array (without address)
        /// </summary>
        /// <param name="line">Line to parse (without address)</param>
        /// <returns>Parsed FileReaderEntry array</returns>
        protected FileReaderEntry[] ParseLine(string[] line)
        {
            // get count
            var count = line.Length;
            // get iterations
            var iterations = count / 3;
            // initialize results array
            var results = new FileReaderEntry[iterations];
            // initialize index
            var index = 0;

            // iterate through iterations
            for (var i = 0; i < iterations; i++)
            {
                // get offset
                var offset = Convert.ToInt32(line[index]);
                // get type
                var type = Enum.Parse<EntryValueType>(line[index + 1]);
                // get value
                var value = GetValue(line[index + 2], type);
                // add to results
                results[i] = new FileReaderEntry(offset, type, value);
                index += 3;
            }
            return results;
        }

        /// <summary>
        /// Get value from value range
        /// </summary>
        /// <param name="valueRange">Value range</param>
        /// <param name="type">Type of the value</param>
        /// <returns>Determined single value from range</returns>
        protected object GetValue(string valueRange, EntryValueType type)
        {
            object result = valueRange;
            // check if value range contains comma
            if (valueRange.Contains(","))
            {
                // split by comma
                var split = valueRange.Split(new char[] { ',' });

                // get random item
                var item = split[Randomizer.GetInt(split.Length)];
            } else if (valueRange.Contains("#"))
            {
                // split by hash
                var split = valueRange.Split(new char[] { '#' });

                switch (type)
                {
                    // determine value based on type
                    case EntryValueType.INT:
                        result = Randomizer.GetInt(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
                        break;
                    case EntryValueType.FLOAT:
                        result = Randomizer.GetFloat(Convert.ToSingle(split[0]), Convert.ToSingle(split[1]));
                        break;
                }
            }

            return result;
        }
    }
}
