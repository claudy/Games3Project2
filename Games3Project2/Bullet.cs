﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

using BoundingVolumeRendering;
using Games3Project2.Globals;

namespace Games3Project2
{
    public class Bullet : Collidable
    {
        BoundingSphere bs;
        //TODO: CreateTranslation matrix
        public const int TTL = 2000; //Milliseconds
        public int timeLived;
        /// <summary>
        /// // The networkPlayerID of the shooter who shot this bullet.
        /// </summary>
        public int shooterID; 
        public Vector3 startPosition;
        public int damage;

        /// <param name="shooterID">networkPlayerID</param>
        public Bullet(Vector3 startPosition, Vector3 velocity, int shooterID, int damage) :
            base(Global.game, startPosition, velocity, Global.Constants.BULLET_RADIUS)
        {
            this.startPosition = startPosition;
            this.shooterID = shooterID;
            bs = new BoundingSphere(startPosition, Global.Constants.BULLET_RADIUS);
            this.damage = damage;
            timeLived = 0;
        }

        public void update(GameTime gametime)
        {
            position = position + velocity * gametime.ElapsedGameTime.Milliseconds;
            bs.Center = position;
            timeLived += gametime.ElapsedGameTime.Milliseconds;
        }

        public void draw()
        {
            BoundingSphereRenderer.Draw(bs,
                Global.CurrentCamera.view,
                Global.CurrentCamera.projection);

            //TODO: Add bullet geometry. Perhaps a sideways cylinder.
        }
            
    }
}
