/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 13/06/2014
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace YOT.Test
{
	/// <summary>
	/// Description of FailedException.
	/// </summary>
	public class FailedException:Exception
	{
		private string expected, obtained;
			
		
		public FailedException(string expected, string obtained, string message) : base(message) 
		{
			this.expected = expected;
			this.obtained= obtained;
		}
		
		public string GetExpected()
		{
			return expected;
		}
		
		public string GetObtained()
		{
			return obtained;
		}
	}
}



