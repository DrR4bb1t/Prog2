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
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileBacklayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/mushroomRed");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Bottom");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Top");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/signRight");
            mapTileMiddlelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/earth");
            mapTileForelayer.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/grass");
            mapTileForelayer.Add(texture);

   
        }
    }
}
