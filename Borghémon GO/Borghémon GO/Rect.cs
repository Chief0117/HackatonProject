using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

    class Rect
    {
        public Vector2 TopLeft;
        public Vector2 BottomRight;
        public Vector2 Offset;//Parent position

        public RigidBody Parent { get; set; }

        public float Width { get; protected set; }
        public float Height { get; protected set; }

        public Rect(Vector2 Top_Left, Vector2 Bottom_Right, RigidBody parentGeometry = null)
        {
            TopLeft = Top_Left;
            BottomRight = Bottom_Right;

            Width = BottomRight.X - TopLeft.X;
            Height = BottomRight.Y - TopLeft.Y;

            Parent = parentGeometry;
        }

        public Rect(Vector2 Top_Left, float width, float height, RigidBody parentGeometry = null) : this(Top_Left, new Vector2(Top_Left.X + width, Top_Left.Y + height), parentGeometry)
        {

        }

        public bool Contains(Vector2 point)
        {

            return (point.X >= TopLeft.X + Offset.X && point.X <= BottomRight.X + Offset.X) && (point.Y >= TopLeft.Y + Offset.Y && point.Y <= BottomRight.Y + Offset.Y);
        }

        public bool Collide(Rect other)
        {
            //compute rectangles offset (the position of the parent)
            Offset = Parent.Parent.Position;
            other.Offset = other.Parent.Parent.Position;

            return (
                this.Contains(other.TopLeft + other.Offset) ||
                this.Contains(other.BottomRight + other.Offset) ||
                this.Contains(new Vector2(other.BottomRight.X + other.Offset.X, other.TopLeft.Y + other.Offset.Y)) ||
                this.Contains(new Vector2(other.TopLeft.X + other.Offset.X, other.TopLeft.Y + other.Offset.Y)) ||

                other.Contains(this.TopLeft + Offset) ||
                other.Contains(this.BottomRight + Offset) ||
                other.Contains(new Vector2(this.BottomRight.X + Offset.X, this.TopLeft.Y + Offset.Y)) ||
                other.Contains(new Vector2(this.TopLeft.X + Offset.X, this.TopLeft.Y + Offset.Y))
                );
        }
    }
