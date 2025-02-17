using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProgII_GameMonogame_JuliaC01272025
{
    internal class Player : GameEntity
    {
        private float gravity = 90.0f;
        private float gravityDownSpeed = 150.0f;
        private float maxGravity = 90.0f;
        private float flapForce = -100.0f;
        private float velocityY = 0.0f;
        private bool isJumpPressed = false;
        private GameManager gameManager;

        public Player(GameManager game, Vector2 initialPosition) : base(game, initialPosition)
        {
            gameManager = game;
            position = initialPosition;
            sprite = gameManager.Content.Load<Texture2D>("tile_0126");
        }

        public override void Update(float deltaTime)
        {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Space) && !isJumpPressed)
            {
                velocityY = flapForce; // Apply upward velocity when space is pressed
                isJumpPressed = true;
            }
            else if (kstate.IsKeyUp(Keys.Space))
            {
                isJumpPressed = false;
            }

            velocityY += gravityDownSpeed * deltaTime; // Apply gravity over time
            velocityY = MathHelper.Clamp(velocityY, flapForce, maxGravity);

            position.Y += velocityY * deltaTime; // Apply velocity to position

            int heightOfWindow = gameManager.Graphics.PreferredBackBufferHeight;
            position.Y = MathHelper.Clamp(position.Y, 0, heightOfWindow - sprite.Height);
        }
    }
}
