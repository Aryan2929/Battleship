using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    public class SeaGridTests
    {
        private Dictionary<ShipName, Ship> _ships = new Dictionary<ShipName, Ship>();
        private SeaGrid _seaGrid;

        [SetUp]
        public void SetUp()
        {
            // initialize ships
            _ships.Clear();
            foreach (ShipName name in Enum.GetValues(typeof(ShipName)))
            {
                if (name != ShipName.None) _ships.Add(name, new Ship(name));
            }

            // initialize seagrid
            _seaGrid = new SeaGrid(_ships);
        }

        [Test]
        public void TestSeaGridInitializesTiles()
        {
            for (int y=0; y<_seaGrid.Height; y++)
            {
                for (int x=0; x<_seaGrid.Width; x++)
                {
                    Assert.AreEqual(_seaGrid[x, y], TileView.Sea);
                }
            }
        }
    }
}
