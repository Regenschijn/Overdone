using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class SpearOfOlyndicusProjectile : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = 19;
            Projectile.penetrate = -1;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.friendly = true;

            AIType = 49;
        }

        public override void AI() {
            base.AI();
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            // een of ander on hit effect?
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}