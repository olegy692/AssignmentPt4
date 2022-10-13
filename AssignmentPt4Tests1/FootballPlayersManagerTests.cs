using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssignmentPt4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1_Prog_n_tech;

namespace AssignmentPt4.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var manager = new FootballPlayersManager();
            List<FootballPlayer> testList = manager.GetAll();

            Assert.AreEqual(testList.Count, 4);
            Assert.IsNotNull(testList);
        }

       

        [TestMethod()]
        public void AddTest()
        {
            FootballPlayer player1 = new FootballPlayer { Name = "Bob", Age = 25, ShirtNumber = 33 };

            var manager = new FootballPlayersManager();
            manager.Add(player1);
            Assert.AreEqual(player1.Id, manager.GetById(5).Id);
            Assert.AreEqual(player1.ToString(), manager.GetById(5).ToString());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var manager = new FootballPlayersManager();
            var count1 = manager.GetAll().Count();
            manager.Delete(1);
            var count2 = manager.GetAll().Count();
            Assert.IsTrue(count2 == count1 - 1);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var manager = new FootballPlayersManager();

            FootballPlayer player1 = manager.GetById(2);
            var player1Str = player1.Name;

            FootballPlayer updatePlayer = new FootballPlayer() { Id = 2, Name = "boris", Age = 25, ShirtNumber = 35 };

            FootballPlayer player2 = manager.Update(2, updatePlayer);
            FootballPlayer play2 = manager.GetById(2);
            var player2str = play2.Name;

            Assert.IsTrue(player2str == "boris");
        }
    }
}