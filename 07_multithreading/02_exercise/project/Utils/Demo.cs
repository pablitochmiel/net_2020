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
            var res = 0;
            for (var i = 0; i < _data.Length; i++)
                res += _data[i];

            return res;
        }

        public int SumForeach()
        {
            // TODO: Use foreach loop to calculate sum
            var res = 0;
            foreach (var t in _data)
                res += t;
            
            return res;
        }

        public int SumLinq()
        {
            // TODO: Use for LINQ to calculate sum

            return _data.Sum();
        }

        private delegate void ThreadAction(int start, int stop);

        private void RunStandaloneThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' threads and execute 'action' in every one with appropriate range of data
            var t = new Thread[count];
            for (var i = 0; i < count; i++)
            {
                var i1 = i;
                t[i] = new Thread(() => action(i1*_data.Length / count, (i1+1)*_data.Length / count));
            }

            foreach (var temp in t)
            {
                temp.Start();
            } 
            foreach (var temp in t)
            {
                temp.Join();
            }
        }

        public int SumThreadsInterlocked(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Ue lambda to poss 'action' to 'RunStandaloneThreads'
            var sum = 0;
            RunStandaloneThreads(count, (start, stop) =>
            {
                for (var i = start; i < stop; i++)
                    Interlocked.Add(ref sum, _data[i]);                                                                                                                                                                            
            });                                                        

            return sum;
        }


        public int SumThreads(int count)
        {
            // TODO: Use 'Interlocked.Add' to calculate total sum
            // TODO: Use partial sum in threads to avoid excessive use of 'Interlocked.Add'
            // TODO: Use 'RunStandaloneThreads' to run threads
            // TODO: Ue lambda to poss 'action' to 'RunStandaloneThreads'
            var sum = 0;
            RunStandaloneThreads(count, (start, stop) =>
            {
                var s = 0;
                for (var i = start; i < stop; i++)
                {
                    s += _data[i];
                }
                Interlocked.Add(ref sum, s);
            });

            return sum;
        }

        private void RunPoolThreads(int count, ThreadAction action)
        {
            // TODO: Run 'count' pool threads and execute 'action' in every one with appropriate range of data
            // TODO: Use 'ManualResetEvent' to synchronize operations
            var events = new List<ManualResetEvent>();
            for (int i = 0; i < count; i++)
            {
                var i1 = i;
                var resetEvent=new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(_ => { action(i1*_data.Length / count, (i1+1)*_data.Length / count); resetEvent.Set(); });
                events.Add(resetEvent);
            }
            WaitHandle.WaitAll(events.ToArray<WaitHandle>());
        }

        public int SumPoolThreads(int count)
        {
            // TODO: Use 'RunPoolThreads' to run threads
            // TODO: Use 'Interlocked.Add' to aggregate data
            // TODO: Ue lambda to poss 'action' to 'RunPoolThreads'
            // var events = new List<ManualResetEvent>();
            // for (int i = 0; i < 10; i++) {
            //     var resetEvent = new ManualResetEvent(false);
            //     ThreadPool.QueueUserWorkItem(_ => { ThreadAction(); resetEvent.Set(); });
            //     events.Add(resetEvent);
            // }
            // WaitHandle.WaitAll(events.ToArray<WaitHandle>());
            
            var sum = 0;
            RunPoolThreads(count,(start, stop)=>
            {
                var s = 0;
                for (var i = start; i < stop; i++)
                {
                    s += _data[i];
                }
                Interlocked.Add(ref sum, s);
            });

            return sum;
        }

        public int SumTpl()
        {
            // TODO: Use 'Parallel.For' to calculate sum
            // TODO: Ue lambdas to poss operations
            var sum = 0;
            Parallel.For(0, _data.Length, () => 0, (j, loop, subtotal) =>
                {
                    subtotal += _data[j];
                    return subtotal;
                },
                (x) => Interlocked.Add(ref sum, x)
            );
            return  sum;
        }
    }
}