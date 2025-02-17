using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

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
                // freeze the game 
            }
        }

        protected override void Initialize()
        {
            base.Initialize();
            //gameEntities.Add(new Player(this, new Vector2(100,100)));
            player = new Player(this, new Vector2(300,300));
            gameEntities.Add(player);
            Debug.WriteLine("GameManager Update: " + gameEntities.Count);
            //pipe = new Pipe(this, new Vector2(100, 100));
            int screenWidth = GraphicsDevice.Viewport.Width;

            for (int i = 0; i < 3; i++) // for loop to draw pipes
            {
                gameEntities.Add(new Pipes(this, screenWidth));
            }
        }
        // somewhere?? foreach gameentity in gameentities draw ??
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var entity in gameEntities)
            {
                entity.Update(deltaTime);
            }
            base.Update(gameTime);
        }
        public void CreatePipe(Vector2 pipePosition)
        {
            //var newPipe = Pipe(this, pipePosition);
            //gameEntities.Add(newPipe);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();

            foreach (var entity in gameEntities)
            {
                entity.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
