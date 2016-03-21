using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// This class formats string.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Creates cryptographic algorithm.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>MD5 hash code</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Check if the string value is true or false. The true values are: "true", "ok", "yes", "1" and "да". 
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>true or false</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Converts string numeric value to short value (Int16).
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>short value type</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Converts string numeric value to integer value (Int32).
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>integer value type</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Converts string numeric value to long value (Int64).
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>long value type</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Converts string to datetime.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>datetime structure</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalize the first letter.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>string</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Returns string values by given start and end position. 
    /// If two, three, etc. letters with same value are adjacent to each other (ex. "aaabs"), 
    /// use 'startFrom' to determine from which letter to start count.
    /// </summary>
    /// <param name="input">string value</param>
    /// <param name="startString">start position</param>
    /// <param name="endString">end position</param>
    /// <param name="startFrom">determine start position</param>
    /// <returns>string value</returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition =
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Converts Bulgarian characters to Latin characters.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>string value</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
                "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Converts Latin keybord characters to Bulgarian keybord characters.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>string value</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Returns only latin letters, numbers, underscores and dots - removes all other non-letter and non-numeric characters.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>string value - only latin letters, numbers, underscore and dot</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Returns only latin letters, numbers, underscores, dots and dashes - removes all other non-letter and non-numeric characters.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>string value - only latin letters, numbers, underscore, dot and dash</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Get first characters from a string.
    /// </summary>
    /// <param name="input">string value</param>
    /// <param name="charsCount">number of characters to be displayed</param>
    /// <returns>string value</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Returns file extension.
    /// </summary>
    /// <param name="fileName">string value</param>
    /// <returns>string value</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Enter file extension and find it location.
    /// </summary>
    /// <param name="fileExtension">string value</param>
    /// <returns>string value - file extension location</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Converts string value to it byte value.
    /// </summary>
    /// <param name="input">string value</param>
    /// <returns>byte array</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}