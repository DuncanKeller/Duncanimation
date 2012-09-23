using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Duncanimation
{
    public class Animator
    {
        Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        Animation currentAnimation = null;
        Texture2D spriteSheet;
        int rows;
        int columns;

        int currentFrame = 0;
        float timer = 0;
        bool playing = true;

        public bool FinishedPlaying
        {
            get
            {
                return (currentFrame == currentAnimation.StartingFrame + currentAnimation.NumberOfFrames &&
                    currentAnimation.Looping == false);
            }
        }

        public string CurrentAnimation
        {
            get { return currentAnimation.Name; }
        }

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

        public void AddAnimation(string name, int start, int numFrames, float speed, bool looping, int loopFrom)
        {
            Animation anim = new Animation(name, start, numFrames, speed, looping, loopFrom);
            animations.Add(name, anim);
        }

        public void Update(float deltaTime)
        {
            if (currentAnimation != null && playing)
            {
                if (currentFrame >= currentAnimation.StartingFrame + currentAnimation.NumberOfFrames)
                {
                    if (currentAnimation.Looping)
                    {
                        currentFrame = currentAnimation.LoopFromFrame;
                    }
                    else
                    {
                        currentFrame = currentAnimation.StartingFrame + currentAnimation.NumberOfFrames;
                        Stop();
                    }
                }

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

        public void Play(string anim)
        {
            currentAnimation = animations[anim];
            currentFrame = animations[anim].StartingFrame;
            Play();
        }

        public void Draw(SpriteBatch sb, Rectangle dest, Color c, float rotation, Vector2 origin, SpriteEffects effect)
        {
            int width = spriteSheet.Width / columns;
            int height = spriteSheet.Height / rows;
            int x = (currentFrame % columns) * width;
            int y = (currentFrame / columns) * height;
            Rectangle source = new Rectangle(x, y, width, height);
            origin = new Vector2(width * origin.X, height * origin.Y);

            sb.Draw(spriteSheet, dest, source, c, rotation, origin, effect, 0);
        }
    }
}