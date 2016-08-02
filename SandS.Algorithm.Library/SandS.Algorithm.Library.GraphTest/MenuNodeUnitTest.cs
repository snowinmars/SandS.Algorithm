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
                MenuNode<MenuNodeBody> node = new MenuNode<MenuNodeBody>(new MenuNodeBody())
                {
                    Color = GraphNodeColor.Grey
                };

                MenuNode<MenuNodeBody> node0 = new MenuNode<MenuNodeBody>(new MenuNodeBody());
                MenuNode<MenuNodeBody> node1 = new MenuNode<MenuNodeBody>(new MenuNodeBody());
                MenuNode<MenuNodeBody> node2 = new MenuNode<MenuNodeBody>(new MenuNodeBody());

                node.Children.Add(node0);
                node.Children.Add(node1);
                node.Children.Add(node2);

                return node;
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
            MenuNode<MenuNodeBody> node = new MenuNode<MenuNodeBody>(new MenuNodeBody());

            Assert.NotNull(node.Body);
            Assert.NotNull(node.Body.Text);
            Assert.NotNull(node.Children);

            Assert.Equal(0, node.Children.Count);
        }

        #endregion correct
    }
}