﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Monogame._2;

namespace spaceshhoter;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Player player;
    private Texture2D dacia;
    private Texture2D alberg;
    private Texture2D backgrundbild;

    private List<Enemy> enemies = new List<Enemy>();
    Song theme; 

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);


        alberg = Content.Load<Texture2D>("Alberg");

        dacia = Content.Load<Texture2D>("Dacia");

        backgrundbild = Content.Load<Texture2D>("background-road");

        player = new Player(dacia,new Vector2(380,250),150);

        enemies.Add(new Enemy(alberg));
        
        theme = Content.Load<Song>("gpsmusic");
        MediaPlayer.Play(theme);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        

        player.Update(gameTime);
        foreach(Enemy Enemy in enemies){
            Enemy.Update();
        }

        enemybulletCollision();

        SpawnEnemy();
        base.Update(gameTime);
    }  

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        _spriteBatch.Begin();
        Rectangle bgRect = new(0, 0, 800, 600);
        _spriteBatch.Draw(backgrundbild, bgRect, Microsoft.Xna.Framework.Color.Black);
        player.Draw(_spriteBatch);
        foreach(Enemy Enemy in enemies)
        Enemy.Draw(_spriteBatch);

        _spriteBatch.End();



        base.Draw(gameTime);
    }
    private void SpawnEnemy(){
        Random rand = new Random();
        int value = rand.Next(1,1001);
        int spawnChancePercent = 5;
        if(value<=spawnChancePercent) {
            enemies.Add(new Enemy(alberg));
        }
    }

private void enemybulletCollision(){
for(int i = 0; i <enemies.Count; i++){
    for(int j = 0; j <player.Bullets.Count; j++){
        if(enemies[i].Hitbox.Intersects(player.Bullets[j].Hitbox)){
            enemies.RemoveAt(i);
            player.Bullets.RemoveAt(j);
            break;  
        }
    }

}
}

}