using Terraria;

namespace Overdone.Combo {
    public static class ComboManager {
        public static long Combo { get; private set; }

        /// <summary>
        /// Amount of combo to add
        /// </summary>        
        public static void Add( int amount ) {
            Combo += amount;
            Main.NewText( $"COMBO {Combo}", 255, 0, 0 );
        }

        /// <summary>
        /// Try to use combo with a certain cost.
        /// </summary>
        /// <param name="price">The amount of combo needed,</param>
        /// <returns>If the combo can be used.</returns>
        public static bool UseCombo( int price ) {
            if ( Combo < price ) return false;
            Combo -= price;
            Main.NewText( $"COMBO {Combo}", 255, 0, 0 );
            return true;
        }
    }
}