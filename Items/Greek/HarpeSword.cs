using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Projectiles;

namespace Overdone.Items
{
	public class HarpeSword : DoubleUseModItem
	{

		private int counter;

		public override void SetStaticDefaults() 
		{
            Tooltip.SetDefault("Used to decapitate Medusa");
		}

		public override void SetDefaults() 
		{
			item.damage = 17;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 15;
			item.value = 10000;
			item.crit = 27;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shootSpeed = 8f;                 
            base.SetDefaults();
        }        

        protected override void SetLeftClickMode() {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = false;
            item.mana = 0;            
        }

        protected override void SetRightClickMode() {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.mana = 8;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            counter++;
            if ( counter >= 7 ) {
                for ( int i = 0; i < 3; i++ ) {
                    Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float) Main.rand.Next( -230, 230 ) / 100f, speedY + (float) Main.rand.Next( -230, 230 ) / 100f, ProjectileID.MedusaHead, damage, knockBack, (player).whoAmI, 0f, 0f );
                }
                counter = 0;
            }
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( player.altFunctionUse == 2 ) {
                Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ModContent.ProjectileType<HarpeSwordHead>(), (int) (damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
                Main.PlaySound( SoundID.Item45, player.position );
            }
            return false;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}


    }
}