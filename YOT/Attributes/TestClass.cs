/*
 * Created by SharpDevelop.
 * User: Eric NARA
 * Date: 13/06/2014
 * Time: 10:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace YOT.Attributes
{
	/// <summary>
	/// Description of TestClass.
	/// </summary>
	/// 
	[AttributeUsage(AttributeTargets.Class)]
	public class TestClass:Attribute
	{
		public TestClass()
		{
		}
	}
}
