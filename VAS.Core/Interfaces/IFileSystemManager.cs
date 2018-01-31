﻿//
//  Copyright (C) 2017 FLUENDO S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
namespace VAS.Core.Interfaces
{
	/// <summary>
	/// File system service, access to the file system alwasys trough this service
	/// Extend this service to add the necessary functionality
	/// </summary>
	public interface IFileSystemManager
	{
		/// <summary>
		/// Exists the file in the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		bool FileExists (string path);

		/// <summary>
		/// Exists the directory in the specified path.
		/// </summary>
		/// <param name="path">Path.</param>
		bool DirectoryExists (string path);

		/// <summary>
		/// Copy a whole directory to the specified.
		/// </summary>
		/// <param name="sourceDirName">Source dir name.</param>
		/// <param name="destDirName">Destination dir name.</param>
		/// <param name="copySubDirs">If set to <c>true</c> copy sub dirs.</param>
		void CopyDirectory (string sourceDirName, string destDirName, bool copySubDirs);

		/// <summary>
		/// Gets the path of the specified directory name.
		/// </summary>
		/// <param name="sourceDirName">Source dir name.</param>
		string GetDataDirPath (string dirname);
	}
}
