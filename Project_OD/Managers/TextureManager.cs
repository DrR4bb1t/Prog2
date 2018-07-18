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
        public static List<Texture2D> tile = new List<Texture2D>();
        private static Texture2D texture;
        public TextureManager() { }
        public static void StoreTexture()
        {
            texture = OD.content.Load<Texture2D>("Tiles/empty");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/earth");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/grass");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/mushroomRed");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Bottom");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/tree2Top");
            tile.Add(texture);

            texture = OD.content.Load<Texture2D>("Tiles/signRight");
            tile.Add(texture);
        }
    }
}
