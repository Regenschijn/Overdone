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

namespace Overdone.Items.Mesopotamian {
    public class Nergal : DoubleUseOverdoneModItem {
        private int _counter;        

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Nergal" );
            // Tooltip.SetDefault( "Nergals lion-winged mace \n LMB: Boink - every 5th attack deals extra damage \n RMB: Shoot a lions blast ");
        }

        public override void SetDefaults() {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 90;
            Item.height = 90;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 10000;
            Item.crit = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 12f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.damage = 24;
            Item.mana = 0;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 15f;
            Item.UseSound = SoundID.Item40;
            Item.shootSpeed = 12f;
            Item.autoReuse = true;
            Item.noMelee = false;
            Item.crit = (int) (7 + (ComboManager.Combo / 25f));
        }

        protected override void SetRightClickMode() {
            Item.damage = 50;
            Item.mana = 0;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1f;
            Item.UseSound = SoundID.Item110;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.reuseDelay = 37;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {            
            _counter++;
            if ( _counter < 5 )
                return false;

            for ( var i = 0; i < 3; i++ ) {
                Item.damage = damage + 24;
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {

            Projectile.NewProjectile( player.GetSource_FromAI(), position.X - 8f, position.Y + 8f, velocity.X + Main.rand.Next( -30, 30 ) / 150f, velocity.Y + Main.rand.Next( -30, 30 ) / 150f, ModContent.ProjectileType<SpiritBlastLion>(), damage, knockBack, player.whoAmI, 0f, 0f );

            return true;
        }

        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }

        protected override Mythology Mythology => Mythology.Mesopotamian;
        protected override GodDomain GodDomain => GodDomain.Afterlife;
    }
}