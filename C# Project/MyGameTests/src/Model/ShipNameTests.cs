using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    public class ShipNameTests
    {
        [Test]
        public void TestShipNames()
        {
            Assert.AreEqual(0, (int)ShipName.None);
            Assert.AreEqual(1, (int)ShipName.Tug);
            Assert.AreEqual(2, (int)ShipName.Submarine);
            Assert.AreEqual(3, (int)ShipName.Destroyer);
            Assert.AreEqual(4, (int)ShipName.Battleship);
            Assert.AreEqual(5, (int)ShipName.AircraftCarrier);
        }
    }
}
