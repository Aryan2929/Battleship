using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    public class ShipTests
    {
        private Dictionary<ShipName, Ship> _ships = new Dictionary<ShipName, Ship>();

        [SetUp]
        public void SetUp()
        {
            // initialize ships
            _ships.Clear();
            foreach (ShipName name in Enum.GetValues(typeof(ShipName)))
            {
                if (name != ShipName.None) _ships.Add(name, new Ship(name));
            }
        }

        [Test]
        public void TestShipNames()
        {
            Assert.AreEqual("Tug", _ships[ShipName.Tug].Name);
            Assert.AreEqual("Submarine", _ships[ShipName.Submarine].Name);
            Assert.AreEqual("Destroyer", _ships[ShipName.Destroyer].Name);
            Assert.AreEqual("Battleship", _ships[ShipName.Battleship].Name);
            Assert.AreEqual("Aircraft Carrier", _ships[ShipName.AircraftCarrier].Name);
        }

        [Test]
        public void TestShipSizes()
        {
            foreach(KeyValuePair<ShipName, Ship> entry in _ships)
            {
                ShipName name = entry.Key;
                Ship ship = entry.Value;
                Assert.AreEqual((int)name, ship.Size);
            }
        }

        [Test]
        public void TestShipDeployed()
        {
            int offset = 0;
            SeaGrid seaGrid = new SeaGrid(_ships);
            foreach (KeyValuePair<ShipName, Ship> entry in _ships)
            {
                ShipName name = entry.Key;
                Ship ship = entry.Value;
                seaGrid.MoveShip(0, offset++, name, Direction.UpDown);
                Assert.IsTrue(ship.IsDeployed);
            }
        }

        [Test]
        public void TestShipIsDestroyed()
        {
            foreach (KeyValuePair<ShipName, Ship> entry in _ships)
            {
                Ship ship = entry.Value;
                
                // put ship near death
                for (int i = 0; i < ship.Size-1; i++) ship.Hit();

                Assert.IsFalse(ship.IsDestroyed);
                ship.Hit();
                Assert.IsTrue(ship.IsDestroyed);
            }
        }
    }
}
