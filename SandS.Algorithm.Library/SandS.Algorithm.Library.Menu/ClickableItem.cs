using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SandS.Algorithm.Library.StorageNamespace;
using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.MenuNamespace
{
    public enum VisibleState
    {
        Normal = 0,
        Pressed = 1,
        Hover = 2,
    }

    public class ClickableItem
    {
        /// <summary>
        /// Init it with MonogameStock dictionaries, using SetTextures() method
        /// </summary>
        private Dictionary<VisibleState, Texture2D> textures;

        private VisibleState currentVisibleState = VisibleState.Normal;
        private VisibleState previousVisibleState = VisibleState.Normal;
        private MouseState currentMouseState;
        private MouseState previousMouseState;

        public ClickableItem(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
            this.textures = new Dictionary<VisibleState, Texture2D>();
        }

        /// <summary>
        /// Set textures with this methods.
        /// </summary>
        /// <param name="dict"></param>
        public void SetTextures(Dictionary<VisibleState, Texture2D> dict)
        {
            this.textures = dict; // due to I wanna all cells have same copy of textures.
        }

        public event EventHandler MouseClick;

        public event EventHandler MouseDown;

        public event EventHandler MouseOut;

        public event EventHandler MouseUp;

        private Rectangle Rectangle { get; set; }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(TextureStorage.Instance.Get(TextureType.Default), this.Rectangle, Color.Wheat);
        }

        public virtual void Update()
        {
            this.previousVisibleState = this.currentVisibleState;
            this.previousMouseState = this.currentMouseState;

            this.currentMouseState = Mouse.GetState();

            if (this.Rectangle.Contains(this.currentMouseState.X, this.currentMouseState.Y))
            {
                if (this.currentMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (this.previousMouseState.LeftButton == ButtonState.Released)
                    {
                        this.OnMouseDown(EventArgs.Empty);
                        this.currentVisibleState = VisibleState.Pressed;
                    }
                    else
                    {
                        if (this.currentVisibleState != VisibleState.Pressed)
                        {
                            this.currentVisibleState = VisibleState.Hover;
                        }
                    }
                }
                else
                {
                    if (this.previousVisibleState == VisibleState.Pressed)
                    {
                        this.OnMouseClick(EventArgs.Empty);
                    }

                    this.currentVisibleState = VisibleState.Hover;
                }
            }
            else
            {
                if (this.previousVisibleState == VisibleState.Hover ||
                    this.previousVisibleState == VisibleState.Pressed)
                {
                    this.OnMouseOut(EventArgs.Empty);
                }

                this.currentVisibleState = VisibleState.Normal;
            }

            if (this.currentMouseState.LeftButton == ButtonState.Released &&
                this.previousVisibleState == VisibleState.Pressed)
            {
                this.OnMouseUp(EventArgs.Empty);
            }
        }

        private void OnMouseClick(EventArgs e)
        {
            this.MouseClick?.Invoke(this, e);
        }

        private void OnMouseDown(EventArgs e)
        {
            this.MouseDown?.Invoke(this, e);
        }

        private void OnMouseOut(EventArgs e)
        {
            this.MouseOut?.Invoke(this, e);
        }

        private void OnMouseUp(EventArgs e)
        {
            this.MouseUp?.Invoke(this, e);
        }
    }
}