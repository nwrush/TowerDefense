﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SharpGLass {
    public abstract class Input {

        public enum KeyState {
            None,
            Down,
            Pressed,
            Released
        }

        private static Dictionary<Keys, KeyState> KeyboardState = new Dictionary<Keys, KeyState>();
        //private static Dictionary<MouseButton, KeyState> MouseState = new Dictionary<MouseButton, KeyState>();

        public static Point MousePosition;

        public static Dictionary<Keys, KeyState> KeyTable {
            get { return KeyboardState; }
            private set { KeyboardState = value; }
        }
        //public static Dictionary<MouseButton, KeyState> MouseTable {
        //    get { return MouseState; }
        //    private set { MouseState = value; }
        //}

        public static void Update() {

            Dictionary<Keys, KeyState> tempState = new Dictionary<Keys, KeyState>();
            foreach (KeyValuePair<Keys, KeyState> kvp in KeyboardState) {
                Keys key = kvp.Key;
                if (KeyboardState[key] == KeyState.Pressed) { tempState[key] = KeyState.Down; }
                if (KeyboardState[key] == KeyState.Released) { tempState[key] = KeyState.None; }
            }
            foreach (KeyValuePair<Keys, KeyState> kvp in tempState) {
                Keys key = kvp.Key;
                KeyboardState[key] = tempState[key];
            }
        }

        public static KeyState GetKeyState(Keys k) {
            KeyState pressed = KeyState.Pressed;
            KeyState down = KeyState.Down;
            KeyState released = KeyState.Released;

            if (KeyTable.TryGetValue(k, out pressed)) {
                return pressed;
            }
            else if (KeyTable.TryGetValue(k, out down)) {
                return down;
            }
            else if (KeyTable.TryGetValue(k, out released)) {
                return released;
            }

            return KeyState.None;
        }

        public static void SetKeyState(Keys k, KeyState state) {
            if (KeyTable.ContainsKey(k) == false) {
                KeyTable.Add(k, state);
            }
            else { KeyTable[k] = state; }
        }

        //public static void SetMouseButton(MouseButton m, KeyState state) {
        //    if (MouseTable.ContainsKey(m) == false) {
        //        MouseTable.Add(m, state);
        //    }
        //    else { MouseTable[m] = state; }
        //}
        //public static KeyState GetMouseButton(MouseButton m) {
        //    KeyState pressed = KeyState.Pressed;
        //    KeyState down = KeyState.Down;
        //    KeyState released = KeyState.Released;

        //    if (MouseTable.TryGetValue(m, out pressed)) {
        //        return pressed;
        //    }
        //    else if (MouseTable.TryGetValue(m, out down)) {
        //        return down;
        //    }
        //    else if (MouseTable.TryGetValue(m, out released)) {
        //        return released;
        //    }

        //    return KeyState.None;
        //}

        //public static bool IsMouseClicked() {
        //    return (GetMouseButton(MouseButton.Left) == KeyState.Down || GetMouseButton(MouseButton.Left) == KeyState.Pressed);
        //}

        //Personally added functions
        public static bool IsKeyDown(Keys key) {
            //If the key is down or pressed return true
            if (KeyboardState.ContainsKey(key)) {
                if ((KeyboardState[key].Equals(KeyState.Down)) || (KeyboardState[key].Equals(KeyState.Pressed))) { return true; }
            }
            return false;
        }
        public static bool IsKeyUp(Keys key) {
            //If the key is up or released return true
            if (KeyboardState.ContainsKey(key)) {
                if ((KeyboardState[key].Equals(KeyState.None)) || (KeyboardState[key].Equals(KeyState.Released))) { return true; }
            }
            return false;
        }
    }
}