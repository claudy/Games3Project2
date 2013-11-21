using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Games3Project2.Globals;
using Camera3D;
using ReticuleCursor;
using InputHandler;
using Geometry;

namespace Games3Project2
{
    
    public class BugBot
    {
        public Vector3 position;
        public Vector3 direction;
        public float speed;
        public Vector3[] points;
        public Boolean Alive;
        public int pointCount = 0;

        Sphere body;

        public BugBot(Vector3 position, float speed, Vector3 point1, Vector3 point2, Vector3 point3, Vector3 point4)
        {
            this.position = position;
            body = new Sphere(Global.game, Color.Gold, this.position);
            body.localScale = Matrix.CreateScale(5);
            body.SetWireframe(1);
            this.speed = speed;
            points = new Vector3[4];
            points[0] = point1;
            points[1] = point2;
            points[2] = point3;
            points[3] = point4;
            Alive = true;

        }
        
        public void update()
        {
            //move in a square pattern
            if (Alive)
            {
                direction = position - points[pointCount];


                if ((position - points[pointCount]).Length() < 2)
                {
                    pointCount++;
                    if (pointCount >= 4)
                        pointCount = 0;
                }

                direction.Normalize();

                position -= speed * direction * Global.gameTime.ElapsedGameTime.Milliseconds;

                body.Position = position;
                body.Update(Global.gameTime);
                
            }

        }

        public void draw()
        {
            body.Draw(Global.CurrentCamera);
        }

    }
}