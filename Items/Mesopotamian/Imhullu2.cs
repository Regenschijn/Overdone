using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;

namespace Overdone.Items {
    public class Imhullu2 : DoubleUseDodoModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Imhullu Restored " );
            Tooltip.SetDefault( "LMB: Stab. RMB: Shoot Imhullu" );
        }

        public override void SetDefaults() {
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.value = Item.sellPrice( gold: 5 );
            item.rare = ItemRarityID.Orange;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.autoReuse = true;
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode () {
            item.damage = 26;
            item.mana = 0;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 1f;
            item.UseSound = SoundID.Item1;
            item.noMelee = false;
            item.reuseDelay = 25;
        }

        
        protected override void SetRightClickMode() {
            item.damage = 20;
            item.mana = 20;
            item.useTime = 50;
            item.useAnimation = 50;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item42;
            item.shoot = ProjectileID.SandnadoFriendly;
            item.shootSpeed = 4f;
            item.noMelee = true;
            item.reuseDelay = 50;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type,
            ref int damage, ref float knockBack ) {
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
        protected override GodDomain GodDomain => GodDomain.Weather | GodDomain.Thunder;
    }
}