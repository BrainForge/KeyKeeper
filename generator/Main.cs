using System;

namespace generator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine("Введите тип \n 1 - сотрудник \n 2 - предмет");
			int n = Int16.Parse(Console.ReadLine());
			Console.WriteLine("Введите код");
			int code = Int16.Parse(Console.ReadLine()); 
			
			
		}
		

	}
}
