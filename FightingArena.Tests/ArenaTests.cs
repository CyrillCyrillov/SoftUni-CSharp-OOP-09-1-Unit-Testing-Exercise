using NUnit.Framework;

namespace FightingArena
{
    
    using System;
    using System.Collections.Generic;

    public class ArenaTests
    {
        Arena testArena;

        [SetUp]
        public void Setup()
        {
            testArena = new Arena();
        }

        [Test]
        public void Corect_Set_Empty_Arena_Count_Is_0()
        {
            Assert.AreEqual(testArena.Count, 0);
        }

        [Test]
        public void Wehn_Enroll_Count_Must_Increases()
        {
            Warrior first = new Warrior("First", 50, 50);
            testArena.Enroll(first);
            Assert.AreEqual(testArena.Count, 1);
        }

        [Test]
        public void Wehn_Enroll_Same_Name_Throw_And_Message()
        {
            Warrior first = new Warrior("First", 50, 50);
            Warrior second = new Warrior("First", 1, 1);
            testArena.Enroll(first);
            
            

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Enroll(second);
            });

            Assert.AreEqual(ex.Message, "Warrior is already enrolled for the fights!");
           
        }


    }
}