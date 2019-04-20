using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    public class TileTests
    {
        private const int _WIDTH = 10;
        private const int _HEIGHT = 10;
        private Tile[,] _tiles = new Tile[_WIDTH, _HEIGHT];

        [SetUp]
        public void SetUp()
        {
            for (int i = 0; i <= _WIDTH - 1; i++)
            {
                for (int j = 0; j <= _HEIGHT - 1; j++)
                {
                    _tiles[i, j] = new Tile(i, j, null);
                }
            }
        }

        [Test]
        public void TestTileRowColumn()
        {
            for (int x = 0; x <= _WIDTH - 1; x++)
            {
                for (int y = 0; y <= _HEIGHT - 1; y++)
                {
                    Assert.AreEqual(x, _tiles[x, y].Row);
                    Assert.AreEqual(y, _tiles[x, y].Column);
                }
            }
        }

        [Test]
        public void TestTileAddShip()
        {
            Ship tug = new Ship(ShipName.Tug);
            _tiles[0, 0].Ship = tug;
            Assert.AreEqual(tug, _tiles[0, 0].Ship);
        }

        [Test]
        public void TestTileRemoveShip()
        {
            Ship tug = new Ship(ShipName.Tug);
            _tiles[0, 0].Ship = tug;
            Assert.AreEqual(tug, _tiles[0, 0].Ship);
        }

        [Test]
        public void TestTileViewShip()
        {
            Ship tug = new Ship(ShipName.Tug);
            _tiles[0, 0].Ship = tug;
            Assert.AreEqual(TileView.Ship, _tiles[0, 0].View);
        }

        [Test]
        public void TestTileViewSea()
        {
            Assert.AreEqual(TileView.Sea, _tiles[0, 0].View);
        }
    }
}