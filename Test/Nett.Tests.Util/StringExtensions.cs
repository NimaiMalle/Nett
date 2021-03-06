﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Nett.Tests.Util
{
    [ExcludeFromCodeCoverage]
    public static class StringExtensions
    {
        public static Stream ToStream(this string s)
        {
            var ms = new MemoryStream();
            StreamWriter writer = new StreamWriter(ms);
            writer.Write(s);
            writer.Flush();
            ms.Position = 0;
            return ms;
        }

        public static string StripWhitespace(this string s) =>
            s.Replace(" ", "").Replace("\t", "").Replace("\n", "").Replace("\r", "");

        public static string NormalizeLineEndings(this string s) =>
           s.Replace("\r\n", "\n").Replace("\r", "\n");

        public static string TestRunUniqueName(this string s) => $"../../../../data/{s}_{Guid.NewGuid().ToString("N").Substring(0, 8)}";

        public static string TestRunUniqueName(this string s, string fileExtension) => s.TestRunUniqueName() + fileExtension;
    }
}
