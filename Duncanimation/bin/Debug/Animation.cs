using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duncanimation
{
    public class Animation
    {
        string name;
        int startFrame;
        int frames;
        int loopFrame;
        float speed;
        bool looping;

        #region properties
        public bool Looping
        {
            get { return looping; }
        }
        public string Name
        {
            get { return name; }
        }
        public int StartingFrame
        {
            get { return startFrame; }
        }
        public int LoopFromFrame
        {
            get { return loopFrame; }
        }
        public int NumberOfFrames
        {
            get { return frames; }
        }
        public float FramesPerSecond
        {
            get { return speed; }
        }
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion

        public Animation(string name, int startFrame, int frames, float speed, bool looping)
        {
            this.startFrame = startFrame;
            this.frames = frames;
            this.speed = speed;
            this.name = name;
            this.looping = looping;
            this.loopFrame = startFrame;
        }

        public Animation(string name, int startFrame, int frames, float speed, bool looping, int loopFrom)
        {
            this.startFrame = startFrame;
            this.frames = frames;
            this.speed = speed;
            this.name = name;
            this.looping = looping;
            this.loopFrame = loopFrom;
        }

    }
}
