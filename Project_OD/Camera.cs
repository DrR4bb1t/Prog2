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
        private int maxCamWidth;
        private float camStartPoint = 1.3f;
        /// <summary>
        /// Cameramatrix
        /// </summary>
        public Matrix ViewMatrix { get => viewMatrix; }
        /// <summary>
        /// Width and height of the shown screen.
        /// </summary>
        public int ScreenWidth { get => GraphicsDeviceManager.DefaultBackBufferWidth; }
        public int ScreenHeight { get => GraphicsDeviceManager.DefaultBackBufferHeight; }

        public Camera(int viewportWidth)
        {
            ViewportCalc(viewportWidth);
        }

        /// <summary>
        /// Updates the camera.
        /// </summary>
        /// <param name="playerPos">position of the camera is set nby player's position.</param>
        public void Update(Vector2 playerPos)
        {
            position.X = playerPos.X - (ScreenWidth / camStartPoint);
            position.Y = playerPos.Y - (ScreenHeight * 2);

            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            if (position.X > maxCamWidth)
            {
                position.X = maxCamWidth;
            }

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        public void ViewportCalc(int viewportWidth)
        {
            maxCamWidth = viewportWidth;
        }

    }
}
