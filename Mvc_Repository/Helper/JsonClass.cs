using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Repository.Helper
{
    public class JsonClass
    {
        /// <summary>
        /// 檢查 JSON 驗證格式
        /// </summary>
        public string chkJson(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s.Substring(i, 1) != "")
                {
                    char c = char.Parse(s.Substring(i, 1));

                    switch (c)
                    {
                        case '\"':
                            sb.Append("\\\"");
                            break;

                        case '\\':
                            sb.Append("\\\\");
                            break;

                        case '/':
                            sb.Append("\\/");
                            break;

                        case '\b':
                            sb.Append("\\b");
                            break;

                        case '\f':
                            sb.Append("\\f");
                            break;

                        case '\n':
                            sb.Append("\\n");
                            break;

                        case '\r':
                            sb.Append("\\r");
                            break;

                        case '\t':
                            sb.Append("\\t");
                            break;

                        default:
                            sb.Append(c);
                            break;

                    }
                }
                else
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();

        }
    }
}
