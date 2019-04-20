using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    public class SeaGridAdapterTests
    {
        private Dictionary<ShipName, Ship> _ships = new Dictionary<ShipName, Ship>();
        private SeaGrid _seaGrid;
        private SeaGridAdapter _adapter;

        [SetUp]
        public void SetUp()
        {
            // initialize ships
            _ships.Clear();
            foreach (ShipName name in Enum.GetValues(typeof(ShipName)))
            {
                if (name != ShipName.None) _ships.Add(name, new Ship(name));
            }

            // initialize seagrid and adapter
            _seaGrid = new SeaGrid(_ships);
            _adapter = new SeaGridAdapter(_seaGrid);
        }

        [Test]
        public void TestSeaGridAdapterViewShip()
        {
            _seaGrid.MoveShip(0, 0, ShipName.Destroyer, Direction.LeftRight);
            Assert.AreEqual(TileView.Sea, _adapter[0, 0]);
        }

        [Test]
        public void TestSeaGridAdapterSize()
        {
            Assert.AreEqual(_seaGrid.Width, _adapter.Width);
            Assert.AreEqual(_seaGrid.Height, _adapter.Height);
        }

        [Test]
        public void TestSeaGridHitTile()
        {
            _seaGrid.MoveShip(0, 0, ShipName.Destroyer, Direction.LeftRight);
            Assert.AreEqual(ResultOfAttack.Hit, _adapter.HitTile(0, 0).Value);
        }
    }
}
