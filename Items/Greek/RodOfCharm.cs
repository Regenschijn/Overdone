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

namespace Overdone.Items.Greek {
    public class RodOfCharm : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rod of Charm");
            Tooltip.SetDefault( "LMB: Shoots homing orbs RMB: Shoots bouncing orbs " );
        }
        public override void SetDefaults() {
            UseCombo = true;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Green;
            Item.noMelee = true;
            Item.noUseGraphic = false;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 5;
            Item.mana = 4;
            Item.DamageType = DamageClass.Magic;

            Item.shootSpeed = 5f;
            Item.useTime = 20;
            Item.useAnimation = 20;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item34;
            Item.shoot = ModContent.ProjectileType<OrbCharm>();
            Item.damage = 30;


            Item.autoReuse = true;
        }

        protected override void SetRightClickMode() {
            Item.damage = 5;
            Item.mana = 4;
            Item.DamageType = DamageClass.Magic;

            Item.shootSpeed = 15f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shoot = ModContent.ProjectileType<OrbCharm>();

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item45;
            Item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {

                const float numberProjectiles = 5;
                const float rotation = (float)(0.5 * Math.PI);
                position += Vector2.Normalize( velocity ) * 45f;

                for ( int i = 0; i < numberProjectiles; i++ ) {
                    Vector2 perturbedSpeed = velocity.RotatedBy( MathHelper.Lerp( -rotation, rotation, i / (numberProjectiles - 1) ) ) * .2f;
                    Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, perturbedSpeed.X * 2.5f, perturbedSpeed.Y * 2.5f, type, damage, knockBack, player.whoAmI );
                }
            
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, velocity.X * 1.1f, velocity.Y * 1.1f, ProjectileID.Typhoon, (int)(damage / 2f), 10f, player.whoAmI, 0f, 0f );
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