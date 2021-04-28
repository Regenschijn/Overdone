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
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;

            aiType = 49;
        }

        public override void AI() {
            base.AI();
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            // een of ander on hit effect?
        }
    }
}