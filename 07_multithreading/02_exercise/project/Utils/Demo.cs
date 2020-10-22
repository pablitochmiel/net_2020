using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class Demo
    {
        private readonly int[] _data;

        public Demo(int[] data)
        {
            _data = data;
        }

        public int Sum()
        {
            // TODO: Use for loop to calculate sum

            return 0;
        }

        public int SumForeach()
        {
            // TODO: Use foreach loop to calculate sum

            return 0;
        }

        public int SumLinq()
        {
            // TODO: Use for LINQ to calculate sum

            return 0;
        }

        private delegate void ThreadAction(int start, int stop);

        private void RunStandaloneThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' threads and execute 'action' in every one with appropriate range of data
        }

        public int SumThreadsInterlocked(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Ue lambda to poss 'action' to 'RunStandaloneThreads'

            return 0;
        }


        public int SumThreads(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use partial sum in threads to avoid excessive use of 'Interlocked.Add'
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Ue lambda to poss 'action' to 'RunStandaloneThreads'

            return 0;
        }

        private void RunPoolThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' pool threads and execute 'action' in every one with appropriate range of data
            // TODO: Use 'ManualResetEvent' to synchronize operations
        }

        public int SumPoolThreads(int count)
        {
            // TODO: Use 'RunPoolThreads' to run threads
            // TODO: Use 'Interlocked.Add' to aggregate data
            // TODO: Ue lambda to poss 'action' to 'RunPoolThreads'

            return 0;
        }

        public int SumTpl()
        {
            // TODO: Use 'Parallel.For' to calculate sum
            // TODO: Ue lambdas to poss operations

            return 0;
        }
    }
}