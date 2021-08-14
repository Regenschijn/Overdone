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
    public class YggdrasilLarge : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Full Twig of Yggdrasil" );
            Tooltip.SetDefault( "Someone tore a full branch off of the world tree. \n LMB: Shoot leaves. RMB: Nova blast of leaves." );
        }

        public override void SetDefaults() {
            item.damage = 10;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice( silver: 50 );
            item.rare = ItemRarityID.Green;
            item.noMelee = false;
            item.noUseGraphic = false;
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 10;
            item.mana = 7;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 16f;
            item.autoReuse = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<YggdrasilLeaf>();
        }

        protected override void SetRightClickMode() {
            item.damage = 13;
            item.mana = 0;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 25f;
            item.noMelee = true;
            item.autoReuse = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            for ( var i = 0; i < 3; i++ ) {
                Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -130, 330 ) / 150f, speedY + Main.rand.Next( -330, 130 ) / 150f, ModContent.ProjectileType<YggdrasilLeaf>(), damage, knockBack, player.whoAmI, 0f, 0f );
            }
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 5 ) ) {
                const float numberProjectiles = 24;
                const float rotation = (float)(2 * Math.PI);
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

        protected override Mythology Mythology => Mythology.Norse;
        protected override GodDomain GodDomain => GodDomain.Creation;
    }
}