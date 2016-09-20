using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.StorageNamespace
{
    public class FontStorage : IFontStorage
    {
        #region singleton

        protected FontStorage()
        {
        }

        private static readonly Lazy<FontStorage> instance = new Lazy<FontStorage>(() => new FontStorage());

        public static FontStorage Instance => FontStorage.instance.Value;

        #endregion singleton

        private ContentManager ContentManager { get; set; }
        private IDictionary<FontType, SpriteFont> FontDictionary { get; set; }

        public void Initialize(ContentManager contentManager)
        {
            this.ContentManager = contentManager;
            this.FontDictionary = new Dictionary<FontType, SpriteFont>();

            this.FontDictionary.Add(FontType.Default, this.ContentManager.Load<SpriteFont>("fonts/PTSans14"));
        }

        public SpriteFont Get(FontType fontType)
            => this.FontDictionary[fontType];
    }
}