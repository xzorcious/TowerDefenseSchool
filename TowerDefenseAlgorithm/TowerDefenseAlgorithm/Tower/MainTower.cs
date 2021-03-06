﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefenseAlgorithm
{
    class MainTower : Tower 
    {
        float fireRate = 0.6f;
        float reloadTimer = 0;
        bool reloading = true;
        public MainTower(Vector2 pos, float damage) : base(pos, damage)
        {
            
        }
        public override void Update(GameTime time)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(time);
                bullets[i].RemoveBullet();
                if (bullets[i].finished)
                {
                    bullets.RemoveAt(i);
                }               
            }
            if (reloading)
            {
                reloadTimer += (float)time.ElapsedGameTime.TotalSeconds;
            }
            if (reloadTimer > fireRate)
            {
                reloading = false;
            }
        }
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(Globals.mainTower, pos);
            foreach (Bullet b in bullets)
            {
                b.Draw(sb);
            }
        }
        public override void Shoot(Vector2 target)
        {
            if (!reloading)
            {
                bullets.Add(new NormalBullet(new Vector2((int)pos.X + 25, (int)pos.Y + 25), target, damage));
                reloading = true;
                reloadTimer = 0;
            }            
        }

    }
}
