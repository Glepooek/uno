#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;

namespace Windows.Storage.Pickers
{
	/// <summary>
	/// Represents a collection of display names mapped to the associated file types (extensions).
	/// Each element in this collection maps a display name to a corresponding collection of file name extensions.
	/// The key is a single string, the value is a list/vector of strings representing one or more extension choices.
	/// </summary>
	public partial class FilePickerFileTypesOrderedMap : IDictionary<string, IList<string>>, IEnumerable<KeyValuePair<string, IList<string>>>
	{
		private readonly Dictionary<string, IList<string>> _items = new Dictionary<string, IList<string>>();

		internal FilePickerFileTypesOrderedMap()
		{
		}

		public uint Size => (uint)_items.Count;

		public void Add(string key, IList<string> value) => _items.Add(key, value);

		public bool ContainsKey(string key) => _items.ContainsKey(key);

		public bool Remove(string key) => _items.Remove(key);

		public bool TryGetValue(string key, out IList<string> value) => _items.TryGetValue(key, out value);

		public IList<string> this[string key]
		{
			get => _items[key];
			set => _items[key] = value;
		}

		public ICollection<string> Keys
		{
			get => _items.Keys;
			set => throw new InvalidOperationException();
		}
		public ICollection<IList<string>> Values
		{
			get => _items.Values;
			set => throw new InvalidOperationException();
		}

		public void Add(KeyValuePair<string, IList<string>> item) => _items.Add(item.Key, item.Value);

		public void Clear() => _items.Clear();

		public bool Contains(KeyValuePair<string, IList<string>> item) => _items.TryGetValue(item.Key, out var value) && value == item.Value;

		public void CopyTo(KeyValuePair<string, IList<string>>[] array, int arrayIndex)
		{
			foreach (var item in _items)
			{
				array[arrayIndex] = item;
				arrayIndex++;
			}
		}

		public bool Remove(KeyValuePair<string, IList<string>> item) => _items.Remove(item.Key);

		public int Count
		{
			get => _items.Count;
			set => throw new InvalidOperationException();
		}

		public bool IsReadOnly
		{
			get => false;
			set => throw new InvalidOperationException();
		}

		public IEnumerator<KeyValuePair<string, IList<string>>> GetEnumerator() => _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();		
	}
}
