using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace SudoExtension
{
	class Program
	{
		static void Main(string[] args)
		{
			string command;
			string[] comArgs = new string[args.Length - 1];
			Array.Copy(args, 1, comArgs, 0, comArgs.Length);

			if(File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + args[0]))
			{
				command = Environment.CurrentDirectory + Path.DirectorySeparatorChar + args[0];
			}
			else
			{
				command = args[0];
			}

			var process = Process.Start(new ProcessStartInfo()
			{
				FileName = command,
				Arguments = string.Join(" ", comArgs),
				WorkingDirectory = Environment.CurrentDirectory,
				Verb = "runas",
				UseShellExecute = true
			});

			process.WaitForExit();
		}
	}
}
