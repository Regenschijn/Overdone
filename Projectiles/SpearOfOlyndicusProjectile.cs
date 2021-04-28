using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles {
    public class SpearOfOlyndicusProjectile : ModProjectile {
        public override void SetDefaults() {
            projectile.width = 80;
            projectile.height = 80;
            // projectile.scale = 0.5f;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
            aiType = 49;

            drawOriginOffsetX = -500;
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            // een of ander on hit effect?
        }
    }
}