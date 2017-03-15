using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

    class RigidBody
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Position { get; set; }
        public bool IsGravityAffected { get; set; }
        public Rect geometry { get; protected set; }

        public GameObject Parent { get; set; }

        public RigidBody(Vector2 position, GameObject parent, Rect boundingBox = null)
        {
            Position = position;
            Parent = parent;

            if (boundingBox != null)
            {
                geometry = boundingBox;

            }
            else
            {
                //default bounding box
                geometry = new Rect(new Vector2(0, 0), new Vector2(Parent.Width * Parent.Scale.X - 1, Parent.Height * Parent.Scale.Y - 1));

            }

            geometry.Parent = this;

            PhysicsMgr.AddBody(this);
        }

        public void AddVelocity(float velX, float velY)
        {
            Velocity = new Vector2(Velocity.X + velX, Velocity.Y + velY);
        }

        public void SetYvelocity(float vel)
        {
            Velocity = new Vector2(Velocity.X, vel);
        }

        public void SetXvelocity(float vel)
        {
            Velocity = new Vector2(vel, Velocity.Y);
        }

        public void Update()
        {
            if (IsGravityAffected)//add gravity
                Velocity = new Vector2(Velocity.X, Velocity.Y + PhysicsMgr.G * Game.Window.deltaTime);

            Position = new Vector2(Position.X + Velocity.X * Game.Window.deltaTime, Position.Y + Velocity.Y * Game.Window.deltaTime);
        }

        public bool isColliding(RigidBody other)
        {
            return this.geometry.Collide(other.geometry);
        }
    }
