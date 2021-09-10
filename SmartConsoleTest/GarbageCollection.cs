using System.Diagnostics;
using System;
using Xunit;

namespace SmartConsoleTest
{
    //https://github.com/maartenba/memory-demos/tree/master/TripDownMemoryLane/TripDownMemoryLane
    public class GarbageCollection : IDisposable
    {
        public GarbageCollection()
        {
            Debug.WriteLine("Object created");

        }
        public void Dispose()
        {
            Debug.WriteLine("u r out of scope");
            //call disposble pattern for cleaning managed or unmanaged memory 
            GC.SuppressFinalize(this);// it ll remove current obj for finalize queue and destroy it
        }
        ~GarbageCollection()
        {
            Debug.WriteLine("Object ll destroy buy gc or call GC.Collect() for immediate clearance");
        }
    }
    public class GarbageCollectionTest
    {
        [Fact]
        public void IdisposableTest()
        {
            GarbageCollection o = new GarbageCollection();

            using (o)
            {

            }
        }

        [Fact]
        public void CgCollectTest()
        {
            GarbageCollection o = new GarbageCollection();
            o = null;
            GC.Collect();
        }

    }
}
