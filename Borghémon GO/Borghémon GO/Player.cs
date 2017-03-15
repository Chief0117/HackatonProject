using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Aiv.Fast2D;


namespace Borghémon_GO
{
    class Player : GameObject
    {
        public Vector2 jumpForce;
        public int jumpPower = 300;
        public Vector2 gravityAccumulator;

        public Player(Vector2 position):base(position, "player")
        {
            gravityAccumulator = Vector2.Zero;
            jumpForce = Vector2.Zero;
            this.sprite = new Sprite(1, 1);
        }

        public override void Update()
        {
            Jump();
        }


        private void Jump()
        {
            if (Game.Window.GetKey(KeyCode.Space))
            {
                gravityAccumulator = Vector2.Zero;
                jumpForce = new Vector2(0, -jumpPower);
            }

            if(this.sprite.position.Y >= Game.Window.Height - this.sprite.Height)
            {
                Vector2 fakepos = this.sprite.position;
                fakepos.Y = 0;
                this.sprite.position = fakepos;
            }
        }


    }
}
