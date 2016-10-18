﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefenseAlgorithm
{
    class PurpleTower : Tower
    {
        float fireRate = 1f;
        float reloadTimer = 0;
        bool reloading = true;
        public PurpleTower(Vector2 pos, int damage) : base(pos, damage)
        {

        }
        public override void Update(GameTime time)
        {
            foreach (Bullet b in bullets)
            {
                b.Update(time);
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
            sb.Draw(Globals.purpleTower, pos);
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