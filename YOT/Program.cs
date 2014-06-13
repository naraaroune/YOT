/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 13/06/2014
 * Time: 14:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace YOT
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Entrez le chemin d'une Dll");
			string pathDll=Console.ReadLine();
			
			var runner= new Runner(pathDll);
			
			runner.StartTestRunner();
			 			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}