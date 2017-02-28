using System;

namespace BotOnBot.BotConnect
{
    internal static class EnumParser
    {
        internal static bool TryParse<TEnum>(string member, out TEnum result) where TEnum : struct, IComparable
        {
            if (Enum.TryParse(member, true, out result))
                return true;

            return false;
        }
    }
}
