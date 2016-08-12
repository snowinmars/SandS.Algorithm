using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SandS.Algorithm.Library.MenuNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using System.Reflection;

namespace SandS.Algorithm.Library.Menu
{
    public class MenuNodeBodyBuilder : IBuilder<MenuNodeBody>
    {
        private MenuNodeType menuNodeType;
        private string text;
        private Drawable drawable;
        private Position position;
        private int shift;
        private EventHandler action;

        private bool isCreateNew;
        private MenuNodeBody body;

        public MenuNodeBody Build()
        {
            MenuNodeBody body = new MenuNodeBody(this.menuNodeType,
                                                    this.text,
                                                    this.drawable,
                                                    this.position,
                                                    this.shift);

            body.ClickableItem.MouseClick += this.action;

            return body;
        }

        public MenuNodeBodyBuilder SetBasic(MenuNodeType menuNodeType)
        {
            this.menuNodeType = menuNodeType;

            return this;
        }

        public MenuNodeBodyBuilder SetPosition(Position position, int shift)
        {
            this.position = position;
            this.shift = shift;

            return this;
        }

        public MenuNodeBodyBuilder SetBehavior(EventHandler action)
        {
            this.action = action;

            return this;
        }

        public MenuNodeBodyBuilder SetDecoration(string text, Drawable drawable)
        {
            this.text = text;
            this.drawable = drawable;

            return this;
        }

        public MenuNodeBodyBuilder WorkWith(MenuNodeBody body)
        {
            this.SetBasic(body.NodeType);

            Type type = body.ClickableItem.GetType();
            EventInfo eventInfo = body.ClickableItem.GetType().GetEvent("MouseClick");
            FieldInfo fieldInfo = type.GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

            if (fieldInfo != null)
            {
                Delegate fieldDelegate = ((Delegate)fieldInfo.GetValue(body.ClickableItem));
                EventHandler handler = fieldDelegate.GetInvocationList().FirstOrDefault() as EventHandler;

                this.SetBehavior(handler);
            }

            this.SetDecoration(body.Text, body.Drawable);
            this.SetPosition(body.Position, 0); // TODO

            return this;
        }
    }
}
