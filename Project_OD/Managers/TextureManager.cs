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
        public static List<Texture2D> mapTile = new List<Texture2D>();
        private static Texture2D texture;
        public TextureManager() { }
        /// <summary>
        /// Stores all textures.
        /// List variable needs to be adjust foreach texture type.
        /// </summary>
        public static void StoreTexture()
        {
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/earth");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/grass");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/mushroomRed");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Bottom");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Top");
            mapTile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/signRight");
            mapTile.Add(texture);
        }
    }
}
