using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus
{
    internal sealed class WrappedReadOnlyList<T, TWrapped> : IReadOnlyList<T> where T : class, IWrapping<TWrapped>
    {
        private readonly ReadOnlyMemory<TWrapped> _wrappedItems;
        private readonly Func<int, TWrapped, T> _converter;
        private readonly T?[] _items;

        public WrappedReadOnlyList(ReadOnlyMemory<TWrapped> wrappedItems, Func<int, TWrapped, T> converter)
        {
            Debug.Assert(converter != null);

            _wrappedItems = wrappedItems;
            _converter = converter;
            _items = new T?[wrappedItems.Length];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException($"Index out of range (expected: 0 to {Count - 1})");
                }

                var wrappedItem = _wrappedItems.Span[index];
                ref var item = ref _items[index];
                if (item is null || !ReferenceEquals(item.Wrapped, wrappedItem))
                {
                    item = _converter(index, wrappedItem);
                }

                return item;
            }
        }

        public int Count => _items.Length;

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; ++i)
            {
                yield return this[i];
            }
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
