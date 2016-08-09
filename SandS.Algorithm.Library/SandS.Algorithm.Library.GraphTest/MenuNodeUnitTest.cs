using Microsoft.Xna.Framework;
using SandS.Algorithm.Library.GraphNamespace;
using SandS.Algorithm.Library.MenuNamespace;
using SandS.Algorithm.Library.PositionNamespace;
using Xunit;

namespace SandS.Algorithm.Library.GraphTestNamespace
{
    public class MenuNodeUnitTest
    {
        private MenuNode<MenuNodeBody> NewMenuNode
        {
            get
            {
                MenuNode<MenuNodeBody> head = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Head, "HEAD", new Drawable(), new 
                    Position(), 0));
                MenuNode<MenuNodeBody> node0 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node1", new Drawable(), new Position(), 0));
                MenuNode<MenuNodeBody> node1 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node2", new Drawable(), new Position(), 0));
                MenuNode<MenuNodeBody> node2 = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node3", new Drawable(), new Position(), 0));

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
            MenuNode<MenuNodeBody> node = new MenuNode<MenuNodeBody>(new MenuNodeBody(MenuNodeType.Node, "node1", new Drawable(), new Position(), 0));

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