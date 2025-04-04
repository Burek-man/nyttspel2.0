using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;


namespace spaceshhoter
{
    public class bullet
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;

        public Rectangle Hitbox
        {
            get { return hitbox; }
        }

        private Random random = new Random();
        private Color currentColor = Color.White;
        private float timePassed = 0f;
        private float changeInterval = 0.5f; 

        public bullet(Texture2D texture, Vector2 spawnposition)
        {
            this.texture = texture;
            position = spawnposition;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 10, 10);
        }

        public void Update(GameTime gameTime)
        {
            float speed = 50;
            position.Y -= speed * 1f / 50f;
            hitbox.Location = position.ToPoint();
        
        
                { 
            float Speed = 50;
            position.Y -= Speed * 1f / 50f;
            hitbox.Location = position.ToPoint();
                }
            timePassed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timePassed >= changeInterval)
            {
                currentColor = new Color(random.Next(256), random.Next(233), random.Next(174));
                timePassed = 0f;  
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, currentColor);
        }
    }
}


    


        