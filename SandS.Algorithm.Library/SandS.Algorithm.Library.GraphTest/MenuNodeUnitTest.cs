using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.Graph;
using SandS.Algorithm.Library.Menu;
using Xunit;

namespace SandS.Algorithm.Library.GraphTest
{
    public class MenuNodeUnitTest
    {
        public MenuNode<MenuNodeBody> NewMenuNode
        {
            get
            {
                MenuNode<MenuNodeBody> head = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head, "HEAD", new Drawable(null), new Rectangle()))
                {
                    Color = GraphNodeColor.Grey
                };

                MenuNode<MenuNodeBody> node0 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node1", new Drawable(null), new Rectangle()));
                MenuNode<MenuNodeBody> node1 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node2", new Drawable(null), new Rectangle()));
                MenuNode<MenuNodeBody> node2 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node3", new Drawable(null), new Rectangle()));

                head.Children.Add(node0);
                head.Children.Add(node1);
                head.Children.Add(node2);

                return head;
            }
        }

        #region correct

        [Fact]
        public void CreateTestMenuNodeMustNotThrowArgExc()
        {
            MenuNode<MenuNodeBody> node = this.NewMenuNode;
        }

        [Fact]
        public void CtorMustInit()
        {
            MenuNode<MenuNodeBody> node = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node1", new Drawable(null), new Rectangle()));

            Assert.NotNull(node.Body);
            Assert.NotNull(node.Body.Text);
            Assert.NotNull(node.Body.Rectangle);
            Assert.NotNull(node.Body.Drawable);
            Assert.NotNull(node.Children);

            Assert.Equal(0, node.Children.Count);
        }

        #endregion correct
    }
}