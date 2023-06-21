using Newtonsoft.Json;
using Telegram.Bot;
using Domain;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using File = System.IO.File;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var botClient = new TelegramBotClient("5625302969:AAHrEI05o4-IDjQ1I5KBla8pJPG5DFUM_j4");

            using CancellationTokenSource cts = new();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7178/api/User");

            Console.Write(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            //Send cancellation request to stop bot
            cts.Cancel();
        }

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            switch (messageText)
            {
                case "Привет":
                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"Здравствуй, {message.From.FirstName}!",
                        cancellationToken: cancellationToken);
                    break;
                case "Картинка":
                    await botClient.SendPhotoAsync(chatId, photo: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg"), caption: "Отправляю вам красивую картинку!", cancellationToken: cancellationToken);
                    break;
                case "Видео":
                    await botClient.SendVideoAsync(chatId, video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
    thumbnail: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/2/docs/thumb-clock.jpg"), caption: "Посмотри это видео!", cancellationToken: cancellationToken);
                    break;
                case "Стикер":
                    await botClient.SendStickerAsync(chatId, sticker: InputFile.FromUri("https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp"), cancellationToken: cancellationToken);
                    break;
                case "Кнопки":
                    var replyMarkup = new InlineKeyboardMarkup(
                        new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("Кнопка 1"),
                                InlineKeyboardButton.WithCallbackData("Кнопка 2")
                            }
                        });

                    await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Выберите одну из кнопок:",
                        replyMarkup: replyMarkup,
                        cancellationToken: cancellationToken);
                    break;
                default:
                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Вы отправили текстовое сообщение.",
                        cancellationToken: cancellationToken);
                    break;
            }
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString() 
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

    }
}