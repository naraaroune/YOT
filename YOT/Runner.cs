using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YOT
{
    public class Runner
    {
        private Assembly Dll;

        public bool LoadDll(string pathdll)
		{
            try 
			{
                if (!File.Exists(pathdll) || pathdll == null) 
                    return false;

                Dll = Assembly.LoadFrom(pathdll);
                return true;
            }
            catch (Exception ex) 
			{
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
