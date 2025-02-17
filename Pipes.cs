using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace ProgII_GameMonogame_JuliaC01272025
{
    internal class Pipes : GameEntity
    {
        private GameManager gameManager;

        private List<Vector2> pipePosition;
        private Texture2D pipeTexture;
        // Pipe Movement
        private float speed = 200f;
        private int screenWidth;
        private Random random = new Random();
        private int gapSize = 150;

        public Pipes(GameManager game, int screenWidth) : base(game, Vector2.Zero)
        {
            gameManager = game;
            this.screenWidth = screenWidth;
            pipeTexture = gameManager.Content.Load<Texture2D>("tile_0095");
            pipePosition = new List<Vector2>();

            SpawnPipe();
        }
        public override void Update(float deltaTime)
        {
            // set pipe positions
            for (int i = 0; i < pipePosition.Count; i++)
            {
                pipePosition[i] = new Vector2
                    (pipePosition[i].X - speed * deltaTime, pipePosition[i].Y);
            }
            // remove off-screen pipes
            pipePosition.RemoveAll(pipe => pipe.X + pipeTexture.Width < 0);
            // spawn new pipes 
            if (pipePosition.Count == 0
                || pipePosition[pipePosition.Count - 1].X < screenWidth - 300)
            {
                SpawnPipe();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < pipePosition.Count; i += 2)
            {
                // get both positions
                Vector2 topPipePos = pipePosition[i];
                Vector2 bottomPipePos = pipePosition[i + 1];

                // draw TOP
                spriteBatch.Draw(
                    pipeTexture, topPipePos, null, Color.White, 0f,
                    Vector2.Zero, 1f, SpriteEffects.FlipVertically, 0f
                );
                // draw BOTTOM
                spriteBatch.Draw(pipeTexture, bottomPipePos, Color.White);
            }
        }

        private void SpawnPipe()
        {
            int minY = 100;
            int maxY = 300;
            int gapSize = 150;
            int yPos = random.Next(minY, maxY); // random Y position to spawn
            // spawn TOP
            pipePosition.Add(new Vector2(screenWidth, yPos - pipeTexture.Height));
            // spawn BOTTOM
            pipePosition.Add(new Vector2(screenWidth, yPos + gapSize));
        }
    }
}
