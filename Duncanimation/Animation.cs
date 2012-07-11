using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duncanimation
{
    class Animation
    {
        string name;
        int startFrame;
        int frames;
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
        public int NumberOfFrames
        {
            get { return frames; }
        }
        public float FramesPerSecond
        {
            get { return speed; }
        }
        #endregion

        public Animation(string name, int startFrame, int frames, float speed, bool looping)
        {
            this.startFrame = startFrame;
            this.frames = frames;
            this.speed = speed;
            this.name = name;
            this.looping = looping;
        }

    }
}
