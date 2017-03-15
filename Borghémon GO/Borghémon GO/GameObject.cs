using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

    class GameObject
    {
        public Vector2 Position
        {
            get
            {
                return sprite.position;
            }

            protected set
            {
                sprite.position = value;
            }
        }

        public float Width
        {
            get
            {
                return sprite.Width;
            }
        }

        public float Height
        {
            get
            {
                return sprite.Height;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return this.rigidBody.Velocity;
            }

            set
            {
                this.rigidBody.Velocity = value;
            }

        }

        public Vector2 Scale
        {
            get
            {
                return sprite.scale;
            }
        }

        public bool IsActive { get; set; }

        protected Sprite sprite;
        protected Texture texture;
        protected RigidBody rigidBody;
        //protected Vector2 direction;
        //protected float speed;

        public GameObject(Vector2 position, String textureName)
        {
            this.texture = GfxMgr.GetTexture(textureName);
            sprite = new Sprite(texture.Width, texture.Height);
            this.Position = position;
            //this.direction = new Vector2(direction.X, direction.Y);            
            //this.speed = speed;
            IsActive = true;
        }

        public virtual void Draw()
        {
            //if (IsActive)
                sprite.DrawTexture(texture);
        }

        public virtual void Update()
        {
            //if(IsActive)
            //    Position += direction * Game.Window.deltaTime * speed;

            if (rigidBody != null)
                this.sprite.position = rigidBody.Position;

        }

        public virtual void OnCollide(GameObject other)
        {

        }
    }
