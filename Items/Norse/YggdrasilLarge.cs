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

namespace Overdone.Items.Norse {
    public class YggdrasilLarge : DoubleUseOverdoneModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Full Twig of Yggdrasil" );
            Tooltip.SetDefault( "Someone tore a full branch off of the world tree. \n LMB: Shoot leaves. RMB: Nova blast of leaves." );
        }

        public override void SetDefaults() {
            Item.damage = 10;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice( silver: 50 );
            Item.rare = ItemRarityID.Green;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 10;
            Item.mana = 7;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 5f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 16f;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<YggdrasilLeaf>();
        }

        protected override void SetRightClickMode() {
            Item.damage = 13;
            Item.mana = 0;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 25f;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 3; i++ ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -130, 330 ) / 150f, velocity.Y + Main.rand.Next( -330, 130 ) / 150f, ModContent.ProjectileType<YggdrasilLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 5 ) ) {
                const float numberProjectiles = 24;
                const float rotation = (float)(2 * Math.PI);
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

        protected override Mythology Mythology => Mythology.Norse;
        protected override GodDomain GodDomain => GodDomain.Creation;
    }
}