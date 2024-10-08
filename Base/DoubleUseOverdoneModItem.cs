﻿using Microsoft.Xna.Framework;
using Overdone.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class DoubleUseOverdoneModItem : OverdoneModItem {
        protected bool IsUsingLeftClick = true;

        public override bool AltFunctionUse( Player player ) => true;

        public override void SetDefaults() {
            Item.shoot = ModContent.ProjectileType<None>();
            SetLeftClickMode();
        }

        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) {
                IsUsingLeftClick = false;
                SetRightClickMode();                
            } else {
                IsUsingLeftClick = true;
                SetLeftClickMode();
            }
            return true;
        }


        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            return player.altFunctionUse == 2 
                ? ShootRightClick( player, ref position, ref velocity, ref type, ref damage, ref knockback ) 
                : ShootLeftClick( player, ref position,  ref velocity, ref type, ref damage, ref knockback );
        }

        protected abstract void SetLeftClickMode();
        protected abstract void SetRightClickMode();
        public abstract bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack );
        public abstract bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack );
    }
}
