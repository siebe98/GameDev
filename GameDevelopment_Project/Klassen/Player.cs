using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopment_Project.Klassen
{
    class Player
    {
        public Texture2D PlayerTexture;
        public Vector2 Position;
        // eventueel active nog toevoegen
        public int Health;

        public int Width { get { return PlayerTexture.Width; } }
        public int Height { get { return PlayerTexture.Height; } }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            PlayerTexture = texture;
            Position = position;
            // 200 ipv van 100
            Health = 200;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // eventueel nog meer dingen aan methode
            spriteBatch.Draw(PlayerTexture, Position);
        }
    }
}
