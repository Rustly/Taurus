using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orion.Core;
using Orion.Core.Utils;

namespace Taurus.Commands
{
    public interface ICommandSender
    {
        public void SendMessage(string message);

        public void SendMessage(string message, Color3 color);
    }

    public static class CommandSenderExtensions
    {
        public static void SendInfoMessage(this ICommandSender sender, string message) => sender.SendMessage(message, new(100, 100, 100));

        public static void SendErrorMessage(this ICommandSender sender, string message) => sender.SendMessage(message, new(100, 100, 100));

        public static void SendSuccessMessage(this ICommandSender sender, string message) => sender.SendMessage(message, new(100, 100, 100));

        public static void SendWarningMessage(this ICommandSender sender, string message) => sender.SendMessage(message, new(100, 100, 100));

        public static void SendInfoMessage(this ICommandSender sender, string message, params object[] args) => sender.SendMessage(string.Format(message, args), new(100, 100, 100));

        public static void SendErrorMessage(this ICommandSender sender, string message, params object[] args) => sender.SendMessage(string.Format(message, args), new(100, 100, 100));

        public static void SendSuccessMessage(this ICommandSender sender, string message, params object[] args) => sender.SendMessage(string.Format(message, args), new(100, 100, 100));

        public static void SendWarningMessage(this ICommandSender sender, string message, params object[] args) => sender.SendMessage(string.Format(message, args), new(100, 100, 100));
    }
}
