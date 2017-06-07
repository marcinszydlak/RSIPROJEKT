using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MovieServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WorkerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WorkerService.svc or WorkerService.svc.cs at the Solution Explorer and start debugging.
    public class WorkerService : IWorkerService
    {
        public void DoWork()
        {
        }
    }
}
