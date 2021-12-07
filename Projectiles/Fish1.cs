using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class Fish1 : DodoModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Dead fish";
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 5;
            projectile.penetrate = 1;
            projectile.timeLeft = 120;
            projectile.extraUpdates = 1;
            projectile.knockBack = 2;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            }        
    
    }
}

