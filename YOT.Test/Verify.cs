/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 13/06/2014
 * Time: 10:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace YOT.Test
{
	/// <summary>
	/// Description of Verify.
	/// </summary>
	public static class Verify
	{
		
		public static void IsTrue (bool sut, string message = null)
		{
			if(true != sut)
			{
				throw new FailedException("true",sut.ToString(),message);
			}
		}
		
		public static void IsFalse (bool sut, string message = null)
		{
			if(false != sut)
			{
				throw new FailedException("false",sut.ToString(),message);
			}
		}
		
		public static void IsNull<T> (T sut, string message = null)
		{
			if(null != sut)
			{
				throw new FailedException(default(T).ToString(),sut.ToString(),message);
			}
		}
		
		public static void IsNotNull<T> (T sut, string message = null)
		{
			if(null == sut)
			{
				throw new FailedException("not null","null",message);
			}
		}
		
		public static void AreEqual<T> (T sut, T expected, string message = null)
		{
			if(!sut.Equals(expected))
			{
				throw new FailedException(expected.ToString(),sut.ToString(), message);
			}
		}
	}
}
