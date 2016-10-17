﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace TowerDefenseAlgorithm
{
    public static class Globals
    {
        public static int TILE_SIZE = 50;
        public static int X_SIZE = 10;
        public static int Y_SIZE = 10;
        public static Texture2D wallTex;
        public static Texture2D floorText;
        public static Texture2D enemyTex;

        public static void LoadTextures(ContentManager content)
        {
            wallTex = content.Load<Texture2D>(@"notPassable");
            floorText = content.Load<Texture2D>(@"Middle");
            enemyTex = content.Load<Texture2D>(@"Ball");
        }
    }
}