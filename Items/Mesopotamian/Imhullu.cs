using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class Imhullu : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Imhullu, the weapon used by the sky god Marduk " );
            Tooltip.SetDefault( "LMB: Stab. RMB: Elemental Attack." );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Orange;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.autoReuse = true;
            SetStabMode();
        }

        private void SetStabMode() {
            item.damage = 13;
            item.mana = 0;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileID.Arkhalis;
            item.noMelee = false;
            item.reuseDelay = 25;
        }

        private void SetThrowMode() {
            item.damage = 13;
            item.mana = 20;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item42;          
            item.shoot = ProjectileID.SandnadoFriendly;
            item.shootSpeed = 4f;
            item.noMelee = true;
            item.reuseDelay = 50;
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

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }
    }
}