using QuickFix;
using QuickFix.DataDictionary;
using QuickFix.Fields;
using System.Text;

namespace AcceptorFix
{
    public static class MessageDecoder
    {
        public static string Decode(this Message message, DataDictionary dataDictionary)
        {
            return DecodeMessage(message, dataDictionary);
        }

        public static string DecodeMessage(Message message, DataDictionary dataDictionary)
        {
            var messageStr = new StringBuilder();
            //var messageStr = new StringBuilder("{");

            var msgType = message.Header.GetString(Tags.MsgType);

            DecodeFieldMap(" ", dataDictionary, messageStr, msgType, message.Header);
            DecodeFieldMap(" ", dataDictionary, messageStr, msgType, message);
            DecodeFieldMap(" ", dataDictionary, messageStr, msgType, message.Trailer);

            //messageStr.Append("}");
            string messageReturn = messageStr.ToString().Remove(messageStr.Length - 1, 1).Remove(0, 1);

            return messageStr.ToString();
        }

        private static void DecodeFieldMap(string prefix, DataDictionary dd, StringBuilder str, string msgType, FieldMap fieldMap)
        {

            foreach (var kvp in fieldMap)
            {
                
                if (dd.IsGroup(msgType, kvp.Key)) continue;

                var field = dd.FieldsByTag[kvp.Key];

                var value = fieldMap.GetString(field.Tag);
                //var value = kvp.Value.ToString();

                if (dd.FieldHasValue(field.Tag, value))
                {
                    value = $"{field.EnumDict[value]} ({value})";
                }

                str.AppendFormat("{0}{1}={2},", prefix, field.Name, value);
            }

            
            foreach (var groupTag in fieldMap.GetGroupTags())
            {
                var groupField = dd.FieldsByTag[groupTag];
                str.AppendFormat("{0}{1} (count {2}) {{\n", prefix, groupField.Name, fieldMap.GetInt(groupTag));

                for (var i = 1; i <= fieldMap.GetInt(groupTag); i++)
                {
                    var group = fieldMap.GetGroup(i, groupTag);
                    var groupPrefix = prefix + "  ";
                    str.AppendFormat("{0}{{\n", groupPrefix);
                    DecodeFieldMap(groupPrefix + "  ", dd, str, msgType, group);
                    str.AppendFormat("{0}}},\n", groupPrefix);
                }

                str.AppendFormat("{0}}};\n", prefix);
            }
            
        }
    }
}
