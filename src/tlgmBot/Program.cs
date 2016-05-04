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
            var Bot = new Api("API-KEY");

            var me = await Bot.GetMe();

            var offset = 0;

            while (true)
            {
                var updates = await Bot.GetUpdates(offset);

                foreach (var update in updates)
                {
                    if (update.Message != null && !string.IsNullOrEmpty(update.Message.Text))
                    {
                        Console.WriteLine("*");

                        Message t;

                        switch (update.Message.Chat.Type)
                        {
                            case ChatType.Private:
                                
                                await Bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                                await Task.Delay(2000);

                                if (!string.IsNullOrEmpty(update.Message.Chat.FirstName) && update.Message.Chat.FirstName.ToLower().Contains("raul"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Pesou!");
                                }

                                if (update.Message.Text.ToLower().Equals("oi"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, string.Format("Olá, eu sou o {0}!", me.FirstName));
                                }
                                else if (update.Message.Text.ToLower().Contains("bom dia"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Bom dia Danado(a)!");
                                }
                                else if (update.Message.Text.ToLower().Contains("doideira"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "KKK");
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Doideira hein?");
                                }
                                else if (update.Message.Text.ToLower().Equals("danado"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Danadoooooooooo!");
                                }
                                else if (update.Message.Text.ToLower().Equals("danada"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Danadaaaaaaaaaa!");
                                }
                                else
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Não entendi o que você falou!");
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Meu dono ainda não me ensinou tudo.");
                                }
                                break;

                            case ChatType.Channel:
                            case ChatType.Group:
                            case ChatType.Supergroup:

                                await Bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
                                await Task.Delay(2000);

                                if (!string.IsNullOrEmpty(update.Message.Chat.FirstName) && update.Message.Chat.FirstName.ToLower().Contains("raul"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Pesou!");
                                }

                                if (update.Message.Text.ToLower().Contains("pesou"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Pesou meu irmão!");
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "E vai pesar mais ainda!");
                                }

                                if (update.Message.Text.ToLower().Contains("bom dia"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Bom dia Danados(as)!");
                                }

                                if (update.Message.Text.ToLower().Contains("doideira"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "KKK");
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Doideira hein?");
                                }

                                if (update.Message.Text.ToLower().Equals("danado"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Danadoooooooooo!");
                                }

                                if (update.Message.Text.ToLower().Equals("danada"))
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Danadaaaaaaaaaa!");
                                }

                                if (update.Message.Text == "/start")
                                {
                                    t = await Bot.SendTextMessage(update.Message.Chat.Id, "Oi!");
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
                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }
    }
}
