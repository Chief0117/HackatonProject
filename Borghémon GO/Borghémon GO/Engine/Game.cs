using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

    class Game
    {
        public static Window Window;

        private static List<Scene> scenes;
        private static int currentScene;

        public static Scene CurrentScene
        {
            get
            {
                return scenes[currentScene];
            }
        }

        static Game()
        {
            Window = new Window(1024, 576, "MemesFromOuterSpace");
            Window.SetVSync(false);

        }

        public static void Init()
        {
            scenes = new List<Scene>();

            scenes.Add(new PlayScene());
            currentScene = 0;

        }

        public static void Update()
        {
            PhysicsMgr.Update();

            CurrentScene.Update();


            PhysicsMgr.CheckCollision();

        }

        public static void Play()
        {
            CurrentScene.Start();

            while (Window.opened)
            {
                //Utils.Clear(window);
                PhysicsMgr.Update();
                CurrentScene.Update();
                PhysicsMgr.CheckCollision();
                CurrentScene.Input();

                if (!CurrentScene.IsPlaying)
                {
                    PhysicsMgr.RemoveAll();//remove all obj in order to change level

                    if (currentScene < scenes.Count - 1)
                    {
                        currentScene++;
                        //scenes[currentScene].Start();
                    }
                    else
                        currentScene = 0;
                    CurrentScene.Start();
                }
                else//Draw level
                {
                    CurrentScene.Draw();
                }
                Window.Update();
            }

        }
    }
