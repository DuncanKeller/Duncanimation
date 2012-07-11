using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duncanimation
{
    class Animator
    {
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        Animation currentAnimation = null;
        Texture2D spriteSheet;
        int rows;
        int columns;

        int currentFrame = 0;
        float timer = 0;
        bool playing = true;

        public Animator(Texture2D spriteSheet, int rows, int columns)
        {
            this.spriteSheet = spriteSheet;
            this.rows = rows;
            this.columns = columns;
        }

        public void AddAnimation(string name, int start, int numFrames, float speed, bool looping)
        {
            Animation anim = new Animation(name, start, numFrames, speed, looping);
            animations.Add(name, anim);
        }

        public void Update(float deltaTime)
        {
            if (currentAnimation != null && playing)
            {
                timer += (deltaTime / 1000) * currentAnimation.FramesPerSecond;
                if (timer > 1)
                {
                    timer = 0;
                    currentFrame++;
                }
            }
        }

        public void Stop()
        {
            playing = false;
        }

        public void Play()
        {
            playing = true;
        }

        public void Draw(SpriteBatch sb)
        {
            int x = currentFrame % columns;
            int y = currentFrame / columns;
            int width = spriteSheet.Width / columns;
            int height = spriteSheet.Height / rows;
            Rectangle source = new Rectangle(x,y,width,height);
        }
    }
}