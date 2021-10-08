using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Items;

namespace Overdone.Items.Mesopotamian {
    public class RodAndRing : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rod and Ring");
            Tooltip.SetDefault( "Rule the world with a ruler. \n LMB: Shoots banana-shaped wind projectiles. If you have 50 or more combo, get an improved projectile. RMB: Use 10 combo to shoot five projectiles instead. " );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            UseCombo = true;
            item.magic = true;
            item.width = 32;
            item.height = 32;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Green;
            item.noMelee = true;
            item.noUseGraphic = false;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 20;
            item.mana = 4;
            item.magic = true;

            item.shootSpeed = 15f;
            item.useTime = 20;
            item.useAnimation = 20;

            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item34;
            if ( ComboManager.Combo >= 50 ) {
                item.shoot = ModContent.ProjectileType<WindBanana>();
                item.damage = 30;
            }
            else {
                item.shoot = ModContent.ProjectileType<WindBananaSmall>();
                item.damage = 20;
            }
            item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            item.damage = 25;
            item.mana = 0;
            item.magic = true;

            item.shootSpeed = 15f;
            item.useTime = 35;
            item.useAnimation = 35;
            item.shoot = ModContent.ProjectileType<WindBanana>();
            
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item45;
            item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
           return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 10 ) ) {
                const float numberProjectiles = 5;
                const float rotation = (float)(0.2 * Math.PI);
                position += Vector2.Normalize( new Vector2( speedX, speedY ) ) * 45f;

                for ( int i = 0; i < numberProjectiles; i++ ) {
                    Vector2 perturbedSpeed = new Vector2( speedX, speedY ).RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                    Projectile.NewProjectile( position.X, position.Y, perturbedSpeed.X * 2.5f, perturbedSpeed.Y * 2.5f, type, damage, knockBack, player.whoAmI );
                }
            }
            return false;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }
        
        protected override Mythology Mythology => Mythology.Mesopotamian;
        protected override GodDomain GodDomain => GodDomain.Creation;
    }
}