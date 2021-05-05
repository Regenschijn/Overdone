using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles {
    public class ExampleBulletB : ModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Tiny Ahnk";
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 180;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 18; 
        }
        public override void AI() {
            projectile.type = 45;
        }
    }
}
