﻿using System;
using System.Net;
using FluentFTP;

namespace Examples {
	internal static class GetListingExample {
		public static void GetListing() {
			using (var conn = new FtpClient()) {
				conn.Host = "localhost";
				conn.Credentials = new NetworkCredential("ftptest", "ftptest");

				foreach (var item in conn.GetListing(conn.GetWorkingDirectory(),
					FtpListOption.Modify | FtpListOption.Size)) {
					switch (item.Type) {
						case FtpFileSystemObjectType.Directory:
							break;

						case FtpFileSystemObjectType.File:
							break;

						case FtpFileSystemObjectType.Link:

							// derefernece symbolic links
							if (item.LinkTarget != null) {
								// see the DereferenceLink() example
								// for more details about resolving links.
								item.LinkObject = conn.DereferenceLink(item);

								if (item.LinkObject != null) {
									// switch (item.LinkObject.Type)...
								}
							}

							break;
					}
				}

				// same example except automatically dereference symbolic links.
				// see the DereferenceLink() example for more details about resolving links.
				foreach (var item in conn.GetListing(conn.GetWorkingDirectory(),
					FtpListOption.Modify | FtpListOption.Size | FtpListOption.DerefLinks)) {
					switch (item.Type) {
						case FtpFileSystemObjectType.Directory:
							break;

						case FtpFileSystemObjectType.File:
							break;

						case FtpFileSystemObjectType.Link:
							if (item.LinkObject != null) {
								// switch (item.LinkObject.Type)...
							}

							break;
					}
				}
			}
		}
	}
}