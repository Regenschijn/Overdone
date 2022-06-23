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
            Projectile.Name = "Asclepius' Cloud";
            Projectile.width = 100;
            Projectile.height = 100;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 11;
        }

        public override void Kill( int timeLeft ) {
            
        }
    }
}

