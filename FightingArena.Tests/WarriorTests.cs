using NUnit.Framework;
using System;

namespace FightingArena
{
    

    public class WarriorTests
    {
        Warrior testWarrior;
        string testName = "Testy";
        int testDamage = 1;
        int testHp = 1;


        [SetUp]
        public void Setup()
        {
            testWarrior = new Warrior(testName, testDamage, testHp);
        }

        

        [Test]
        public void Warrior_Constructor_If_Name_Is_Empty_Must_Thwrow_And_Message()
        {
            string emptyName = "";

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior emptyNameWarrior = new Warrior(emptyName, testDamage, testHp);
            });

            Assert.AreEqual(ex.Message, "Name should not be empty or whitespace!");
            
        }

        [Test]
        public void Warrior_Constructor_If_Damage_Is_Not_Positive_Must_Thwrow_And_Message()
        {
            int negativDamage = -1;

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior emptyNameWarrior = new Warrior(testName, negativDamage, testHp);
            });

            Assert.AreEqual(ex.Message, "Damage value should be positive!");

        }

        [Test]
        public void Warrior_Constructor_If_HP_Is_Not_Positive_Must_Thwrow_And_Message()
        {
            int negativHp = -1;

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior emptyNameWarrior = new Warrior(testName, testDamage, negativHp);
            });

            Assert.AreEqual(ex.Message, "HP should not be negative!");

        }

        [Test]
        public void Constructor_Set_Corectly()
        {
            Assert.AreEqual(testWarrior.Name, testName);
            Assert.AreEqual(testWarrior.Damage, testDamage);
            Assert.AreEqual(testWarrior.HP, testHp);
        }

        [Test]
        public void Atack_With_Low_HP_Must_Thwrow_And_Message()
        {
            Warrior opponent = new Warrior("Opponent", 50, 50);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testWarrior.Attack(opponent);
            });

            Assert.AreEqual(ex.Message, "Your HP is too low in order to attack other warriors!");

        }

        [Test]
        public void Atack_Opponent_With_Low_HP_Must_Thwrow_And_Message()
        {
            int MIN_ATTACK_HP = 30;
            Warrior opponent = new Warrior("Opponent", 50, MIN_ATTACK_HP);
            Warrior strongerWarrior = new Warrior("Opponent", 50, 50);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                strongerWarrior.Attack(opponent);
            });

            Assert.AreEqual(ex.Message, $"Enemy HP must be greater than { MIN_ATTACK_HP} in order to attack him!");

        }

        [Test]
        public void Atack_Stronger_Opponent_Thwrow_And_Message()
        {
            
            Warrior opponent = new Warrior("Opponent", 50, 50);
            Warrior ordinaryWarrior = new Warrior("Opponent", 31, 31);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                ordinaryWarrior.Attack(opponent);
            });

            Assert.AreEqual(ex.Message, $"You are trying to attack too strong enemy");
        }

        [Test]
        public void Corect_Finish_Fight()
        {

            Warrior opponent = new Warrior("Opponent", 40, 40);
            Warrior ordinaryWarrior = new Warrior("Opponent", 50, 50);

            ordinaryWarrior.Attack(opponent);

            Assert.AreEqual(ordinaryWarrior.HP, 10);
            Assert.AreEqual(ordinaryWarrior.Damage, 50);
            Assert.AreEqual(opponent.HP, 0);
            Assert.AreEqual(opponent.Damage, 40);
        }

        [Test]
        public void Corect_Finish_Fight_Two()
        {

            Warrior opponent = new Warrior("Opponent", 40, 40);
            Warrior ordinaryWarrior = new Warrior("Opponent", 35, 50);

            ordinaryWarrior.Attack(opponent);

            Assert.AreEqual(ordinaryWarrior.HP, 10);
            Assert.AreEqual(ordinaryWarrior.Damage, 35);
            Assert.AreEqual(opponent.HP, 5);
            Assert.AreEqual(opponent.Damage, 40);
        }


    }
}
