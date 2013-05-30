﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense {
    public static partial class Input {
    #region Stuff that Andy Did
        //public enum KeyState {
        //    None,
        //    Down,
        //    Pressed,
        //    Released
        //}

        //private static Dictionary<Keys, KeyState> KeyboardState = new Dictionary<Keys, KeyState>();

        //public static Vector2 MousePosition;

        //public static Dictionary<Keys, KeyState> KeyTable {
        //    get { return KeyboardState; }
        //    private set { KeyboardState = value; }
        //}

        //public static void Update() {

        //    Dictionary<Keys, KeyState> tempState = new Dictionary<Keys, KeyState>();
        //    foreach (KeyValuePair<Keys, KeyState> kvp in KeyboardState) {
        //        Keys key = kvp.Key;
        //        if (KeyboardState[key] == KeyState.Pressed) { tempState[key] = KeyState.Down; }
        //        if (KeyboardState[key] == KeyState.Released) { tempState[key] = KeyState.None; }
        //    }
        //    foreach (KeyValuePair<Keys, KeyState> kvp in tempState) {
        //        Keys key = kvp.Key;
        //        KeyboardState[key] = tempState[key];
        //    }
        //    Console.Write("");
        //}

        //public static KeyState GetKeyState(Keys k) {
        //    KeyState pressed = KeyState.Pressed;
        //    KeyState down = KeyState.Down;
        //    KeyState released = KeyState.Released;

        //    if (KeyTable.TryGetValue(k, out pressed)) {
        //        return pressed;
        //    }
        //    else if (KeyTable.TryGetValue(k, out down)) {
        //        return down;
        //    }
        //    else if (KeyTable.TryGetValue(k, out released)) {
        //        return released;
        //    }

        //    return KeyState.None;
        //}

        //public static void SetKeyState(Keys k, KeyState state) {
        //    if (KeyTable.ContainsKey(k) == false) {
        //        KeyTable.Add(k, state);
        //    }
        //    else { KeyTable[k] = state; }
        //}

        ////Personally added functions
        //public static bool IsKeyDown(Keys key) {
        //    //If the key is down or pressed return true
        //    if (KeyboardState.ContainsKey(key)) {
        //        if ((KeyboardState[key].Equals(KeyState.Down)) || (KeyboardState[key].Equals(KeyState.Pressed))) { return true; }
        //    }
        //    return false;
        //}
        //public static bool IsKeyUp(Keys key) {
        //    //If the key is up or released return true
        //    if (KeyboardState.ContainsKey(key)) {
        //        if ((KeyboardState[key].Equals(KeyState.None)) || (KeyboardState[key].Equals(KeyState.Released))) { return true; }
        //    }
        //    return false;
        //}
        #endregion
        //stuff andy did is commented out
        private static KeyboardState oldState;
        private static KeyboardState currentState=Keyboard.GetState();

        public static void Update() {
            oldState = currentState;
            currentState = Keyboard.GetState();
        }
        public static bool isKeyPressed(Keys k) {
            //returns true if the key is down this tick, not pressed
            if (currentState[k] == KeyState.Down && oldState[k] == KeyState.Up) { return true; }
            return false;
        }
        public static bool isKeyDown(Keys k) {
            //returns true if the key is down this tick and last tick
            if (currentState[k] == KeyState.Down && oldState[k] == KeyState.Down) { return true; }
            return false;
        }
        public static bool isKeyUp(Keys k) {
            //returns true if the key is up this tick and last tick
            if (currentState[k] == KeyState.Up && oldState[k] == KeyState.Up) { return true; }
            return false;
        }
        public static bool isKeyReleased(Keys k) {
            //returns true if the key is up this tick and not last tick
            if (currentState[k] == KeyState.Up && oldState[k] == KeyState.Down) { return true; }
            return false;
        }
    }
}
