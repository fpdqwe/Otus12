namespace Otus12
{
	public class OtusDictionary
	{
		private string[] _values;
		private int _size;
        public OtusDictionary(int capacity = 32)
        {
			_values = new string[capacity];
			_size = 0;
        }
        public void Add(int key, string value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value), "Value cannot be null");
			
			// Resize when array of values is full
			if (_size >= _values.Length) Resize();

			// Hash calc
			int index = key % _values.Length;
			Console.WriteLine($"Adding element ({key},{value}): hash = key % capacity ({index} = {key} % {_values.Length})");

			// Collisions solution recursive
			if (_values[index] != null)
			{
				Resize();
				Add(key, value);
				return;
			}

			_values[key] = value;
			_size++;
		}
		public string Get(int key)
		{
			int index = key % _values.Length;
			var result = _values[index];
			return _values[index];
		}
		public void PrintValues()
		{
			for(int i = 0; i < _values.Length - 1; i++)
			{
				if (_values[i] != null)
				{
					Console.WriteLine($"Value in bucket {i}: {_values[i]}");
				}
			}
		}
		private void Resize()
		{
			var currentCollection = _values.ToArray();
			_values = new string[_values.Length * 2];
			_size = 0;
			
			for (int i = 0; i < currentCollection.Length - 1; i++)
			{
				if (currentCollection[i] != null)
				{
					Add(i, currentCollection[i]);
				}
			}
		}
	}
}
