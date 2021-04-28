using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items
{
    public class SpearOfOlyndicus : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("SpearOfOlyndicus"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("The Spear Of Olyndicus\nLMB: Stab. RMB: Throw.");
        }

        public override void SetDefaults()
        {
            item.damage = 13;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.knockBack = 9;
            item.value = 10000;
            item.crit = 15;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType("SpearOfOlyndicusProjectile");

        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
                item.noMelee = true;
                item.mana = 1;
                item.melee = false;
                item.ranged = true;
                            }
            else
            {
                item.useStyle = 5;
                item.noMelee = false;
                item.mana = 0;
                item.melee = true;
                item.ranged = false;
            }

            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX * 1.85f, speedY * 1.85f, mod.ProjectileType( "SpearOfOlyndicusProjectile" ), (int)((double)damage * 1.5), 10f, ((Entity)player).whoAmI, 0f, 0f);
                Main.PlaySound(SoundID.Item45, ((Entity)player).position);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}