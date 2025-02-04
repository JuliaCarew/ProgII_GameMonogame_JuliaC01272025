using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using System.Drawing;

namespace ProgII_GameMonogame_JuliaC01272025
{
    internal class GameEntity
    {
        protected Texture2D sprite;
        protected Rectangle collider;
        protected Vector2 position;
        protected float speed;
        protected Vector2 movementDirection;

        private GameManager gameManager;
        public GameEntity(GameManager game, Vector2 initialPosition) 
        {
            gameManager = game;
            movementDirection = new Vector2();
            //sprite = gameManager.Content.Load<Texture2D>("tile_0126");
        }

        public virtual void Update(float deltaTime)
        {
            position = movementDirection * deltaTime;
            collider = new Rectangle(
                (int)(position.X - (sprite.Width/2)), 
                (int)position.Y - (sprite.Height / 2), 
                sprite.Height, sprite.Width
            );
            //float deltaTime = spriteBatch.ElapsedGameTime.Milliseconds * 0.01f;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Draw(sprite, new Rectangle(
                (int)position.X, (int)position.Y,
                sprite.Width, sprite.Height), Color.White
            );
            
        }
    }
}
/*
 * gameManager.SpriteBatch.Begin();

            gameManager.SpriteBatch.Draw(sprite, new Rectangle(
                (int)position.X, (int)position.Y,
                sprite.Width, sprite.Height), Color.White
            );
            gameManager.SpriteBatch.End();

            Draw(spriteBatch);
 */