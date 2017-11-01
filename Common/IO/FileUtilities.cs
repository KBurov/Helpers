using System;
using System.Collections.Generic;
using System.IO;

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
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="doneDirectory"></param>
        public static void MoveDoneFile(string path, string doneDirectory)
        {
            var fileName = Path.GetFileName(path);

            if (fileName != null) {
                var newFilePath = Path.Combine(doneDirectory, fileName);
                var i = 0;

                while (File.Exists(newFilePath)) {
                    i++;
                    newFilePath = Path.Combine(
                        doneDirectory,
                        $"{Path.GetFileNameWithoutExtension(path)}_{DateTime.Today.Year:D4}_{DateTime.Today.Month:D2}_{DateTime.Today.Day:D2}_{i:D4}{Path.GetExtension(path)}");
                }

                File.Move(path, newFilePath);
            }
        }
    }
}