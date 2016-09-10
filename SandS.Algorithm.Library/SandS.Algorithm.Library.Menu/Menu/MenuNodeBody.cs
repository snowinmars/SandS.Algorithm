using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SandS.Algorithm.Library.PositionNamespace;
using SandS.Algorithm.Library.StorageNamespace;
using System;

namespace SandS.Algorithm.Library.MenuNamespace
{
    public class MenuNodeBody : IUpdateable
    {
        public MenuNodeBody(MenuNodeType nodeType, string text, Drawable drawable, Position position, int shift)
        {
            this.NodeType = nodeType;
            this.Text = text;
            this.Drawable = drawable;
            this.Size = FontStorage.Instance.Get(FontType.Default).MeasureString(this.Text).ToPoint();
            this.Position = this.Shift(position.Clone(), shift);
            this.Rectangle = new Rectangle(this.Position.ToPoint(), this.Size);

            this.ClickableItem = new ClickableItem(this.Rectangle);
        }

        private Position Shift(Position position, int shift)
        {
            position.Y += this.Size.Y * shift;

            return position;
        }

        public string Text { get; set; }

        public Drawable Drawable { get; set; }

        public MenuNodeType NodeType { get; set; }

        public Position Position { get; set; }

        public Point Size { get; }

        public Rectangle Rectangle { get; set; }

        public ClickableItem ClickableItem { get; set; }

        #region IDrawable

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
            this.ClickableItem.Update();
        }

        #endregion IUpdateable
    }
}