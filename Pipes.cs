using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;


namespace ProgII_GameMonogame_JuliaC01272025
{
    internal class Pipes : GameEntity
    {
        private GameManager gameManager;

        public Pipes(GameManager game, Vector2 initialPosition) : base(game, initialPosition)
        {
            gameManager = game;
            sprite = gameManager.Content.Load<Texture2D>("tile_0095");
        }
        public override void Update(float deltaTime)
        {

        }
        // from player
        
        // collision

        // gap
        // position
    }
}
