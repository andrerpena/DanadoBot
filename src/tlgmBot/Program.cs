using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using File = System.IO.File;

namespace tlgmBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            var Bot = new Api("API_KEY");

            var me = await Bot.GetMe();

            Console.WriteLine("Hello my name is {0}", me.Username);

            var offset = 0;

            while (true)
            {
                var updates = await Bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    Message t;

                    switch (update.Message.Chat.Type)
                    {
                        case ChatType.Private:

                            await Bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                            await Task.Delay(2000);

                            if (update.Message.Text.ToLower().Contains("oi"))
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, string.Format("Olá Danado(a), eu sou o {0}!", me.FirstName));
                                Console.WriteLine("Echo Message: {0}", update.Message.Text);
                            }
                            else if (update.Message.Text.ToLower().Contains("bom dia"))
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Bom dia Danados(as)!");
                            }
                            else if (update.Message.Text.ToLower().Contains("doideira"))
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "KKK");
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Doideira hein?");
                            }
                            else
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Não entendi o que você falou!");
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Meu dono ainda não me ensinou tudo.");
                            }
                            break;

                        case Telegram.Bot.Types.ChatType.Group:

                            await Bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                            await Task.Delay(2000);
                            
                            if (update.Message.Text.ToLower().Contains("bom dia"))
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Bom dia Danados(as)!");
                            }

                            if (update.Message.Text.ToLower().Contains("doideira"))
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "KKK");
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Doideira hein?");
                            }

                            if (update.Message.Text == "/command1")
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Oi Danado(a)!");
                            }
                            else if (update.Message.Text == "/command2")
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Beijos!");
                            }
                            else if (update.Message.Text == "/command3")
                            {
                                t = await Bot.SendTextMessage(update.Message.Chat.Id, "Eu? Eu o que Danado(a)?");
                            }
                            break;

                        default:
                            break;
                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }
    }
}
