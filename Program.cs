using System.IO;
using System;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;
using Newtonsoft.Json;

namespace CustomDiscordRichPresence
{
    class Program
    {
        public static DiscordRpcClient client;
        public static Configuration config;
        static void Main()
        {
            if (File.Exists("./config.json")) {
                config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
            } else {
                Console.WriteLine("Creating a new configuration file");
                File.WriteAllText("./config.json", JsonConvert.SerializeObject(new Configuration(), Formatting.Indented));
                Console.WriteLine("New configuration file created, press any key to close this window");
                Console.ReadKey();
                Environment.Exit(0);
            }
            
            Start().GetAwaiter().GetResult();
        }

        public static async Task Start() {
            client = new DiscordRpcClient(config.ApplicationId);

            // Log any warnings into the console
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            // When the application has connected it will send "Ready!" to the console
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Ready!");
            };

            // This is code that is executed every time the presence is updated
            client.OnPresenceUpdate += (sender, e) => {};

            // Initializes the rich presence
            client.Initialize();


            // A timer that activates every second that will update the rich presence
            // to reflect the values in the config.json file
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, args) => {
                config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));

                // Sets the new presence
                client.SetPresence(new RichPresence() {
                    Details = config.Details,
                    State = config.State,
                    Assets = new DiscordRPC.Assets() {
                        LargeImageKey = config.LargeImageKey,
                        LargeImageText = config.LargeImageText,
                        SmallImageKey = config.SmallImageKey,
                        SmallImageText = config.SmallImageText
                    }
                });
            };
            timer.Start();

            // Makes sure the application doesn't quit
            await Task.Delay(-1);
        }
    }
}
