using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YOT.Test;

namespace YOT
{
    public class Runner
    {
    	public Assembly Dll { get; set; } 
		private List<TypeInfo> TestClasses { get; set; } 
		private List<MethodInfo> TestMethods { get; set; } 
		private Dictionary<TypeInfo, MethodInfo> DicoTests { get; set; } 
		
		private int NbTest{ get; set; } 
		private int NbSucceedTest{ get; set; } 
		private int NbFailedTest{ get; set; } 
			
			
		public Runner(string pathDll)
		{
			NbTest=0;
			NbSucceedTest=0;
			NbFailedTest=0;
			
			LoadDll(pathDll);			
			
			TestClasses = this.Dll.DefinedTypes.Where(typeInfo => typeInfo.CustomAttributes.Any(customAttributeData => customAttributeData.AttributeType.Name == "TestClass")).ToList();			
			var methods = new List<MethodInfo>();
			TestClasses.ForEach(typeInfo => typeInfo.GetMethods().ToList().ForEach(methodInfo => methods.Add(methodInfo)));
			TestMethods = methods.Where(methodInfo => methodInfo.CustomAttributes.Any(customAttributeData => customAttributeData.AttributeType.Name == "Test")).ToList();
		}
			
        public bool LoadDll(string pathDll)
		{
            try 
			{
                if (!File.Exists(pathDll) || pathDll == null) 
                    return false;

                Dll = Assembly.LoadFrom(pathDll);
                return true;
            }
            catch (Exception ex) 
			{
                Console.WriteLine(ex.Message);
                return false;
            }
        }
       
        public void StartTestRunner()
        {
        	int i = 1;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("START RUNNER TEST");
			
			foreach (MethodInfo methodInfo in TestMethods)
			{
				Console.Write("Test n°"+i);
				try
				{
					methodInfo.Invoke(Activator.CreateInstance(methodInfo.GetBaseDefinition().DeclaringType), null);
					DisplayTestSucceed(methodInfo);
					NbSucceedTest+=1;
				}
				catch(Exception ex)
				{
					DisplayTestFailed(methodInfo,ex);	
					NbFailedTest+=1;
				}
				NbTest+=1;
				i++;
			}
			if (NbFailedTest>0)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\n{0} tests found, {1} success, {2} failed",NbTest,NbSucceedTest,NbFailedTest);
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\n{0} Tests found, {1} Succeed, {2} Failed",NbTest,NbSucceedTest,NbFailedTest);
				Console.ForegroundColor = ConsoleColor.White;
			}
			Console.WriteLine("END RUNNER TEST");
			Console.ForegroundColor = ConsoleColor.Gray;
			
        }
        
		public void DisplayTestSucceed(MethodInfo methodInfo)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("TEST SUCCEED: ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(methodInfo.DeclaringType.FullName+"."+methodInfo.Name+"\n\n");
		}
        
		public void DisplayTestFailed(MethodInfo methodInfo, Exception e)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Test Failed: ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(methodInfo.DeclaringType.FullName+"."+methodInfo.Name+"\n");					
			
			FailedException failedExecption = (FailedException) e.InnerException;
			Console.WriteLine(methodInfo.Name + " verification failed");							
			Console.WriteLine("Expected : "+ failedExecption.GetExpected() +" but was : " + failedExecption.GetObtained() + " : " + failedExecption.Message); //ceci est le message d'erreur du TU s'il échoue
		}

    }
}