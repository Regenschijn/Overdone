﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://tconfig.fandom.com/wiki/List_of_Projectile_AI_Styles

namespace Overdone.Base {
    public static class AiStyles {
        /// <summary>
        /// Boulder
        /// </summary>
        public const int Boulder = 25;

        /// <summary>
        /// Magic bounce effect. Projectile bounces. Bouncing is much 'springier' than effect #14 or #16.
        /// </summary>
        public const int MagicBounce = 8;
    }
}
