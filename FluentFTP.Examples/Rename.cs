﻿using System;
using System.Net;
using FluentFTP;
using System.IO;

namespace Examples {
	internal static class RenameExample {
		public static void Rename() {
			using (var conn = new FtpClient()) {
				conn.Host = "localhost";
				conn.Credentials = new NetworkCredential("ftptest", "ftptest");

				// renaming a directory is dependant on the server! if you attempt it
				// and it fails it's not because FluentFTP has a bug!
				conn.Rename("/full/or/relative/path/to/src", "/full/or/relative/path/to/dest");
			}
		}
	}
}