using System;
using System.Runtime.InteropServices;

namespace RegExTester
{
	/// <summary>
	/// Class by Corrado Cavalli, found on UGIDOTNET.ORG
	/// </summary>
	public class CLRInfos
	{
		//API declares
		[DllImport("mscoree.dll")] static extern Int32 GetCORSystemDirectory ([MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder buffer,Int32 buflen, ref Int32 numbytes);
		[DllImport("mscoree.dll")] static extern Int32 GetCORVersion ([MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder buffer,Int32 buflen, ref Int32 numbytes); 
		static public String SystemDirectory()
		{
			System.Text.StringBuilder buf=new System.Text.StringBuilder(1024);
			Int32 iBytes=0;
			Int32 ret= GetCORSystemDirectory(buf,buf.Capacity, ref iBytes);
			return buf.ToString().Substring(0,iBytes-1);
		}
		public static string Version()
		{
			System.Text.StringBuilder buf = new System.Text.StringBuilder(1024);
			Int32 iBytes=0;
			Int32 ret= GetCORVersion(buf,buf.Capacity, ref iBytes);
			return buf.ToString().Substring(0,iBytes-1); 
		}
	} 
}
