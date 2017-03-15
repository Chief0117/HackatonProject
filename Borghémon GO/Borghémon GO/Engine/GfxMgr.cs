using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

    class GfxMgr
    {
        private static Dictionary<String, Texture> textures;

        static GfxMgr()
        {
            textures = new Dictionary<String, Texture>();

        //textures.Add("cannon", new Texture("Assets/cannon_straight.png"));
        //textures.Add("cannonBase", new Texture("Assets/cannon_base.png"));
        //textures.Add("ball", new Texture("Assets/cannon_ball.png"));

        textures.Add("player", new Texture("Assets/player.png"));

        }

        public static Texture GetTexture(String textureName)
        {
            if (textures.ContainsKey(textureName))
                return textures[textureName];
            return null;
        }
    }
