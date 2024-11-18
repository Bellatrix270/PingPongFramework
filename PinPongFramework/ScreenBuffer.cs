using System;

namespace PinPongFramework
{
    public class ScreenBuffer
    {
        private char[,] currentBuffer;
        private char[,] previousBuffer;
        private int width, height;

        public ScreenBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            currentBuffer = new char[width, height];
            previousBuffer = new char[width, height];
        }

        public void SetPixel(int x, int y, char c)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
            {
                currentBuffer[x, y] = c;
            }
        }

        public void Clear()
        {
            Array.Clear(currentBuffer, 0, currentBuffer.Length);
        }

        public void Render()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (currentBuffer[x, y] != previousBuffer[x, y])
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(currentBuffer[x, y] == '\0' ? ' ' : currentBuffer[x, y]);
                        previousBuffer[x, y] = currentBuffer[x, y];
                    }
                }
            }
        }
    }
}