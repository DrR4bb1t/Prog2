using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    public class TextureManager
    {
        /// <summary>
        /// Creates a specified list.
        /// One list for specified texture type.
        /// </summary>
        public static List<Texture2D> mapTileBacklayer = new List<Texture2D>();
        public static List<Texture2D> mapTileMiddlelayer = new List<Texture2D>();
        public static List<Texture2D> mapTileForelayer = new List<Texture2D>();
        private static Texture2D texture;
        public TextureManager() { }
        /// <summary>
        /// Stores all textures.
        /// List variable needs to be adjust foreach texture type.
        /// </summary>
        public static void StoreTexture()
        {
            #region Backlayer
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileBacklayer.Add(texture);

            //0

            texture = OD.content.Load<Texture2D>("Tiles/castle1");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle2");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle3");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle4");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle5");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle6");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle7");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle8");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle9");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle10");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle11");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castle12");
            mapTileBacklayer.Add(texture);

            //12

            texture = OD.content.Load<Texture2D>("Tiles/door1");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door2");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door3");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door4");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door5");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door6");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door7");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door8");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door9");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door10");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door11");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door12");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door13");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/door14");
            mapTileBacklayer.Add(texture);

            //26

            texture = OD.content.Load<Texture2D>("Tiles/houseWall1");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall2");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall3");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall4");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall5");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall6");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall7");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall8");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall9");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall10");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall11");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall12");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall13");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall14");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall15");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall16");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall17");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall18");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall19");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall20");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall21");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall22");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall23");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall24");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall25");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall26");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall27");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall28");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall29");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/houseWall30");
            mapTileBacklayer.Add(texture);

            //56

            texture = OD.content.Load<Texture2D>("Tiles/cloud_1_LeftBot");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/cloud_1_LeftTop");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/cloud_1_RightBot");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/cloud_1_RightTop");
            mapTileBacklayer.Add(texture);

            //60

            texture = OD.content.Load<Texture2D>("Tiles/castleCenter");
            mapTileBacklayer.Add(texture);
            texture = OD.content.Load<Texture2D>("Tiles/brick_grey");
            mapTileBacklayer.Add(texture);


            #endregion

            #region Middlayer
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileMiddlelayer.Add(texture);

            //0

            texture = OD.content.Load<Texture2D>("Tiles/tree2Bottom");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Top");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/signRight");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/Bush (1)_L");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/Bush (1)_R");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/Bush (2)_L");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/Bush (2)_R");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/fire_lit_L");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/fire_lit_R");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/doorTop");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/doorKnob");
            mapTileMiddlelayer.Add(texture);


            //11

            texture = OD.content.Load<Texture2D>("Tiles/roof1");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/roof2");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/roof3_L");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/roof3_Mid");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/roof3_R");
            mapTileMiddlelayer.Add(texture);

            //16

            texture = OD.content.Load<Texture2D>("Tiles/liquidWater");
            mapTileMiddlelayer.Add(texture);
            #endregion

            #region Forelayer
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileForelayer.Add(texture);

            //0

            texture = OD.content.Load<Texture2D>("Tiles/earth");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/grass");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/windowLowCheckered");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/castleMid");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/boxAlt");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/bridgeLogs2");
            mapTileForelayer.Add(texture);
            #endregion

        }

        public static void LoadTexture()
        {
            texture = OD.content.Load<Texture2D>("spritesheet3");
        }

        public static void Draw(Texture2D texture, SpriteBatch spriteBatch, Vector2 position, int x, int y, int width, int height)
        {
            spriteBatch.Draw(texture, position, new Rectangle(x, y, width, height), Color.White);
        }
    }
}
