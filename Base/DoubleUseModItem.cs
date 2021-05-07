using Microsoft.Xna.Framework;
using Overdone.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class DoubleUseModItem : ModItem {

        public override bool AltFunctionUse( Player player ) => true;

        public override void SetDefaults() {
            item.shoot = ModContent.ProjectileType<None>();
            SetLeftClickMode();
        }

        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) {
                SetRightClickMode();                
            } else {
                SetLeftClickMode();
            }
            return true;
        }


        public sealed override bool Shoot( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( player.altFunctionUse == 2 ) {
                return ShootRightClick( player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack );                
            } else {
                return ShootLeftClick( player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack );
            }
        }

        protected abstract void SetLeftClickMode();
        protected abstract void SetRightClickMode();
        public abstract bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack );
        public abstract bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack );
    }
}
