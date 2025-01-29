using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ProgII_GameMonogame_JuliaC01272025
{
    internal class Player : GameEntity
    {
        private float gravity = 12.0f;
        private float gravityDownSpeed = 14.0f;
        private float maxGravity = 12.0f;
        private float flapForce = -40.0f;
        private bool isJumpPressed = false;

        private GameManager gameManager;

        public Player(GameManager game, Vector2 initialPosition) : base(game, initialPosition)
        {
            gameManager = game;
            movementDirection = new Vector2(0,gravityDownSpeed);
            sprite = gameManager.Content.Load<Texture2D>("tile_0126");
        }
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            //float deltaTime = gameTime.ElapsedGameTime.Milliseconds * 0.01f;
            KeyboardState kstate = Keyboard.GetState();
            
            //RECTANGLE (PIPE COLLISION)
            Rectangle rectangleA = new Rectangle(0, 0, 50, 50);
            Rectangle rectangleB = new Rectangle(51, 25, 50, 50);

            Debug.WriteLine(rectangleA.Intersects(rectangleB));
           
            if (kstate.IsKeyDown(Keys.Space))
            {
                if (!isJumpPressed) {
                    // up
                    gravity = flapForce;
                    isJumpPressed = true;
                }
            }
            else {
                isJumpPressed = false;
            }
            position.Y += gravity * deltaTime;
            
            if (gravity < maxGravity)
            {
                gravity += deltaTime * gravityDownSpeed;
            }

            int heightofWindow = gameManager.Graphics.PreferredBackBufferHeight;

            Update(deltaTime);
        }
    }
}
// if gamemanager.iscolliding (this) --- gameover = true
