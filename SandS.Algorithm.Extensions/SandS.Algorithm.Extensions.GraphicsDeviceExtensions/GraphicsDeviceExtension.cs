using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SandS.Algorithm.Extensions.GraphicsDeviceExtension
{
    public static class GraphicsDeviceExtensions
    {
        /// <summary>
        /// Generate rectangle texture
        /// </summary>
        /// <param name="device">Game graphic device</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Texture2D Generate(this GraphicsDevice device, int width, int height, Color color)
        {
            Texture2D texture = new Texture2D(device, width, height);
            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = color;
            }

            texture.SetData(data);

            return texture;
        }

        /// <summary>
        /// Generate rectangle texture with borders
        /// </summary>
        /// <param name="device">Game graphic device</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="textureColor"></param>
        /// <param name="borderThick"></param>
        /// <param name="borderColor"></param>
        /// <returns></returns>
        public static Texture2D Generate(this GraphicsDevice device, int width, int height, Color textureColor, int borderThick, Color borderColor)
        {
            Texture2D texture = new Texture2D(device, width, height);

            Color[] data = new Color[width * height];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = textureColor;
            }

            // painting vertical borders
            for (int i = 0; i < data.Length; i = i + width)
            {
                for (int j = 0; j < borderThick; j++)
                {
                    data[i + j] = borderColor;
                }

                if (i > 1)
                {
                    for (int j = 0; j < borderThick; j++)
                    {
                        data[i - 1 - j] = borderColor;
                    }
                }
            }

            // painting horizontal borders
            for (int j = 0; j < borderThick; j++)
            {
                int bias = j * width;

                for (int i = 0; i < height; i++)
                {
                    data[i + bias] = borderColor;
                    data[data.Length - i - 1 - j * width] = borderColor;
                }
            }

            //set the color
            texture.SetData(data);

            return texture;
        }
    }
}