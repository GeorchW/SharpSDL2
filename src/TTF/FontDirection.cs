using System;
using System.Collections.Generic;
using System.Text;

namespace SDL2.TTF
{
    public enum FontDirection {
        /// <summary>
        /// DIRECTION_LTR (Left to Right)
        /// </summary>
        LeftToRight = 0,

        /// <summary>
        /// DIRECTION_RTL (Right to Left)
        /// </summary>
        RightToLeft = 1,

        /// <summary>
        /// DIRECTION_TTB (Top to Bottom)
        /// </summary>
        TopToBottom = 2,
        /// <summary>
        /// DIRECTION_BTT (Bottom to Top)
        /// </summary>
        BottomToTop = 3
    }
}
