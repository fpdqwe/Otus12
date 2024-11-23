namespace Otus12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dict = new OtusDictionary();
			for(int i = 0; i < 32; i++)
			{
				dict.Add(i, $"value #{i}");
			}
			// dict.PrintValues();
			for(int i = 0; i < 32; i++)
			{
				Console.WriteLine($"Got value #{i} from collection: {dict.Get(i)}");
			}
		}
	}
}
