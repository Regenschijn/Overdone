using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class WasSeptreOfSet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Set's Was Septre" );
            Tooltip.SetDefault( "LMB: melee boink. RMB: Heavy havoc" );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 70;
            item.height = 70;
            item.value = Item.sellPrice( gold: 20 );
            item.rare = ItemRarityID.Yellow;
            item.noMelee = false;
            item.noUseGraphic = false;
            SetStabMode();
        }

        private void SetStabMode() {
            item.melee = true;
            item.magic = false;
            item.damage = 23;
            item.crit = 19;
            item.mana = 0;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 13f;
            item.UseSound = SoundID.DD2_MonkStaffSwing;
            item.shoot = default;
            item.shootSpeed = default;
            item.noMelee = false;
            item.autoReuse = true;
        }

        private void SetThrowMode() {
            item.melee = false;
            item.magic = true;
            item.damage = 35;
            item.crit = 0;
            item.mana = 1;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.DD2_FlameburstTowerShot;
            item.shoot = ModContent.ProjectileType<AhnkProjectile>();
            item.shootSpeed = 15f;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool AltFunctionUse( Player player ) => true;
        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) { // Throw mode
                SetThrowMode();
            } else { // Stab mode
                SetStabMode();
            }
            return true;
        }

        public override void OnHitNPC( Player player, NPC target, int damage, float knockBack, bool crit ) {
            if ( player.altFunctionUse == 2 ) {
                target.AddBuff( BuffID.Ichor, 90 );
            }
            else { }
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }
    }
}