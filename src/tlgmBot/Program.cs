using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tlgmBot
{
    class Program
    {
        static string _APIToken = "143897472:AAHJsokXN9rpQizFRMcUlm0qGvAtJXgK-yo";

        static void Main(string[] args)
        {
            var _bot = new Telegram.Bot.Api(_APIToken);

            _bot.IsReceiving = true;

            //testApi(_bot);
            Answer(_bot);

            //Console.ReadLine();
        }

        static void testApi(Telegram.Bot.Api _bot)
        {
            var me = _bot.GetMe().Result;

            System.Console.WriteLine("Hello my name is " + me.FirstName);
        }

        static async void Answer(Telegram.Bot.Api _bot)
        {
            var me = await _bot.GetMe();

            _bot.StartReceiving();

            var messages = await _bot.GetUpdates();

            foreach (var item in messages)
            {
                switch (item.Message.Chat.Type)
                {
                    case Telegram.Bot.Types.ChatType.Private:
                        if (item.Message.Text.ToLower().Contains("oi"))
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, string.Format("Olá Danado(a), eu sou o {0}!", me.FirstName));
                        }
                        else if (item.Message.Text.ToLower().Contains("bom dia"))
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Bom dia Danados(as)!");
                        }
                        else if (item.Message.Text.ToLower().Contains("doideira"))
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "KKK");
                            welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Doideira hein?");
                        }
                        else
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Não entendi o que você falou!");
                            welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Meu dono ainda não me ensinou tudo.");
                        }
                        break;

                    case Telegram.Bot.Types.ChatType.Group:
                        if (item.Message.Text.ToLower().Contains("bom dia"))
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Bom dia Danados(as)!");
                        }

                        if (item.Message.Text.ToLower().Contains("doideira"))
                        {
                            var welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "KKK");
                            welcomeMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Doideira hein?");
                        }

                        if (item.Message.Text == "/command1")
                        {
                            var message = await _bot.SendTextMessage(item.Message.Chat.Id, "Oi Danado(a)!");
                        }
                        else if (item.Message.Text == "/command2")
                        {
                            var message = await _bot.SendTextMessage(item.Message.Chat.Id, "Beijos!");
                        }
                        else if (item.Message.Text == "/command3")
                        {
                            var message = await _bot.SendTextMessage(item.Message.Chat.Id, "Eu? Eu o que Danado(a)?");
                        }
                        break;

                    default:
                        break;
                }

                //var newMessage = await _bot.SendTextMessage(item.Message.Chat.Id, "Danado!");
            }

            _bot.StopReceiving();
        }
    }
}
