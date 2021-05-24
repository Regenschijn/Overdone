using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Base;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class SpearOfOlyndicus : DodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "The Spear Of Olyndicus" );
            Tooltip.SetDefault( "LMB: Stab. RMB: Throw." );
        }

        public override void SetDefaults() {
            UseCombo = true;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Blue;
            item.noMelee = true;
            item.noUseGraphic = true;
            SetStabMode();
        }

        private void SetStabMode() {
            item.damage = 13;
            item.mana = 0;
            item.thrown = false;
            item.useTime = 15;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.shoot = ModContent.ProjectileType<SpearOfOlyndicusProjectile>();
            item.shootSpeed = 4f;
            item.autoReuse = true;
        }

        private void SetThrowMode() {
            item.damage = 13;
            item.mana = 1;
            item.thrown = true;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item5;
            
            item.shoot = ModContent.ProjectileType<SpearOfOlyndicusThrownProjectile>();
            item.shootSpeed = 15f;
            
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

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Iberian;
        protected override GodDomain GodDomain => GodDomain.War;
    }
}