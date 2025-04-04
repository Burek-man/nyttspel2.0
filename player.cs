using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace spaceshhoter
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        private KeyboardState newKstate;
        
         private KeyboardState oldkState;
         private MouseState newMstate;
         private float hp;

        private List<bullet> bullets = new List<bullet>();

        public List<bullet> Bullets{
            get{return bullets;}
        }
        public float Hp{
            get{return hp;}
        }

        public Player(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,
            pixelSize,(int)(pixelSize*1.5f));

        }
    public void Update(GameTime gameTime){
        newKstate = Keyboard.GetState();
        newMstate = Mouse.GetState();
       Move();
       Shoot();
        oldkState = newKstate;

       foreach(bullet b in bullets){
        b.Update(gameTime);
       }
    }


    private void Shoot(){
        
        if((newKstate.IsKeyDown(Keys.Space) && oldkState.IsKeyUp(Keys.Space)) || newMstate.LeftButton == ButtonState.Pressed){
            bullet bullet = new bullet(texture,new(position.X + hitbox.Width/2, position.Y+30)); 
            bullets.Add(bullet);
        }
    }
    private void Move(){
    

        if(newKstate.IsKeyDown(Keys.A)){
            position.X -= 5;
        }
        else if(newKstate.IsKeyDown(Keys.D)){
            position.X +=5;
        }
        if(newKstate.IsKeyDown(Keys.W)){
            position.Y -= 5;
        }
        else if(newKstate.IsKeyDown(Keys.S)){
            position.Y +=5;
        }
        hitbox.Location = position.ToPoint();
    }



    public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture,hitbox,Color.White);
        foreach(bullet b in bullets){
            b.Draw(spriteBatch);
        }
    }
    }
}