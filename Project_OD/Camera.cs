using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OD
{
    class Camera
    {
        /// <summary>
        /// Position of camera.
        /// </summary>
        private Vector2 position;
        private Matrix viewMatrix;

        /// <summary>
        /// Cameramatrix
        /// </summary>
        public Matrix ViewMatrix { get => viewMatrix; }
        /// <summary>
        /// Width and height of the shown screen.
        /// </summary>
        public int ScreenWidth { get => GraphicsDeviceManager.DefaultBackBufferWidth; }
        public int ScreenHeight { get => GraphicsDeviceManager.DefaultBackBufferHeight; }

        /// <summary>
        /// Updates the camera.
        /// </summary>
        /// <param name="playerPos">position of the camera is set nby player's position.</param>
        public void Update(Vector2 playerPos)
        {
            position.X = playerPos.X - (ScreenWidth / 2);
            position.Y = playerPos.Y - (ScreenHeight * 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X > 1600)
            {
                position.X = 1600;
            }

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

    }
}
