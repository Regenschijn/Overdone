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
            Tooltip.SetDefault( "Burn your foes with Sol's bright wrath! \n LMB: Shoot fireballs that cost mana. Burns enemies. \n RMB: Shoots firebolts that cost combo instead and gains attack for every 25 combo. \n damage while wet or in water is halved" );
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
            item.damage = 25;
            item.mana = 5;
            item.useTime = 22;
            item.useAnimation = 22;
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
            item.damage = (int) (20 + (ComboManager.Combo / 25f));
            item.mana = 0;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.knockBack = 2f;
            item.UseSound = SoundID.Item110;
            item.shootSpeed = 12f;
            item.noMelee = true;
            item.autoReuse = true;
            item.reuseDelay = 0;
            item.shoot = ModContent.ProjectileType<InvictusBolt>();
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {            
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 1 ) ) {
                Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + Main.rand.Next( -30, 30 ) / 150f,
                    speedY + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<Projectiles.InvictusBolt>(),
                    damage, knockBack, player.whoAmI, 0f, 0f );
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

        protected override Mythology Mythology => Mythology.Roman;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}