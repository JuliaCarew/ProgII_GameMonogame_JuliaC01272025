using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ProgII_GameMonogame_JuliaC01272025
{
    public class GameManager : Game
    {
        private GraphicsDeviceManager _graphics;
        public GraphicsDeviceManager Graphics { get { return _graphics; } }
       
        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } }
        
        private Player player;
        private List<GameEntity> gameEntities = new List<GameEntity>();

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        public bool isGameOver { get; private set; }
        public void GameOver()
        {
            if (isGameOver)
            {

            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            gameEntities.Add(new Player(this, new Vector2(100,100)));
            //pipe = new Pipe(this, new Vector2(100, 100));
            // for loop to draw pipes
            for (int i = 0; i < 3; i++)
            {
                CreatePipe(new Vector2(_graphics.PreferredBackBufferWidth - i*70),(_graphics.PreferredBackBufferHeight));
            }
        }
        // somewhere?? foreach gameentity in gameentities draw ??
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            float deltaTime = gameTime.ElapsedGameTime.Milliseconds * 0.01f;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }
        public void CreatePipe(Vector2 pipePosition)
        {
            var newPipe = Pipe(this, pipePosition);
            gameEntities.Add(newPipe);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            player.Draw(gameTime); 
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
