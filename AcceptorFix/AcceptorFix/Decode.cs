using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;
using System.Text;

namespace AcceptorFix
{
    public class Decode
    {
        public static string Message(Message message, DataDictionary dataDictionary)
        {
            var sb = new StringBuilder();
            string str = message.ToString().Replace("\u0001", "|");
            var msgType = message.Header.GetString(Tags.MsgType);

            string[] strSplit = str.Split('|');

            for(var x = 0; x < strSplit.Length - 1; x++)
            {
                string[] split = strSplit[x].Split('=');

                if (dataDictionary.IsGroup(msgType, Int32.Parse(split[0]))) continue;

                var field = dataDictionary.FieldsByTag[Int32.Parse(split[0])];

                var value = split[1];

                if (dataDictionary.FieldHasValue(field.Tag, split[1]))
                {
                    value = $"{field.EnumDict[value]}({value})";
                }

                sb.Append(field.Name + "=" + value + ", ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}

/*
using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;
using System.Text;

namespace AcceptorFix
{
    public class DecodificaMensagem
    {
        public static string Decodifica(Message message, DataDictionary dataDictionary)
        {
            string str = message.ToString().Replace("\u0001", "|"); 
            var msgType = message.Header.GetString(Tags.MsgType);
            var ret = new List<string>();

            foreach (var item in str.Remove(str.Length-1,1).Split('|'))
            {
                string[] split = item.Split('=');

                var tag = Int32.Parse(split[0]);

                if (dataDictionary.IsGroup(msgType, tag))
                    continue; //vc deveria tratar os grupos

                var field = dataDictionary.FieldsByTag[tag];
                var value = split[1];

                if (dataDictionary.FieldHasValue(field.Tag, value))
                {
                    value = $"{field.EnumDict[value]}({value})";
                }

                ret.Add(field.Name + "=" + value);
            }

            return String.Join(", ", ret);
        }
    }
}
*/

