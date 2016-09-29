using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Library.EnumsNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using System;

namespace SandS.Algorithm.Library.OtherNamespace
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

        #region mouse

        public Position GetMousePosition()
        {
            return new Position(this.mouseState.X, this.mouseState.Y);
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

        public bool WasMouseMoved()
            => this.mouseState.X != this.oldMouseState.X ||
                this.mouseState.Y != this.oldMouseState.Y;

        public bool IsAnyMouseButtonPressed()
            => this.mouseState.LeftButton == ButtonState.Pressed ||
                this.mouseState.RightButton == ButtonState.Pressed ||
                this.mouseState.MiddleButton == ButtonState.Pressed ||
                this.mouseState.XButton1 == ButtonState.Pressed ||
                this.mouseState.XButton2 == ButtonState.Pressed;

        #endregion mouse

        #region keyboard

        public bool WasKeyReleased(Keys key)
            => this.oldKeyboardState.IsKeyDown(key) &&
                this.keyboardState.IsKeyUp(key);

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
                throw new ArgumentOutOfRangeException(nameof(this.InputKeyPressType), this.InputKeyPressType, null);
            }
        }

        public bool IsKeyDown(Keys key)
            => this.keyboardState.IsKeyDown(key);

        public bool IsKeyUp(Keys key)
            => this.keyboardState.IsKeyUp(key);

        public bool IsShiftDown()
            => this.keyboardState.IsKeyDown(Keys.LeftShift) ||
                this.keyboardState.IsKeyDown(Keys.RightShift);

        public bool IsShiftUp()
            => this.keyboardState.IsKeyUp(Keys.LeftShift) ||
                this.keyboardState.IsKeyUp(Keys.RightShift);

        public bool WasShiftRelease()
            => (this.oldKeyboardState.IsKeyDown(Keys.LeftShift) && this.keyboardState.IsKeyUp(Keys.LeftShift)) ||
                (this.oldKeyboardState.IsKeyDown(Keys.RightShift) && this.keyboardState.IsKeyUp(Keys.RightShift));

        public bool IsCtrlDown()
            => this.keyboardState.IsKeyDown(Keys.LeftControl) ||
                this.keyboardState.IsKeyDown(Keys.RightControl);

        public bool IsCtrlUp()
            => this.keyboardState.IsKeyUp(Keys.LeftControl) ||
                this.keyboardState.IsKeyUp(Keys.RightControl);

        public bool WasCtrlRelease()
            => (this.oldKeyboardState.IsKeyDown(Keys.LeftControl) && this.keyboardState.IsKeyUp(Keys.LeftControl)) ||
                (this.oldKeyboardState.IsKeyDown(Keys.RightControl) && this.keyboardState.IsKeyUp(Keys.RightControl));

        public bool IsAltDown()
            => this.keyboardState.IsKeyDown(Keys.LeftAlt) ||
                this.keyboardState.IsKeyDown(Keys.RightAlt);

        public bool IsAltUp()
            => this.keyboardState.IsKeyUp(Keys.LeftAlt) ||
                this.keyboardState.IsKeyUp(Keys.RightAlt);

        public bool WasAltRelease()
            => (this.oldKeyboardState.IsKeyDown(Keys.LeftAlt) && this.keyboardState.IsKeyUp(Keys.LeftAlt)) ||
                (this.oldKeyboardState.IsKeyDown(Keys.RightAlt) && this.keyboardState.IsKeyUp(Keys.RightAlt));

        public bool WasAnyKeyPressed()
            => this.keyboardState.GetPressedKeys().Length > 0;

        public bool WasAnyKeyFreshPressed()
            => this.oldKeyboardState.GetPressedKeys().Length == 0 &&
                this.keyboardState.GetPressedKeys().Length > 0;

        #endregion keyboard

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
                throw new ArgumentOutOfRangeException(nameof(this.InputKeyPressType), this.InputKeyPressType, null);
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
                throw new ArgumentOutOfRangeException(nameof(this.InputKeyPressType), this.InputKeyPressType, null);
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
                throw new ArgumentOutOfRangeException(nameof(this.InputKeyPressType), this.InputKeyPressType, null);
            }
        }

        #endregion Private Methods
    }
}