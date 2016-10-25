﻿using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.GraphNamespace
{
    public interface IHasGraphTree<TGraphnode, TBody>
        where TGraphnode : GraphNode<TBody>
    {

        void AddNode(TGraphnode node);

        void Connect(TGraphnode lhs, TGraphnode rhs);

        bool IsCycle(bool haveClearColor = true);

        bool IsLooped();

        bool IsNonConnectivity();

        bool IsRouteBetween(TGraphnode startNode, TGraphnode endNode);

        void RemoveNode(TGraphnode node);
    }
}