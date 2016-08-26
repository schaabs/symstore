﻿using System.Text;

namespace FileFormats.Minidump
{
    internal static class MinidumpReaderExtensions
    {
        public static string ReadCountedString(this Reader self, ulong position, Encoding encoding)
        {
            uint elementCount = self.Read<uint>(ref position);
            byte[] buffer = self.Read(position, elementCount);
            return encoding.GetString(buffer);
        }

        public static T[] ReadCountedArray<T>(this Reader self, ulong position)
        {
            uint elementCount = self.Read<uint>(ref position);
            var layout = self.LayoutManager.GetArrayLayout<T[]>(elementCount);
            return (T[])self.LayoutManager.GetArrayLayout<T[]>(elementCount).Read(self.DataSource, position);
        }
    }
}