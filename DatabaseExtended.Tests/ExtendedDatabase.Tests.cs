
using NUnit.Framework;
//using ExtendedDatabase;
using System;

namespace ExtendedDB
{
    public class ExtendedDatabaseTests
    {
        const int capacity = 16;
        Person testPerson;
        long iD = 1111111111;
        string userName = "Kiril";
        ExtendedDatabase testEextendedDatabase;
        
        [SetUp]
        public void Setup()
        {
            testPerson = new Person(iD, userName);
            testEextendedDatabase = new ExtendedDatabase(testPerson);
        }

        [Test]
        public void Constructor_Set_Corectly_ID()
        {
            Assert.AreEqual(iD, testPerson.Id);
        }
        
        [Test]
        public void Constructor_Set_Corectly_userName()
        {
            Assert.AreEqual(userName, testPerson.UserName);
        }

        [Test]
        public void Empty_Base_Have_Count_Zero()
        {
            ExtendedDatabase emptyEextendedDatabase = new ExtendedDatabase();
            Assert.AreEqual(emptyEextendedDatabase.Count, 0);
        }

        [Test]
        public void NoEmpty_Base_Have_Count_No_Zero()
        {
            //ExtendedDatabase.ExtendedDatabase testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);

            Assert.IsTrue(testEextendedDatabase.Count == 1);
        }

        [Test]
        public void When_Add_Person_With_Same_Name_Meassage()
        {
            //ExtendedDatabase.ExtendedDatabase testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            //testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            Person personSameName = new Person(2222222222, "Kiril");

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
                { 
                    testEextendedDatabase.Add(personSameName);
                });

            Assert.AreEqual(ex.Message, "There is already user with this username!");
        }

        [Test]
        public void When_Add_Person_With_Same_ID_Meassage()
        {
            //ExtendedDatabase.ExtendedDatabase testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            //testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            Person personSameName = new Person(1111111111, "Ivan");

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testEextendedDatabase.Add(personSameName);
            });

            Assert.AreEqual(ex.Message, "There is already user with this Id!");
        }

        [Test]
        public void When_Add_Person_With_Same_ID_And_Same_Name_Meassage()
        {
            //ExtendedDatabase.ExtendedDatabase testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            Person personSameName = new Person(1111111111, "Kiril");

            InvalidOperationException exTwo = Assert.Throws<InvalidOperationException>(() =>
            {
                testEextendedDatabase.Add(personSameName);
            });

            Assert.AreEqual(exTwo.Message, "There is already user with this username!");
        }

        [Test]
        public void Wen_Add_More_Then_Capacity_Message()
        {
            //ExtendedDatabase.ExtendedDatabase testEextendedDatabase = new ExtendedDatabase.ExtendedDatabase(testPerson);
            for (int i = 1; i <= capacity - 1; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            Person oneMore = new Person(9999999999, "TheSeventeenth");

            InvalidOperationException exTwo = Assert.Throws<InvalidOperationException>(() =>
            {
                testEextendedDatabase.Add(oneMore);
            });

            Assert.AreEqual(exTwo.Message, "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void When_Remove_Count_Decreases()
        {
            
            for (int i = 1; i <= 5; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            int countBeforeRemove = testEextendedDatabase.Count;

            testEextendedDatabase.Remove();

            Assert.AreEqual(testEextendedDatabase.Count, countBeforeRemove - 1);

        }

        [Test]
        public void FindByUsername()
        {

            for (int i = 1; i <= 6; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            Person findPersonByUserName = testEextendedDatabase.FindByUsername("Kiril4");

            Assert.AreEqual(findPersonByUserName.Id, 1111111115);
            Assert.AreEqual(findPersonByUserName.UserName, "Kiril4");

        }

        [Test]
        public void FindByUsername_When_No_Username_Massege()
        {

            for (int i = 1; i <= 10; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                Person findPersonByID = testEextendedDatabase.FindByUsername("Zzzzzz");
            });

            Assert.AreEqual(ex.Message, "No user is present by this username!");

        }
        
        [Test]
        public void FindByUsername_When_Nul_Massege()
        {
            for (int i = 1; i <= 9; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            Person findPersonByID;
            Assert.That(() => findPersonByID = testEextendedDatabase.FindByUsername(""), Throws.ArgumentNullException);
            
        }
        

        [Test]
        public void FindByID()
        {

            for (int i = 1; i <= 8; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            Person findPersonByID = testEextendedDatabase.FindById(1111111118);

            Assert.AreEqual(findPersonByID.Id, 1111111118);
            Assert.AreEqual(findPersonByID.UserName, "Kiril7");

        }

        [Test]
        public void FindByID_When_No_ID_Massege()
        {

            for (int i = 1; i <= 4; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);


                testEextendedDatabase.Add(nextPerson);
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                Person findPersonByID = testEextendedDatabase.FindById(9999999999);
            });

            Assert.AreEqual(ex.Message, "No user is present by this ID!");
        }

        [Test]
        public void FindByID_When_Invalid_ID_Message()
        {
            for (int i = 1; i <= 12; i++)
            {
                long nextID = 1111111111 + i;
                string nextName = "Kiril" + i.ToString();

                Person nextPerson = new Person(nextID, nextName);

                testEextendedDatabase.Add(nextPerson);
            }

            Person findPersonByID;
            Assert.Throws<ArgumentOutOfRangeException>(() => findPersonByID = testEextendedDatabase.FindById(-11111));
            
        
        }
        
    }
}

