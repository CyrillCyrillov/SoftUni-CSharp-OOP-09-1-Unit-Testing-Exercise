using NUnit.Framework;
using System;
using System.Linq;


namespace Test
{
    public class DatabaseTests
    {

        Database.Database startDatabase; // For Judge -> Replace All "Database.Database" with "Database"


        [SetUp]
        public void Setup()
        {
            startDatabase = new Database.Database();
        }

        [Test]
        public void When_Add_More_Then_Capacity_Must_Throw_Message()
        {

            for (int i = 1; i <= 16; i++)
            {
                startDatabase.Add(i);
            }
            
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                startDatabase.Add(17);
            });

            Assert.AreEqual(ex.Message, "Array's capacity must be exactly 16 integers!");

            /*
             
            Assert.Throws<InvalidOperationException>(() => startDatabase.Add(17));

            */
        }

        [Test]
        public void Wnen_Add_Corectly_Count_Must_Increases()
        {
            int startElementsNumber = 5;

            for (int i = 1; i <= startElementsNumber; i++)
            {
                startDatabase.Add(i);
            }

            startDatabase.Add(6);

            Assert.AreEqual(startElementsNumber + 1, startDatabase.Count );

        }
        [Test]
        public void Add_Element_At_Last_Position()
        {
            int startElementsNumber = 5;

            for (int i = 1; i <= startElementsNumber; i++)
            {
                startDatabase.Add(i);
            }

            int newElement = 789;
            startDatabase.Add(newElement);
            int[] dataBaseElements = startDatabase.Fetch();

            Assert.AreEqual(dataBaseElements[startElementsNumber], newElement);

        }

        [Test]
        public void When_Revome_From_Empty_Base_Must_Throw_Message()
        {

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                startDatabase.Remove();
            });

            Assert.AreEqual(ex.Message, "The collection is empty!");

            /*
             
            Assert.Throws<InvalidOperationException>(() => startDatabase.Remove());

            */
        }

        [Test]
        public void Wnen_Remove_Corectly_Count_Must_Decreases()
        {
            int startElementsNumber = 12;

            for (int i = 1; i <= startElementsNumber; i++)
            {
                startDatabase.Add(i);
            }

            startDatabase.Remove();

            Assert.AreEqual(startDatabase.Count, startElementsNumber - 1);
        }

        [Test]
        public void Remove_From_Last_Position()
        {
            int startElementsNumber = 7;

            for (int i = 1; i <= startElementsNumber; i++)
            {
                startDatabase.Add(i);
            }

            startDatabase.Remove();

            int[] dataBaseElements = startDatabase.Fetch();
            Assert.AreEqual(dataBaseElements.Length, startElementsNumber - 1);

            bool isMissingLastElement = true;

            for (int i = 1; i <= startElementsNumber - 2; i++)
            {
                if(i + 1 != dataBaseElements[i])
                {
                    isMissingLastElement = false;
                }
            }

            Assert.IsTrue(isMissingLastElement);
        }

        [Test]
        public void Fetch_Retunrs_Copy_Of_Database()
        {
            int startElementsNumber = 7;
            int[] startElements = new int[startElementsNumber];

            for (int i = 0; i <= startElementsNumber - 1; i++)
            {
                startElements[i] = i;
            }

            startDatabase = new Database.Database(startElements);

            startDatabase.Remove();
            startDatabase.Remove();

            int[] dataBaseCopy = startDatabase.Fetch();

            int newControlElememnt = 45;
            startDatabase.Add(newControlElememnt);

            Assert.IsFalse(dataBaseCopy.Contains(newControlElememnt));


        }
        



    }
}