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
using Overdone.Projectiles;

namespace Overdone.Items.Egyptian {
    public class BowOfAnhur : DoubleUseOverdoneModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Bow of Anhur" );
            Tooltip.SetDefault( "LMB: Shoot 3 poison arrows \n RMB: shoot more arrows in an unconventional way" );
        }

        public override void SetDefaults() {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( gold: 14 );
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            Item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 2;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 10;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 25f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ArrowEgypt>();
            ComboBuildPerHit = 1;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 3 ) ) {
                const float numberProjectiles = 7;
                const float rotation = (float)(0.7 * Math.PI);
                position += Vector2.Normalize( velocity ) * 45f;

                for ( int i = 0; i < numberProjectiles; i++ ) {
                    Vector2 perturbedSpeed = velocity.RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                    Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, perturbedSpeed.X * 2.5f, perturbedSpeed.Y * 2.5f, type, damage, knockBack, player.whoAmI );
                }
            }
            return false;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Egyptian;
        protected override GodDomain GodDomain => GodDomain.Hunting;
    }
}