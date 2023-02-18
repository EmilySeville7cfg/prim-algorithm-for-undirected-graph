using System;
using System.Collections.Generic;

namespace Graph
{
    public class Vertex<TValue>
    {
        public TValue Value
        {
            get => value;
            set => this.value = value ?? throw new ArgumentNullException("Value", "Vertex can't contain null");
        }

        public Vertex(TValue value) => Value = value;

        public Vertex(TValue value, IEnumerable<Vertex<TValue>> adjacentVertices) : this(value)
        {
            if (adjacentVertices is null)
                throw new ArgumentNullException(nameof(adjacentVertices), "Adjacent vertices can't be null");

            foreach (var adjacentVertex in adjacentVertices)
            {
                if (adjacentVertex is null)
                    throw new ArgumentException("Adjacent vertices can't be null", nameof(adjacentVertices));
                if (!this.adjacentVertices.Add(adjacentVertex))
                    throw new ArgumentException("Adjacent vertices can't be duplicated", nameof(adjacentVertices));
            }
        }

        public override string ToString() => value.ToString();

        private readonly HashSet<Vertex<TValue>> adjacentVertices = new();
        private TValue value;
    }
}
