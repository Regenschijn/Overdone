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
    public class ReedsOfEnki : DoubleUseOverdoneModItem {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Reeds of Enki");
            // Tooltip.SetDefault( "By the power of Abzu! \n LMB: Shoot reed projectiles. If you have 40 or more combo, shoot faster and cheaper. RMB: Use 10 combo to shoot five projectiles instead. " );
        }

        // I switched around throw and melee for fun

        public override void SetDefaults() {
            UseCombo = true;
            Item.DamageType = DamageClass.Magic;
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 20;
            Item.mana = 8;
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item34;
            Item.damage = 30;
            Item.shoot = ModContent.ProjectileType<ReedsOfEnkiProjectile>();
            if ( ComboManager.Combo >= 250 ) {
                Item.shootSpeed = 20f;
                Item.useTime = 15;
                Item.useAnimation = 15;
                Item.mana = 3;
            }
            else if ( ComboManager.Combo >= 50 ) {
                Item.shootSpeed = 15f;
                Item.useTime = 20;
                Item.useAnimation = 20;
                Item.mana = 6;
            }
            else {
                Item.shootSpeed = 10f;
                Item.useTime = 30;
                Item.useAnimation = 30;
                Item.mana = 9;
            }
            Item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            Item.damage = 25;
            Item.mana = 0;
            Item.DamageType = DamageClass.Magic;

            Item.shootSpeed = 15f;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.shoot = ModContent.ProjectileType<WindBananaTriSmall>();
            
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item45;
            Item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 10 ) ) {
                const float numberProjectiles = 3;
                const float rotation = (float)(0.1 * Math.PI);
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
        protected override Mythology Mythology => Mythology.Mesopotamian;
        protected override GodDomain GodDomain => GodDomain.Creation;
    }
}