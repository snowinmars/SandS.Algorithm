using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Library.Enums;
using System;

namespace SandS.Algorithm.Library.Other
{
    public class KeyboardInputHelper : IUpdatable
    {
        #region Private Fields

        private KeyboardState keyboardState;
        private MouseState mouseState;
        private KeyboardState oldKeyboardState;
        private MouseState oldMouseState;

        #endregion Private Fields

        #region Public Constructors

        public KeyboardInputHelper()
        {
            this.keyboardState = Keyboard.GetState();
            this.mouseState = Mouse.GetState();

            this.InputKeyPressType = InputKeyPressType.OnUp;
        }

        #endregion Public Constructors

        #region Public Properties

        public InputKeyPressType InputKeyPressType { get; set; }

        #endregion Public Properties

        #region Public Methods

        public Position.Position GetMousePosition()
        {
            return new Position.Position(this.mouseState.X, this.mouseState.Y);
        }

        public bool WasKeyPressed(Keys key)
        {
            switch (this.InputKeyPressType)
            {
                case InputKeyPressType.OnUp:
                    return this.oldKeyboardState.IsKeyDown(key) &&
                           this.keyboardState.IsKeyUp(key);

                case InputKeyPressType.OnDown:
                    return this.oldKeyboardState.IsKeyUp(key) &&
                           this.keyboardState.IsKeyDown(key);

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool WasMouseButtonPressed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return this.WasLeftMouseButtonPressed();

                case MouseButton.Middle:
                    return this.WasMiddleMouseButtonPressed();

                case MouseButton.Right:
                    return this.WasRightMouseButtonPressed();

                default:
                    throw new ArgumentOutOfRangeException(nameof(button), button, null);
            }
        }

        public void Update(GameTime gameTime)
        {
            this.oldKeyboardState = this.keyboardState;
            this.oldMouseState = this.mouseState;

            this.keyboardState = Keyboard.GetState();
            this.mouseState = Mouse.GetState();
        }

        #endregion Public Methods

        #region Private Methods

        private bool WasLeftMouseButtonPressed()
        {
            switch (this.InputKeyPressType)
            {
                case InputKeyPressType.OnUp:
                    return this.oldMouseState.LeftButton == ButtonState.Pressed &&
                           this.mouseState.LeftButton == ButtonState.Released;

                case InputKeyPressType.OnDown:
                    return this.oldMouseState.LeftButton == ButtonState.Released &&
                           this.mouseState.LeftButton == ButtonState.Pressed;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool WasMiddleMouseButtonPressed()
        {
            switch (this.InputKeyPressType)
            {
                case InputKeyPressType.OnUp:
                    return this.oldMouseState.MiddleButton == ButtonState.Pressed &&
                           this.mouseState.MiddleButton == ButtonState.Released;

                case InputKeyPressType.OnDown:
                    return this.oldMouseState.MiddleButton == ButtonState.Released &&
                           this.mouseState.MiddleButton == ButtonState.Pressed;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool WasRightMouseButtonPressed()
        {
            switch (this.InputKeyPressType)
            {
                case InputKeyPressType.OnUp:
                    return this.oldMouseState.RightButton == ButtonState.Pressed &&
                           this.mouseState.RightButton == ButtonState.Released;

                case InputKeyPressType.OnDown:
                    return this.oldMouseState.RightButton == ButtonState.Released &&
                           this.mouseState.RightButton == ButtonState.Pressed;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion Private Methods
    }
}