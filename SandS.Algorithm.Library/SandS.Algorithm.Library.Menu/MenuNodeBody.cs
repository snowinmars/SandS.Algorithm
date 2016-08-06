using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SandS.Algorithm.Library.Storage;

namespace SandS.Algorithm.Library.Menu
{
    public class MenuNodeBody : IUpdateable, IDrawable
    {
        public MenuNodeBody(MenuNodeType nodeType, string text, Drawable drawable,  Rectangle rectangle)
        {
            this.NodeType = nodeType;
            this.Text = text;
            this.Drawable = drawable;
            this.Rectangle = rectangle;
        }

        public string Text { get; set; }

        public Drawable Drawable { get; set; }

        public MenuNodeType NodeType { get; set; }
        public Position.Position Position { get; set; }

        public Rectangle Rectangle { get; set; }

        #region IDrawable

        public void Draw(GameTime gameTime)
        {
        }

        public int DrawOrder { get; set; }

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(this.Drawable.Texture, this.Position.ToVector2(), Color.White);
            sb.DrawString(FontStorage.Instance.Get(FontType.Default), this.Text, this.Position.ToVector2(), Color.Black);
        }

        #endregion IDrawable

        #region IUpdateable

        public bool Enabled { get; set; }

        public int UpdateOrder { get; set; }

        public event EventHandler<EventArgs> EnabledChanged;

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public override string ToString()
        {
            return this.Text;
        }

        public void Update(GameTime gameTime)
        {
        }

        #endregion IUpdateable
    }
}