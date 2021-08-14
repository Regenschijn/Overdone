using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class PoisonAura : DodoModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Asclepius' Cloud";
            projectile.width = 100;
            projectile.height = 100;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            projectile.aiStyle = 11;
        }

        public override void Kill( int timeLeft ) {
            
        }
    }
}
