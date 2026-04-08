using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using FinanceApp2.Models;

namespace FinanceApp2.Services
{
    public class ChatService
    {
        private const string PipeName = "FinanceChatPipe";
        private List<Message> _messages;
        private readonly DataService _dataService;

        public event Action<Message> MessageReceived;

        public ChatService(DataService dataService)
        {
            _dataService = dataService;
            _messages = _dataService.LoadMessages();
        }

        public async Task StartServerAsync()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        using (var server = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 10))
                        {
                            await server.WaitForConnectionAsync();

                            using (var reader = new StreamReader(server))
                            using (var writer = new StreamWriter(server))
                            {
                                var messageText = await reader.ReadLineAsync();

                                if (!string.IsNullOrEmpty(messageText))
                                {
                                    var parts = messageText.Split('|');
                                    if (parts.Length == 3)
                                    {
                                        var message = new Message
                                        {
                                            Id = _messages.Count > 0 ? _messages.Max(m => m.Id) + 1 : 1,
                                            FromUser = parts[0],
                                            ToUser = parts[1],
                                            Text = parts[2],
                                            Timestamp = DateTime.Now
                                        };

                                        _messages.Add(message);
                                        _dataService.SaveMessages(_messages);
                                        MessageReceived?.Invoke(message);

                                        await writer.WriteLineAsync("OK");
                                        await writer.FlushAsync();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Server error: {ex.Message}");
                    }
                }
            });
        }

        public async Task<bool> SendMessageAsync(string fromUser, string toUser, string text)
        {
            try
            {
                using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut))
                {
                    await client.ConnectAsync(5000);

                    using (var writer = new StreamWriter(client))
                    using (var reader = new StreamReader(client))
                    {
                        var message = $"{fromUser}|{toUser}|{text}";
                        await writer.WriteLineAsync(message);
                        await writer.FlushAsync();

                        var response = await reader.ReadLineAsync();
                        return response == "OK";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Pipe Error: {ex.Message}");
                return false;
            }
        }

        public List<Message> GetMessagesForUser(string username)
        {
            return _messages.Where(m => m.ToUser == username || m.FromUser == username || m.ToUser == "all")
                           .OrderBy(m => m.Timestamp)
                           .ToList();
        }

        public List<Message> GetAllMessages()
        {
            return _messages.OrderBy(m => m.Timestamp).ToList();
        }
    }
}