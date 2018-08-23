using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.Common.IO
{
    /// <summary>
    /// The set of various helper functions for directories, files etc.
    /// </summary>
    public static class FileUtilities
    {
        /// <summary>
        /// Enumerate a file names and directory names that that match the <paramref name="searchPattern"/> in the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="searchPattern">
        /// the search string to match against the names of file and directories in <paramref name="path" />
        /// this parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        /// but doesn't support regular expressions
        /// </param>
        /// <param name="path">the relative or absolute path to the directory to search</param>
        /// <returns>
        /// enumeration of file names and directory names that match the specified search criteria,
        /// or an empty enumeration if no files or directories are found
        /// </returns>
        public static IEnumerable<string> EnumerateTopDirectoryEntries(string searchPattern, string path)
        {
            var filePaths = Directory.GetFileSystemEntries(path, searchPattern);

            foreach (var filePath in filePaths)
                yield return filePath;
        }

        /// <summary>
        /// Enumerate a file names and directory names that that match the <paramref name="searchPattern"/> in the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="searchPattern">
        /// the search string to match against the names of file and directories in <paramref name="path" />
        /// this parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks),
        /// but doesn't support regular expressions
        /// </param>
        /// <param name="path">the relative or absolute path to the directory to search</param>
        /// <returns>
        /// enumeration of file names and directory names that match the specified search criteria,
        /// or an empty enumeration if no files or directories are found
        /// </returns>
        public static IEnumerable<string> EnumerateAllDirectoriesFiles(string searchPattern, string path)
        {
            var filePaths = Directory.GetFileSystemEntries(path, searchPattern, SearchOption.AllDirectories);

            foreach (var filePath in filePaths)
                yield return filePath;
        }

        /// <summary>
        /// Move file from <paramref name="filePath"/> to the folder <paramref name="directoryName"/>.
        /// </summary>
        /// <param name="filePath">path to source file</param>
        /// <param name="directoryName">the relative or absolute path to the directory to move</param>
        public static void MoveFile(string filePath, string directoryName)
        {
            var fileName = Path.GetFileName(filePath);

            if (fileName != null) {
                var newFilePath = Path.Combine(directoryName, fileName);
                var i = 0;

                while (File.Exists(newFilePath)) {
                    i++;
                    newFilePath = Path.Combine(
                        directoryName,
                        $"{Path.GetFileNameWithoutExtension(filePath)}_{DateTime.Today.Year:D4}_{DateTime.Today.Month:D2}_{DateTime.Today.Day:D2}_{i:D4}{Path.GetExtension(filePath)}");
                }

                File.Move(filePath, newFilePath);
            }
        }

        /// <summary>
        /// Check all files in <paramref name="directoryName"/> folder and remove duplicates based on MD5 hash value.
        /// </summary>
        /// <param name="directoryName">the relative or absolute path to the directory to remove duplicates</param>
        public static void RemoveDuplicatedFiles(string directoryName)
        {
            var filePaths = Directory.GetFileSystemEntries(directoryName);
            var existingMd5 = new HashSet<string>();

            foreach (var filePath in filePaths) {
                var newFileMd5 = CalculateMd5(filePath);

                if (existingMd5.Contains(newFileMd5)) {
                    File.Delete(filePath);

                    continue;
                }

                existingMd5.Add(newFileMd5);
            }
        }

        private static string CalculateMd5(string filePath)
        {
            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(filePath))
                return Encoding.Default.GetString(md5.ComputeHash(stream));
        }
    }
}