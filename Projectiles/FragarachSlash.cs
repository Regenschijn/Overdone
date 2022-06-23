using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class FragarachSlash : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Fragarach Slash";
            Projectile.width = 10;
            Projectile.height = 64;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 15;
            Projectile.extraUpdates = 3;
            Projectile.knockBack = 0;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.9f;
        }        
    
    }
}

