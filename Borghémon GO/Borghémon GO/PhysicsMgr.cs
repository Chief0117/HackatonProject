using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    static class PhysicsMgr
    {
            public static float G { private set; get; }
            private static List<RigidBody> bodies;
            private static List<RigidBody> bodiesToRemove;

            static PhysicsMgr()
            {
                G = 980.0f;
                bodies = new List<RigidBody>();
                bodiesToRemove = new List<RigidBody>();
            }

            public static void AddBody(RigidBody rb)
            {
                bodies.Add(rb);
            }

            public static void RemoveBody(RigidBody rb)
            {
                bodiesToRemove.Add(rb);
            }

            public static void CheckCollision()
            {
                for (int i = 0; i < bodies.Count; i++)
                {
                    if (bodies[i].Parent.IsActive)
                        for (int j = i + 1; j < bodies.Count; j++)
                        {
                            if (bodies[j].Parent.IsActive && bodies[i].isColliding(bodies[j]))
                            {
                                bodies[i].Parent.OnCollide(bodies[j].Parent);
                                bodies[j].Parent.OnCollide(bodies[i].Parent);
                            }
                        }
                }

                if (bodiesToRemove.Count > 0)
                {
                    foreach (RigidBody item in bodiesToRemove)
                    {
                        bodies.Remove(item);
                    }

                    bodiesToRemove.Clear();

                }
            }

            public static void RemoveAll()
            {
                bodies.Clear();
            }

            public static void Update()
            {
                foreach (RigidBody body in bodies)
                {
                    body.Update();
                }
            }
        }
