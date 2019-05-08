using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BattleShipTests
{
    [TestFixture]
    class GameResourcesTests
    {
        [Test]
        public void Game_Font_Test()
        {
            GameResources.LoadResources();
            Assert.IsNotNull(GameResources.GameFont("Courier"));
            GameResources.FreeResources();
        }

        [Test]
        public void Game_Image()
        {
            //GameResources.LoadResources();
            Assert.IsNotNull(GameResources.GameImage("Explosion"));
            //GameResources.FreeResources();
        }

        [Test]
        public void Game_Sound()
        {
            //GameResources.LoadResources();
            Assert.IsNotNull(GameResources.GameSound("Error"));
            //GameResources.FreeResources();
        }

        [Test]
        public void Game_Music()
        {
            //GameResources.LoadResources();
            Assert.IsNull(GameResources.GameMusic("Background"));
            //GameResources.FreeResources();
        }
    }
}
