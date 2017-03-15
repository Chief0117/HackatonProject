using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    abstract class Scene
    {
        public bool IsPlaying { get; protected set; }
        public Scene()
        {

        }

        public virtual void Start()
        {
            IsPlaying = true;

        }

        public abstract void Input();

        public virtual void Reset()
        {
            IsPlaying = true;
        }

        public abstract void Update();

        public abstract void Draw();
    }
