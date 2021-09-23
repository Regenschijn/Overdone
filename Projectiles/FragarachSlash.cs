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
            projectile.Name = "Fragarach Slash";
            projectile.width = 10;
            projectile.height = 64;
            projectile.aiStyle = 1;
            projectile.penetrate = 3;
            projectile.timeLeft = 15;
            projectile.extraUpdates = 3;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.9f;
        }        
    
    }
}

