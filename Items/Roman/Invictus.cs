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

namespace Overdone.Items.Roman {
    public class Invictus : DoubleUseDodoModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Invictus" );
            Tooltip.SetDefault( "Burn your foes with Sol's wrath! \n LMB: Shoot fireballs. Pretty basic stuff \n RMB: Creates a burning aura \n damage while wet or in water is halved" );
        }

        public override void SetDefaults() {
            item.damage = 24;
            item.magic = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 15;
            item.value = 10000;
            item.crit = 7;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 10f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.damage = (int) (25 + (ComboManager.Combo / 25f));
            item.mana = 5;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item40;
            item.shootSpeed = 32f;
            item.autoReuse = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<Projectiles.Invictus>();
            
        }

        protected override void SetRightClickMode() {
            item.damage = 13;
            item.mana = 10;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 12f;
            item.noMelee = true;
            item.autoReuse = true;
            item.reuseDelay = 0;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {

            Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -30, 30 ) / 150f, speedY + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<Projectiles.Invictus>(), damage, knockBack, player.whoAmI, 0f, 0f );

            return true;
        }

        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override Mythology Mythology => Mythology.Roman;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}