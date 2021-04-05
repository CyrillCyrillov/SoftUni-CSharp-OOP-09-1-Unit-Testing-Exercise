using NUnit.Framework;

namespace Database
{
    public class DatabaseTests
    {
        Database testDatabase;

        [SetUp]
        public void Setup()
        {
            Database testDatabase = new Database(new int[] { 1 });

        }

        [Test]
        public void Corectly_Set()
        {
            /*
            
            private int[] data;

            private int count;

            public Database(params int[] data)
            {
                this.data = new int[16];

                for (int i = 0; i < data.Length; i++)
                {
                    this.Add(data[i]);
                }

                this.count = data.Length;
            }

            public int Count
            {
                get { return count; }
            }


            */

            Assert.AreEqual(testDatabase.Count, 16);
        }
    }
}