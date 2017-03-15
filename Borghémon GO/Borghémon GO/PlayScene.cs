using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

    class PlayScene : Scene
    {
        //Cannon cannon;

        public override void Start()
        {
            //cannon = new Cannon(new Vector2(300, 400));

        }

        public override void Draw()
        {
            //cannon.Draw();
        }

        public override void Input()
        {
        }

        public override void Update()
        {
            IsPlaying = true;
        }
    }
