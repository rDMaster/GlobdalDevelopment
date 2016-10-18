using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GlobalDevelopment
{
    public static class ExtensionMethods
    {
        #region String
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static int NthIndexOf(this string target, string value, int nth)
        {
            Match m = Regex.Match(target, "((" + Regex.Escape(value) + ").*?{" + nth + "}");
            if (m.Success)
                return m.Groups[2].Captures[nth - 1].Index;
            else
                return -1;
        }
        public static string BetweenIndexes(this string target, string indexof)
        {
            return target.Substring(target.IndexOf(indexof) + 1, target.LastIndexOf(indexof) - 2);
        }
        public static string BetweenIndexes(this string target, string firstIndex, string lastIndex)
        {
            return target.Substring(target.IndexOf(firstIndex) + 1, target.LastIndexOf(lastIndex) - 1);
        }
        public static byte[] StringtoBytes(this string text)
        {
            return Encoding.ASCII.GetBytes(text);
        }
        public static int CharacterCount(this string target, char targetChar)
        {
            int count = 0;
            foreach (char c in target)
            {
                if (c == targetChar) count++;
            }
            return count;
        }
        #endregion
        #region Byte[]
        public static string BytestoString(this byte[] byteData)
        {
            return Encoding.ASCII.GetString(byteData);
        }
        #endregion
        #region Generic
        public static IEnumerable<TSource> DistinctByKey<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
        public static T[,] ToSquare2D<T>(this T[] array, int size)
        {
            var buffer = new T[(int)Math.Ceiling((double)array.Length / size), size];
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    buffer[i, j] = array[i + j];
                }
            }
            return buffer;
        }
        public static void AddUniqueItem<T>(this List<T> items, T item)
        {
            if (items.Count == 0)
            {
                items.Add(item);
            }
            else
            {
                if (items.IndexOf(item) == -1)
                {
                    items.Add(item);
                    items.DistinctByKey(p => item);
                }
            }
        }
        #endregion
        #region Socket
        public static bool IsConnected(this Socket client)
        {
            bool blockinState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException e)
            {
                if (e.NativeErrorCode.Equals(10035))
                    return true;
                else
                    return false;
            }
            finally
            {
                client.Blocking = blockinState;
            }
        }
        #endregion
        #region Http
        public static UriBuilder AddQuestString(this UriBuilder builder, Dictionary<string, string> query)
        {
            if (query == null || query.Count == 0) return builder;
            int index = 0;
            foreach (var entry in query)
            {
                if (index <= query.Count - 1)
                {
                    builder.Query += entry.Key + "=" + entry.Value + "&";
                    index++;
                }
                else
                    builder.Query += entry.Key + "=" + entry.Value;
            }
            return builder;
        }
        public static string ToString(this HttpWebResponse Response)
        {
            if (Response == null) return null;
            using (var stream = Response.GetResponseStream())
            {
                if (stream == null) return null;
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion
    }
}