using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense {
    public static partial class MouseInput {
        static bool isLeftMouseDown() {
            if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed)) {
                return true;
            }
            return false;
        }

        static bool isRightMouseDown() {
            if (Mouse.GetState().RightButton.Equals(ButtonState.Pressed)) {
                return true;
            }
            return false;
        }

        static Vector2 getPos() {
            return new Vector2((float)Mouse.GetState().X, (float)Mouse.GetState().Y);
        }
    }
}
