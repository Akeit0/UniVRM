using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine.Pool;


namespace UniJSON
{
    public static class JsonParser
    {
        private static readonly ConcurrentBag<List<JsonValue>> listPool = new ConcurrentBag<List<JsonValue>>();
        static ValueNodeType GetValueType(ReadOnlySpan<byte> segment)
        {
            switch (Char.ToLower((char)segment[0]))
            {
                case '{': return ValueNodeType.Object;
                case '[': return ValueNodeType.Array;
                case '"': return ValueNodeType.String;
                case 't': return ValueNodeType.Boolean;
                case 'f': return ValueNodeType.Boolean;
                case 'n':
                    if (segment.Length >= 2 && ((char)segment[1]) is 'a'or 'A')
                    {
                        return ValueNodeType.NaN;
                    }

                    return ValueNodeType.Null;

                case 'i':
                    return ValueNodeType.Infinity;

                case '-':
                    if (segment.Length >= 2 && ((char)segment[1]) is 'i' or 'I')
                    {
                        return ValueNodeType.MinusInfinity;
                    }
                    goto case '0';// fall through
                case '0': // fall through
                case '1': // fall through
                case '2': // fall through
                case '3': // fall through
                case '4': // fall through
                case '5': // fall through
                case '6': // fall through
                case '7': // fall through
                case '8': // fall through
                case '9': // fall through
                    {
                        // if (segment.IsInt)
                        // {
                        //     return ValueNodeType.Integer;
                        // }
                        // else
                        {
                            return ValueNodeType.Number;
                        }
                    }

                default:
                    throw new ParserException(Utf8String.Encoding.GetString(segment) + " is not valid json start(maybe invalid ',')");
            }
        }

        /// <summary>
        /// Expected null, boolean, integer, number
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="valueType"></param>
        /// <param name="parentIndex"></param>
        /// <returns></returns>
        static JsonNode ParsePrimitive(JsonNode tree, Utf8String segment, ValueNodeType valueType)
        {
            int i = 1;
            var span = segment.AsSpan();
            for (; i < span.Length; ++i)
            {
                var c  = (char)span[i];
                if (Char.IsWhiteSpace(c)
                    || c is  '}' or  ']'or ',' or ':'
                    )
                {
                    break;
                }
            }
            return tree.AddValue(segment.Subbytes(0, i).Bytes, valueType);
        }

        static JsonNode ParseString(JsonNode tree, Utf8String segment)
        {
            int pos;
            if (segment.TrySearchDoubleQuote(1, out pos))
            {
                return tree.AddValue(segment.Subbytes(0, pos + 1).Bytes, ValueNodeType.String);
            }
            else
            {
                throw new ParserException("no close string: " + segment);
            }
        }

        static JsonNode ParseArray(JsonNode tree, Utf8String segment)
        {
            var array = tree.AddValue(segment.Bytes, ValueNodeType.Array);

            const byte closeChar = (byte)']';
            bool isFirst = true;
            var current = segment.Subbytes(1);
            while (true)
            {
                {
                    // skip white space
                    int nextToken;
                    if (!current.TrySearchUnWhiteSpace(out nextToken))
                    {
                        throw new ParserException("no white space expected");
                    }
                    current = current.Subbytes(nextToken);
                }

                {
                    if (current[0] == closeChar)
                    {
                        // end
                        break;
                    }
                }

                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    // search ',' or closeChar
                    int keyPos;
                    if (!current.TrySearchByte((byte)',', out keyPos))
                    {
                        throw new ParserException("',' expected");
                    }
                    current = current.Subbytes(keyPos + 1);
                }

                {
                    // skip white space
                    int nextToken;
                    if (!current.TrySearchUnWhiteSpace(out nextToken))
                    {
                        throw new ParserException("not whitespace expected");
                    }
                    current = current.Subbytes(nextToken);
                }

                // value
                var child = Parse(array, current);
                current = current.Subbytes(child.Value.Segment.ByteLength);
            }

            // fix array range
            var count = current.Bytes.Offset + 1 - segment.Bytes.Offset;
            array.SetValueBytesCount(count);
            
            return array;
        }

        static JsonNode ParseObject(JsonNode tree, Utf8String segment)
        {
            var obj = tree.AddValue(segment.Bytes, ValueNodeType.Object);

            const char closeChar = '}';
            bool isFirst = true;
            var current = segment.Subbytes(1);
            while (true)
            {
                {
                    // skip white space
                    int nextToken;
                    if (!current.TrySearchUnWhiteSpace(out nextToken))
                    {
                        throw new ParserException("no white space expected");
                    }
                    current = current.Subbytes(nextToken);
                }

                {
                    if (current[0] == closeChar)
                    {
                        break;
                    }
                }

                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    // search ',' or closeChar
                    int keyPos;
                    if (!current.TrySearchByte((byte)',', out keyPos))
                    {
                        throw new ParserException("',' expected");
                    }
                    current = current.Subbytes(keyPos + 1);
                }

                {
                    // skip white space
                    int nextToken;
                    if (!current.TrySearchUnWhiteSpace( out nextToken))
                    {
                        throw new ParserException("not whitespace expected");
                    }
                    current = current.Subbytes(nextToken);
                }

                // key
                var key = Parse(obj, current);
                if (!key.IsString())
                {
                    throw new ParserException("object key must string: " + key.Value.Segment);
                }
                current = current.Subbytes(key.Value.Segment.ByteLength);

                // search ':'
                int valuePos;
                if (!current.TrySearchByte((byte) ':', out valuePos))
                {
                    throw new ParserException(": is not found");
                }
                current = current.Subbytes(valuePos + 1);

                {
                    // skip white space
                    int nextToken;
                    if (!current.TrySearchUnWhiteSpace( out nextToken))
                    {
                        throw new ParserException("not whitespace expected");
                    }
                    current = current.Subbytes(nextToken);
                }

                // value
                var value = Parse(obj, current);
                current = current.Subbytes(value.Value.Segment.ByteLength);
            }

            // fix obj range
            var count = current.Bytes.Offset + 1 - segment.Bytes.Offset;
            obj.SetValueBytesCount(count);

            return obj;
        }

        public static JsonNode Parse(JsonNode tree, Utf8String segment)
        {
            // skip white space
            int pos;
            if (!segment.TrySearchUnWhiteSpace( out pos))
            {
                throw new ParserException("only whitespace");
            }
            segment = segment.Subbytes(pos);

            var valueType = GetValueType(segment.AsSpan());
            switch (valueType)
            {
                case ValueNodeType.Boolean:
                case ValueNodeType.Integer:
                case ValueNodeType.Number:
                case ValueNodeType.Null:
                case ValueNodeType.NaN:
                case ValueNodeType.Infinity:
                case ValueNodeType.MinusInfinity:
                    return ParsePrimitive(tree, segment, valueType);

                case ValueNodeType.String:
                    return ParseString(tree, segment);

                case ValueNodeType.Array: // fall through
                    return ParseArray(tree, segment);

                case ValueNodeType.Object: // fall through
                    return ParseObject(tree, segment);

                default:
                    throw new NotImplementedException();
            }
        }

        public static JsonNode Parse(String json)
        {
            return Parse(Utf8String.From(json));
        }

        public static JsonNode Parse(Utf8String json)
        {
            //return Parse(default, json);
            const int bufferSize = 1 << 15;
            if (!listPool.TryTake(out var list))
            {
               list = new List<JsonValue>(bufferSize);
            }
            var node= Parse(new JsonNode(list,-1), json);
            var shrunk = new List<JsonValue>(list);
            list.Clear();
            listPool.Add(list);
            return new  JsonNode(shrunk, node.ValueIndex);
        }
    }
}
