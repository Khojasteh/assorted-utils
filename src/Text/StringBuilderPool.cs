using Assorted.Utils.Collections;
using System.Text;

namespace Assorted.Utils.Text
{
    /// <summary>
    /// Defines a pool of reusable <see cref="StringBuilder"/> objects.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public static class StringBuilderPool
    {
        /// <summary>
        /// Gets the pool of <see cref="StringBuilder"/> objects.
        /// </summary>
        public static ObjectPool<StringBuilder> Instance { get; }
            = new ObjectPool<StringBuilder>(2, () => new StringBuilder(), sb => sb.Length = 0);
    }
}
