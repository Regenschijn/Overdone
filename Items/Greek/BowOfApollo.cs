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

namespace Overdone.Items.Greek {
    public class BowOfApollo : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Bow of Apollo" );
            Tooltip.SetDefault( "LMB: Burst of sun arrows \n RMB: Fling a sun blast" );
        }

        public override void SetDefaults() {
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 14 );
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.shoot = ModContent.ProjectileType<ArrowApollo>();
            ComboBuildPerHit = 1;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = 44;
            item.useTime = 5;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 20f;
            item.autoReuse = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<ArrowApollo>();
            item.reuseDelay = 25;
            ComboBuildPerHit = 1;
        }

        protected override void SetRightClickMode() {
            item.damage = 33;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 25f;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<ApolloBlast>();
            ComboBuildPerHit = 1;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -130, 330 ) / 150f, speedY + Main.rand.Next( -330, 130 ) / 150f, ModContent.ProjectileType<ApolloBlast>(), damage, knockBack, player.whoAmI, 0f, 0f );
            return false;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Sun;
    }
}