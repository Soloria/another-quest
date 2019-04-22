namespace Soloria
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using System.ComponentModel;

    public static class Config
    {
        public static void StartUp()
        {
            if (root != null) return;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Assembly.GetExecutingAssembly().Location
                    .Replace(Path.GetFileName(Assembly.GetExecutingAssembly().Location), ""))
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            root = builder.Build();
        }

        private static IConfigurationRoot root;

        public static T GetValue<T>(string key, T defaultValue = default)
        {
            return root?[key] == null ? defaultValue : ProcessTypes<T>(root[key]);
        }

        internal static T ProcessTypes<T>(string value)
        {
            if(TypeDescriptor.GetConverter(typeof(T)).CanConvertFrom(typeof(string)))
                throw new Exception("something going wrong lol");
            return TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
        }
    }
 }
