using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles {
    public class None : ModProjectile {
        public override void SetDefaults() {
            projectile.width = 0;
            projectile.height = 0;

        }
    }
}

       

