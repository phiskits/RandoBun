using RandoBun.Workspace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoBun.Workspace.ClassLib
{
    public interface IRandomizerWorker
    {
        /// <summary>
        /// Run worker with parameters
        /// </summary>
        /// <param name="workerParams">Worker parameters</param>
        public void RunWorker(RandomizerWorkerParams workerParams);

        //public void Initialize(RandomizerWorkerParams workerParams);
    }
}
